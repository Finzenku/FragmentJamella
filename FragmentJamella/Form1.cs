using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using FragmentJamella.Helpers;
using Binarysharp.MemoryManagement;

namespace FragmentJamella
{
    public partial class Form1 : Form
    {
        int gGameOffset;
        MemorySharp m;
        Encoding enc = Encoding.GetEncoding(932);
        
        private const string PCSX2PROCESSNAME = "pcsx2";
        bool pcsx2Running = false;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox5.SelectedIndex = 1;
            comboBox4.SelectedIndex = 1;

        }

        private void tmr_Attach_Tick(object sender, EventArgs e)
        {
            PCSX2Check_Tick();
            if (pcsx2Running)
            {
                m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME)[0]);
                SetGameOffset();
                SetComboBoxesFromData();
                tmr_Attach.Enabled = false;
                tmr_readMem.Enabled = true;
            }

        }

        private void tmr_readMem_Tick(object sender, EventArgs e)
        {
            PCSX2Check_Tick();
            if (pcsx2Running)
            {
                SetGameOffset();
                lbl_Name.Text = m.ReadString(new IntPtr(gGameOffset + GameHelper.PLAYER_NAME), enc, false);
            }
        }

        private void PCSX2Check_Tick()
        {
            Process[] pcsx2 = Process.GetProcessesByName(PCSX2PROCESSNAME);

            if (pcsx2.Length > 0)
            {
                pcsx2Running = true;
            }
            else
            {
                MessageBox.Show("PCSX2 not detected. Closing.");
                this.Close();
            }
        }

        private void SetGameOffset()
        {
            if (pcsx2Running)
            {
                if (GameHelper.GetCurrentElfFile(m.Read<byte>(new IntPtr(GameHelper.LUI_HEAP),false)) == GameHelper.CurrentElf.ONLINE)
                {
                    label1.Text = "Online";
                    gGameOffset = m.Read<int>(new IntPtr(GameHelper.ONLINE_PLAYER_POINTER),false) + 0x20000000;
                }
                if (GameHelper.GetCurrentElfFile(m.Read<byte>(new IntPtr(GameHelper.LUI_HEAP),false)) == GameHelper.CurrentElf.OFFLINE)
                {
                    label1.Text = "Offline";
                    gGameOffset = m.Read<int>(new IntPtr(GameHelper.OFFLINE_PLAYER_POINTER),false) + 0x20000000;
                }
            }
        }

        private void SetComboBoxesFromData()
        {
            int i = m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_CLASS), false);
            if (i < comboBox1.Items.Count) comboBox1.SelectedIndex = i;
            i = m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_MODEL), false);
            if (i < comboBox2.Items.Count) comboBox2.SelectedIndex = i;
            i = m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_COLOR), false);
            if (i < comboBox3.Items.Count) comboBox3.SelectedIndex = i;
            i = m.Read<byte>(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_SIZE), false);
            if ((i / 3) < comboBox4.Items.Count) comboBox4.SelectedIndex = (i / 3);
            if ((i % 3) < comboBox5.Items.Count) comboBox5.SelectedIndex = (i % 3);
        }

        private string GetModelFromData(int charClass, int charModelNum, int charColor, int charHeight, int charWidth)
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

        private int GetModelCountFromClass(int charClass)
        {
            if (charClass <= 5 && charClass >= 0) return new int[] { 8, 10, 6, 5, 6, 6 }[charClass];
            else return 0;
        }
        private string CalculateNewAddress(string baseAddress, int offset)
        {
            return (int.Parse(baseAddress, System.Globalization.NumberStyles.HexNumber) + offset).ToString("X8");
        }

        private string GetModelFromComboBoxes()
        {
            return GetModelFromData(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox5.SelectedIndex);
        }


        private void updateCharcter()
        {
            string newmodel = GetModelFromComboBoxes();

            m.WriteString(new IntPtr(gGameOffset + GameHelper.PLAYER_MODEL_STRING), newmodel, enc, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_CLASS), (byte)comboBox1.SelectedIndex, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_CLASS), (byte)comboBox1.SelectedIndex, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_MODEL), (byte)comboBox2.SelectedIndex, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_COLOR), (byte)comboBox3.SelectedIndex, false);
            m.Write(new IntPtr(gGameOffset + GameHelper.PLAYER_CHARACTER_SIZE), (byte)(3*comboBox4.SelectedIndex + comboBox5.SelectedIndex), false);
            if (ckBox_Stats.Checked) updateStats();
        }

        private void updateStats()
        {
            string model = m.ReadString(new IntPtr(gGameOffset + GameHelper.PLAYER_MODEL_STRING), enc, false);
            int level = m.Read<short>(new IntPtr(gGameOffset + GameHelper.PLAYER_STATS_LEVEL), false);
            int[] newstats = StatHelper.GetStats(model, level, statSliders1.GetSliders());
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(pcsx2Running)
            {
                updateCharcter();
            }
        }


        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(GetModelFromComboBoxes());
            UpdateBonusStats(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int b2index = comboBox2.SelectedIndex, count = GetModelCountFromClass(comboBox1.SelectedIndex);
            object[] o = new object[count];

            for (int i = 0; i < count; i++)
            {
                o[i] = (char)('A' + i);
            }
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(o);
            if (b2index >= count) comboBox2.SelectedIndex = 0;
            else comboBox2.SelectedIndex = b2index;

            comboBox_SelectedIndexChanged(sender, e);
        }
        
        private void UpdateBonusStats(object sender, EventArgs e)
        {
            int[] stats = StatHelper.SliderStats(GetModelFromComboBoxes(), statSliders1.GetSliders());
            lbl_bonus_patk.Text = "+" + stats[0] / 10 + "." + stats[0] % 10;
            lbl_bonus_pdef.Text = "+" + stats[1] / 10 + "." + stats[1] % 10;
            lbl_bonus_phit.Text = "+" + stats[2] / 10 + "." + stats[2] % 10;
            lbl_bonus_peva.Text = "+" + stats[3] / 10 + "." + stats[3] % 10;
            lbl_bonus_matk.Text = "+" + stats[4] / 10 + "." + stats[4] % 10;
            lbl_bonus_mdef.Text = "+" + stats[5] / 10 + "." + stats[5] % 10;
            lbl_bonus_mhit.Text = "+" + stats[6] / 10 + "." + stats[6] % 10;
            lbl_bonus_meva.Text = "+" + stats[7] / 10 + "." + stats[7] % 10;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            SetComboBoxesFromData();
        }
    }
}
