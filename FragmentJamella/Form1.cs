using System;
using System.Windows.Forms;
using Memory;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

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

            tmr_Attach.Enabled = false;
            tmr_readMem.Enabled = true;
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
                lbl_Model.Text = m.ReadString((gGameOffset + 0x3C).ToString("X8"));
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(pcsx2Running)
            {
                m.WriteMemory((gGameOffset + 0x3C).ToString("X8"), "string", label11.Text);
                m.WriteMemory((gGameOffset + 0x8884).ToString("X8"), "byte", comboBox1.SelectedIndex.ToString("X1"));
                m.WriteMemory((gGameOffset + 0x3759).ToString("X8"), "byte", comboBox1.SelectedIndex.ToString("X1"));
                m.WriteMemory((gGameOffset + 0x375A).ToString("X8"), "byte", comboBox2.SelectedIndex.ToString("X1"));
                m.WriteMemory((gGameOffset + 0x375B).ToString("X8"), "byte", comboBox3.SelectedIndex.ToString("X1"));
                m.WriteMemory((gGameOffset + 0x375C).ToString("X8"), "byte", (3*comboBox4.SelectedIndex + comboBox5.SelectedIndex).ToString("X1"));
            }
        }


        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label11.Text = (GetModelFromData(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox5.SelectedIndex));
            panel1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(label11.Text);
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
    }
}
