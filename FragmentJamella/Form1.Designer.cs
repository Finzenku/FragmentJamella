namespace FragmentJamella
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmr_readMem = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.tmr_Attach = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_bonus_patk = new System.Windows.Forms.Label();
            this.lbl_bonus_pdef = new System.Windows.Forms.Label();
            this.lbl_bonus_phit = new System.Windows.Forms.Label();
            this.lbl_bonus_peva = new System.Windows.Forms.Label();
            this.lbl_bonus_matk = new System.Windows.Forms.Label();
            this.lbl_bonus_mdef = new System.Windows.Forms.Label();
            this.lbl_bonus_mhit = new System.Windows.Forms.Label();
            this.lbl_bonus_meva = new System.Windows.Forms.Label();
            this.ckBox_Stats = new System.Windows.Forms.CheckBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.statSliders1 = new FragmentJamella.Controls.StatSliders();
            this.SuspendLayout();
            // 
            // tmr_readMem
            // 
            this.tmr_readMem.Tick += new System.EventHandler(this.tmr_readMem_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Twin Blade",
            "Blademaster",
            "Heavy Blade",
            "Heavy Axe",
            "Long Arm",
            "Wavemaster"});
            this.comboBox1.Location = new System.Drawing.Point(57, 70);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H"});
            this.comboBox2.Location = new System.Drawing.Point(57, 103);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 23);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Red (Fire)",
            "Blue (Water)",
            "Yellow (Thunder)",
            "Green (Wood)",
            "Brown (Earth)",
            "Purple (Darkness)"});
            this.comboBox3.Location = new System.Drawing.Point(57, 134);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(140, 23);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Skinny",
            "Medium",
            "Fat"});
            this.comboBox5.Location = new System.Drawing.Point(57, 196);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(140, 23);
            this.comboBox5.TabIndex = 8;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Short",
            "Medium",
            "Tall"});
            this.comboBox4.Location = new System.Drawing.Point(57, 165);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(140, 23);
            this.comboBox4.TabIndex = 7;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 297);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Update Character";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Connecting..";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Model:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Height:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 205);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Width:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Character Name:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(281, 10);
            this.lbl_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(29, 15);
            this.lbl_Name.TabIndex = 17;
            this.lbl_Name.Text = "N/A";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmr_Attach
            // 
            this.tmr_Attach.Enabled = true;
            this.tmr_Attach.Tick += new System.EventHandler(this.tmr_Attach_Tick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(204, 70);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 194);
            this.panel1.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(135, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "Class Changer:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 10);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Game Mode:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(421, 44);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 18);
            this.label13.TabIndex = 26;
            this.label13.Text = "Bonus Stats:";
            // 
            // lbl_bonus_patk
            // 
            this.lbl_bonus_patk.AutoSize = true;
            this.lbl_bonus_patk.Location = new System.Drawing.Point(400, 123);
            this.lbl_bonus_patk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bonus_patk.Name = "lbl_bonus_patk";
            this.lbl_bonus_patk.Size = new System.Drawing.Size(30, 15);
            this.lbl_bonus_patk.TabIndex = 27;
            this.lbl_bonus_patk.Text = "+0.0";
            // 
            // lbl_bonus_pdef
            // 
            this.lbl_bonus_pdef.AutoSize = true;
            this.lbl_bonus_pdef.Location = new System.Drawing.Point(400, 152);
            this.lbl_bonus_pdef.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bonus_pdef.Name = "lbl_bonus_pdef";
            this.lbl_bonus_pdef.Size = new System.Drawing.Size(30, 15);
            this.lbl_bonus_pdef.TabIndex = 28;
            this.lbl_bonus_pdef.Text = "+0.0";
            // 
            // lbl_bonus_phit
            // 
            this.lbl_bonus_phit.AutoSize = true;
            this.lbl_bonus_phit.Location = new System.Drawing.Point(400, 181);
            this.lbl_bonus_phit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bonus_phit.Name = "lbl_bonus_phit";
            this.lbl_bonus_phit.Size = new System.Drawing.Size(30, 15);
            this.lbl_bonus_phit.TabIndex = 29;
            this.lbl_bonus_phit.Text = "+0.0";
            // 
            // lbl_bonus_peva
            // 
            this.lbl_bonus_peva.AutoSize = true;
            this.lbl_bonus_peva.Location = new System.Drawing.Point(400, 210);
            this.lbl_bonus_peva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bonus_peva.Name = "lbl_bonus_peva";
            this.lbl_bonus_peva.Size = new System.Drawing.Size(30, 15);
            this.lbl_bonus_peva.TabIndex = 30;
            this.lbl_bonus_peva.Text = "+0.0";
            // 
            // lbl_bonus_matk
            // 
            this.lbl_bonus_matk.AutoSize = true;
            this.lbl_bonus_matk.Location = new System.Drawing.Point(400, 239);
            this.lbl_bonus_matk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bonus_matk.Name = "lbl_bonus_matk";
            this.lbl_bonus_matk.Size = new System.Drawing.Size(30, 15);
            this.lbl_bonus_matk.TabIndex = 31;
            this.lbl_bonus_matk.Text = "+0.0";
            // 
            // lbl_bonus_mdef
            // 
            this.lbl_bonus_mdef.AutoSize = true;
            this.lbl_bonus_mdef.Location = new System.Drawing.Point(400, 268);
            this.lbl_bonus_mdef.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bonus_mdef.Name = "lbl_bonus_mdef";
            this.lbl_bonus_mdef.Size = new System.Drawing.Size(30, 15);
            this.lbl_bonus_mdef.TabIndex = 32;
            this.lbl_bonus_mdef.Text = "+0.0";
            // 
            // lbl_bonus_mhit
            // 
            this.lbl_bonus_mhit.AutoSize = true;
            this.lbl_bonus_mhit.Location = new System.Drawing.Point(400, 297);
            this.lbl_bonus_mhit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bonus_mhit.Name = "lbl_bonus_mhit";
            this.lbl_bonus_mhit.Size = new System.Drawing.Size(30, 15);
            this.lbl_bonus_mhit.TabIndex = 33;
            this.lbl_bonus_mhit.Text = "+0.0";
            // 
            // lbl_bonus_meva
            // 
            this.lbl_bonus_meva.AutoSize = true;
            this.lbl_bonus_meva.Location = new System.Drawing.Point(400, 325);
            this.lbl_bonus_meva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bonus_meva.Name = "lbl_bonus_meva";
            this.lbl_bonus_meva.Size = new System.Drawing.Size(30, 15);
            this.lbl_bonus_meva.TabIndex = 34;
            this.lbl_bonus_meva.Text = "+0.0";
            // 
            // ckBox_Stats
            // 
            this.ckBox_Stats.AutoSize = true;
            this.ckBox_Stats.Checked = true;
            this.ckBox_Stats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBox_Stats.Location = new System.Drawing.Point(205, 305);
            this.ckBox_Stats.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckBox_Stats.Name = "ckBox_Stats";
            this.ckBox_Stats.Size = new System.Drawing.Size(91, 19);
            this.ckBox_Stats.TabIndex = 35;
            this.ckBox_Stats.Text = "Update stats";
            this.ckBox_Stats.UseVisualStyleBackColor = true;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(57, 230);
            this.btn_Reset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(140, 24);
            this.btn_Reset.TabIndex = 36;
            this.btn_Reset.Text = "Reset to current";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // statSliders1
            // 
            this.statSliders1.Location = new System.Drawing.Point(0, 0);
            this.statSliders1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.statSliders1.Name = "statSliders1";
            this.statSliders1.Size = new System.Drawing.Size(214, 292);
            this.statSliders1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 360);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.ckBox_Stats);
            this.Controls.Add(this.lbl_bonus_meva);
            this.Controls.Add(this.lbl_bonus_mhit);
            this.Controls.Add(this.lbl_bonus_mdef);
            this.Controls.Add(this.lbl_bonus_matk);
            this.Controls.Add(this.lbl_bonus_peva);
            this.Controls.Add(this.lbl_bonus_phit);
            this.Controls.Add(this.lbl_bonus_pdef);
            this.Controls.Add(this.lbl_bonus_patk);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FragmentJamella";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmr_readMem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Timer tmr_Attach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Controls.StatSliders statSliders1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_bonus_patk;
        private System.Windows.Forms.Label lbl_bonus_pdef;
        private System.Windows.Forms.Label lbl_bonus_phit;
        private System.Windows.Forms.Label lbl_bonus_peva;
        private System.Windows.Forms.Label lbl_bonus_matk;
        private System.Windows.Forms.Label lbl_bonus_mdef;
        private System.Windows.Forms.Label lbl_bonus_mhit;
        private System.Windows.Forms.Label lbl_bonus_meva;
        private System.Windows.Forms.CheckBox ckBox_Stats;
        private System.Windows.Forms.Button btn_Reset;
    }
}

