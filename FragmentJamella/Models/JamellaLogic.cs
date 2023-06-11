using System;
using System.ComponentModel;
using System.Text;
using FragmentJamella.Helpers;
using MemoryIO.Pcsx2;

namespace FragmentJamella.Models
{
    public class JamellaLogic
    {
        private int gGameOffset;
        private Pcsx2MemoryIO m;
        private readonly Encoding enc;

        private bool loggedIn = false;

        public JamellaLogic()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            enc = Encoding.GetEncoding("Shift-JIS");
            m = new Pcsx2MemoryIO(enc);
            Update_Tick();
        }

        
        public bool Update_Tick()
        {
            if (!m.Pcsx2Running || !m.IsAttached)
            {
                m.Update();
            }
            if (m.IsAttached)
            {
                SetGameOffset();
            }
            return m.IsAttached && loggedIn;
        }

        private void SetGameOffset()
        {
            if (m.IsAttached)
            {
                int luiHeap = 0;
                try 
                {
                    luiHeap = m.Read<byte>(GameHelper.LUI_HEAP);
                }
                catch (Win32Exception e)
                {
                    var removeWarning = e.Message; // :)
                }
                //Online
                if (GameHelper.GetCurrentElfFile(luiHeap) == GameHelper.CurrentElf.ONLINE)
                {
                    gGameOffset = m.Read<int>(new IntPtr(GameHelper.ONLINE_PLAYER_POINTER));
                    if (m.Read<int>(new IntPtr(GameHelper.ONLINE_LOAD_STATE)) == 5) loggedIn = true;
                    else loggedIn = false;
                }
                //Offline
                else if (GameHelper.GetCurrentElfFile(luiHeap) == GameHelper.CurrentElf.OFFLINE)
                {
                    gGameOffset = m.Read<int>(new IntPtr(GameHelper.OFFLINE_PLAYER_POINTER));
                    if (m.Read<int>(new IntPtr(GameHelper.OFFLINE_LOAD_STATE)) == 5) loggedIn = true;
                    else loggedIn = false;
                }
                else loggedIn = false;
            }
        }

        public string GetGameMode()
        {
            if (m.IsAttached)
            {
                int luiHeap = 0;
                try
                {
                    luiHeap = m.Read<byte>(new IntPtr(GameHelper.LUI_HEAP));
                }
                catch (Win32Exception e)
                {
                    var removeWarning = e.Message; // :)
                }
                //Online
                if (GameHelper.GetCurrentElfFile(luiHeap) == GameHelper.CurrentElf.ONLINE)
                {
                    return "Online";
                }
                //Offline
                else if (GameHelper.GetCurrentElfFile(luiHeap) == GameHelper.CurrentElf.OFFLINE)
                {
                    return "Offline";
                }
            }
            return "None";
        }

        public string GetCharacterName()
        {
            if (m.IsAttached && loggedIn) return m.ReadString(new IntPtr(gGameOffset + GameHelper.PLAYER_NAME), enc);
            return "";
        }
        public string GetWarning()
        {
            if (m.IsAttached && loggedIn) return "";
            else if (!m.IsAttached) return "Cannot Find PCSX2";
            return "Character Not Logged In";
        }

        public int[] GetModelValues()
        {
            if (m.IsAttached && loggedIn)
            {
                return new int[] {
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_CLASS)),
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_MODEL)),
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_COLOR)),
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_SIZE)) / 3,
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_SIZE)) % 3};
            }
            else return new int[] { 0, 0, 0, 1, 1 };
        }

        public string GetModelFromData(int charClass, int charModelNum, int charColor, int charHeight, int charWidth)
        {
            string model = "c";
            if (charClass <= 5 && charClass >= 0) model += new string[] { "t", "b", "h", "a", "l", "w" }[charClass];
            else model += "t";

            if (charModelNum <= GetModelCountFromClass(charClass) && charModelNum >= 0) model += (charModelNum + 1).ToString("X1").ToLower();
            else model += "1";

            if (model == "ch3") model = "ch5";
            else if (model == "ch5") model = "ch3";

            if (charHeight > 2 || charHeight < 0) charHeight = 1;
            if (charWidth > 2 || charWidth < 0) charWidth = 1;
            model += ((char)('a' + (charHeight * 3) + charWidth));

            model += "b_";

            if (charColor <= 5 && charColor >= 0) model += new string[] { "rd", "bl", "yl", "gr", "br", "pp" }[charColor];
            else model += "rd";

            return model;
        }
        public int GetModelCountFromClass(int charClass)
        {
            if (charClass <= 5 && charClass >= 0) return new int[] { 8, 10, 6, 5, 6, 6 }[charClass];
            else return 0;
        }
        public int[] GetBonusStats(string model, int[] sliders = null)
        {
            sliders = sliders ?? new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            return StatHelper.SliderStats(model, sliders);
        }

        public void updateCharcter(int charClass, int charModelNum, int charColor, int charHeight, int charWidth)
        {
            string newmodel = GetModelFromData(charClass, charModelNum, charColor, charHeight, charWidth);

            if (m.IsAttached && loggedIn)
            {
                m.WriteString(new IntPtr(gGameOffset + GameHelper.PLAYER_MODEL_STRING), newmodel, enc);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_CLASS), (byte)charClass);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_CLASS), (byte)charClass);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_MODEL), (byte)charModelNum);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_COLOR), (byte)charColor);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_SIZE), (byte)(3 * charHeight + charWidth));
            }
        }

        public void updateStats(int[] statSliders = null)
        {

            if (m.IsAttached && loggedIn)
            {
                string model = m.ReadString(new IntPtr(gGameOffset + GameHelper.PLAYER_MODEL_STRING), enc);
                int level = m.Read<short>(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_LEVEL));
                int[] newstats = StatHelper.GetStats(model, level, statSliders);

                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_HP), (short)newstats[0]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_SP), (short)newstats[1]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_PATK), (short)newstats[2]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_PDEF), (short)newstats[3]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_PHIT), (short)newstats[4]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_PEVA), (short)newstats[5]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MATK), (short)newstats[6]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MDEF), (short)newstats[7]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MHIT), (short)newstats[8]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MEVA), (short)newstats[9]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_EARTH), (short)newstats[10]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_WATER), (short)newstats[11]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_FIRE), (short)newstats[12]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_WOOD), (short)newstats[13]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_THUNDER), (short)newstats[14]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_DARK), (short)newstats[15]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MIND), (short)newstats[16]);
                m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_BODY), (short)newstats[17]);
            }
        }
        
        
    }
}
