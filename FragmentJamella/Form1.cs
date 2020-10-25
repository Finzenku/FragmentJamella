using System;
using System.Windows.Forms;
using Memory;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;
using FragmentJamella.Helpers;

namespace FragmentJamella
{
    public partial class Form1 : Form
    {
        int gGameOffset;
        Mem m = new Mem();
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
            m.OpenProcess(PCSX2PROCESSNAME + ".exe");
            tmr_Attach.Enabled = m.IsAdmin();
            if (!m.IsAdmin()) label1.Text = "Not running as Admin";

        }

        private void tmr_Attach_Tick(object sender, EventArgs e)
        {
            if (pcsx2Running)
            {
                m.OpenProcess(PCSX2PROCESSNAME + ".exe");
                SetGameOffset();
                SetComboBoxesFromData();
                tmr_Attach.Enabled = false;
                tmr_readMem.Enabled = true;
            }

        }

        private void tmr_PCSX2Check_Tick(object sender, EventArgs e)
        {
            Process[] pcsx2 = Process.GetProcessesByName(PCSX2PROCESSNAME);

            if (pcsx2.Length > 0)
            {
                pcsx2Running = true;
            }
            else
            {
                tmr_PCSX2Check.Enabled = false;
                MessageBox.Show("PCSX2 not detected. Closing.");
                this.Close();
            }
        }

        private void tmr_readMem_Tick(object sender, EventArgs e)
        {
            if (pcsx2Running)
            {
                SetGameOffset();
                lbl_Name.Text = m.ReadString((gGameOffset + 0xC).ToString("X8"));
            }
        }

        private void SetGameOffset()
        {
            if (pcsx2Running)
            {
                if (GameHelper.GetCurrentElfFile(m.ReadByte(GameHelper.LUI_HEAP)) == GameHelper.CurrentElf.ONLINE)
                {
                    label1.Text = "Online";
                    gGameOffset = m.ReadInt(GameHelper.ONLINE_PLAYER_POINTER) + 0x20000000;
                }
                if (GameHelper.GetCurrentElfFile(m.ReadByte(GameHelper.LUI_HEAP)) == GameHelper.CurrentElf.OFFLINE)
                {
                    label1.Text = "Offline";
                    gGameOffset = m.ReadInt(GameHelper.OFFLINE_PLAYER_POINTER) + 0x20000000;
                }

            }
        }

        private void SetComboBoxesFromData()
        {
            int i = m.ReadByte((gGameOffset + 0x3759).ToString("X8"));
            if (i < comboBox1.Items.Count) comboBox1.SelectedIndex = i;
            i = m.ReadByte((gGameOffset + 0x375A).ToString("X8"));
            if (i < comboBox2.Items.Count) comboBox2.SelectedIndex = i;
            i = m.ReadByte((gGameOffset + 0x375B).ToString("X8"));
            if (i < comboBox3.Items.Count) comboBox3.SelectedIndex = i;
            i = m.ReadByte((gGameOffset + 0x375C).ToString("X8"));
            if ((i / 3) < comboBox4.Items.Count) comboBox4.SelectedIndex = (i / 3);
            i = m.ReadByte((gGameOffset + 0x375C).ToString("X8"));
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

            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_MODEL_STRING, gGameOffset), "string", newmodel);
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_CLASS, gGameOffset), "byte", comboBox1.SelectedIndex.ToString("X1"));
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_CHARACTER_CLASS, gGameOffset), "byte", comboBox1.SelectedIndex.ToString("X1"));
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_CHARACTER_MODEL, gGameOffset), "byte", comboBox2.SelectedIndex.ToString("X1"));
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_CHARACTER_COLOR, gGameOffset), "byte", comboBox3.SelectedIndex.ToString("X1"));
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_CHARACTER_SIZE, gGameOffset), "byte", (3 * comboBox4.SelectedIndex + comboBox5.SelectedIndex).ToString("X1"));

            if (ckBox_Stats.Checked) updateStats();
        }

        private void updateStats()
        {
            string model = m.ReadString(CalculateNewAddress(GameHelper.PLAYER_MODEL_STRING, gGameOffset));
            int level = ByteConverstionHelper.convertBytesToInt(m.ReadBytes(CalculateNewAddress(GameHelper.PLAYER_STATS_LEVEL, gGameOffset), 2));
            int[] newstats = StatHelper.GetStats(model, level, statSliders1.GetSliders());

            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_HP, gGameOffset), "2bytes", newstats[0].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_SP, gGameOffset), "2bytes", newstats[1].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_PATK, gGameOffset), "2bytes", newstats[2].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_PDEF, gGameOffset), "2bytes", newstats[3].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_PHIT, gGameOffset), "2bytes", newstats[4].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_PEVA, gGameOffset), "2bytes", newstats[5].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_MATK, gGameOffset), "2bytes", newstats[6].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_MDEF, gGameOffset), "2bytes", newstats[7].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_MHIT, gGameOffset), "2bytes", newstats[8].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_MEVA, gGameOffset), "2bytes", newstats[9].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_EARTH, gGameOffset), "2bytes", newstats[10].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_WATER, gGameOffset), "2bytes", newstats[11].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_FIRE, gGameOffset), "2bytes", newstats[12].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_WOOD, gGameOffset), "2bytes", newstats[13].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_THUNDER, gGameOffset), "2bytes", newstats[14].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_DARK, gGameOffset), "2bytes", newstats[15].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_MIND, gGameOffset), "2bytes", newstats[16].ToString());
            m.WriteMemory(CalculateNewAddress(GameHelper.PLAYER_STATS_BODY, gGameOffset), "2bytes", newstats[17].ToString());
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
