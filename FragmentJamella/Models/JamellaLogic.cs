using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FragmentJamella.Helpers;
using FragmentJamella.Memory;

namespace FragmentJamella.Models
{
    public class JamellaLogic
    {
        private int gGameOffset;
        private IMemoryManagement m;
        private readonly Encoding enc;

        private const string PCSX2PROCESSNAME = "pcsx2";
        private bool pcsx2Running = false;

        public JamellaLogic()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            enc = Encoding.GetEncoding(932);
            Attach_Tick();
        }
        public bool Attach_Tick()
        {
            PCSX2Check();
            if (pcsx2Running)
            {
                if (System.Environment.OSVersion.Platform == PlatformID.Unix ||
                    System.Environment.OSVersion.Platform == PlatformID.MacOSX)
                {
                    m = new LinuxMemoryManagement(Process.GetProcessesByName(PCSX2PROCESSNAME)[0]);
                }
                else
                {
                    m = new WindowsMemoryManagement(Process.GetProcessesByName(PCSX2PROCESSNAME)[0]);
                }
                SetGameOffset();
            }
            return pcsx2Running;
        }

        private void PCSX2Check()
        {
            if (System.Environment.OSVersion.Platform == PlatformID.Unix ||
                System.Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                if (LinuxMemoryManagement.getuid() != 0)
                {
                    //throw new Exception("Not running as root");
                }
            }
            Process[] pcsx2 = Process.GetProcessesByName(PCSX2PROCESSNAME);
            if (pcsx2.Length > 0)
            {
                pcsx2Running = true;
            }
            else
            {
                pcsx2Running = false;
            }
        }

        private void SetGameOffset()
        {
            if (pcsx2Running)
            {
                //Online
                if (GameHelper.GetCurrentElfFile(m.Read<byte>(new IntPtr(GameHelper.LUI_HEAP), false)) == GameHelper.CurrentElf.ONLINE)
                {
                    gGameOffset = m.Read<int>(new IntPtr(GameHelper.ONLINE_PLAYER_POINTER), false) + 0x20000000;
                }
                //Offline
                if (GameHelper.GetCurrentElfFile(m.Read<byte>(new IntPtr(GameHelper.LUI_HEAP), false)) == GameHelper.CurrentElf.OFFLINE)
                {
                    gGameOffset = m.Read<int>(new IntPtr(GameHelper.OFFLINE_PLAYER_POINTER), false) + 0x20000000;
                }
            }
        }

        public int[] GetModelValues()
        {
            if (pcsx2Running)
            {
                return new int[] {
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_CLASS), false),
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_MODEL), false),
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_COLOR), false),
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_SIZE), false) / 3,
                m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_SIZE), false) % 3};
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

            m.WriteString(new IntPtr(gGameOffset + GameHelper.PLAYER_MODEL_STRING), newmodel, enc, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_CLASS), (byte)charClass, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_CLASS), (byte)charClass, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_MODEL), (byte)charModelNum, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_COLOR), (byte)charColor, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_SIZE), (byte)(3 * charHeight + charWidth), false);
        }

        public void updateStats(int[] statSliders = null)
        {
            string model = m.ReadString(new IntPtr(gGameOffset + GameHelper.PLAYER_MODEL_STRING), enc, false);
            int level = m.Read<short>(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_LEVEL), false);
            int[] newstats = StatHelper.GetStats(model, level, statSliders);

            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_HP), (short)newstats[0], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_SP), (short)newstats[1], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_PATK), (short)newstats[2], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_PDEF), (short)newstats[3], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_PHIT), (short)newstats[4], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_PEVA), (short)newstats[5], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MATK), (short)newstats[6], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MDEF), (short)newstats[7], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MHIT), (short)newstats[8], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MEVA), (short)newstats[9], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_EARTH), (short)newstats[10], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_WATER), (short)newstats[11], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_FIRE), (short)newstats[12], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_WOOD), (short)newstats[13], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_THUNDER), (short)newstats[14], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_DARK), (short)newstats[15], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_MIND), (short)newstats[16], false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_BODY), (short)newstats[17], false);
        }
    }
}
