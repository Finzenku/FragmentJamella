using FragmentJamella.Controls;
namespace FragmentJamella.Controls
{
    partial class StatSliders
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nswl_meva = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.nswl_mhit = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.nswl_mdef = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.nswl_matk = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.nswl_peva = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.nswl_phit = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.nswl_pdef = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.nswl_patk = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.nswl_Points = new FragmentJamella.Controls.NumericSliderWithLabel();
            this.SuspendLayout();
            // 
            // nswl_meva
            // 
            this.nswl_meva.LabelText = "M.Eva";
            this.nswl_meva.Location = new System.Drawing.Point(5, 247);
            this.nswl_meva.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_meva.Maximum = 99;
            this.nswl_meva.Name = "nswl_meva";
            this.nswl_meva.Size = new System.Drawing.Size(210, 35);
            this.nswl_meva.TabIndex = 8;
            this.nswl_meva.Value = 0;
            this.nswl_meva.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // nswl_mhit
            // 
            this.nswl_mhit.LabelText = "M.Hit";
            this.nswl_mhit.Location = new System.Drawing.Point(5, 218);
            this.nswl_mhit.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_mhit.Maximum = 99;
            this.nswl_mhit.Name = "nswl_mhit";
            this.nswl_mhit.Size = new System.Drawing.Size(210, 35);
            this.nswl_mhit.TabIndex = 7;
            this.nswl_mhit.Value = 0;
            this.nswl_mhit.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // nswl_mdef
            // 
            this.nswl_mdef.LabelText = "M.Def";
            this.nswl_mdef.Location = new System.Drawing.Point(5, 189);
            this.nswl_mdef.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_mdef.Maximum = 99;
            this.nswl_mdef.Name = "nswl_mdef";
            this.nswl_mdef.Size = new System.Drawing.Size(210, 35);
            this.nswl_mdef.TabIndex = 6;
            this.nswl_mdef.Value = 0;
            this.nswl_mdef.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // nswl_matk
            // 
            this.nswl_matk.LabelText = "M.Atk";
            this.nswl_matk.Location = new System.Drawing.Point(5, 160);
            this.nswl_matk.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_matk.Maximum = 99;
            this.nswl_matk.Name = "nswl_matk";
            this.nswl_matk.Size = new System.Drawing.Size(210, 35);
            this.nswl_matk.TabIndex = 5;
            this.nswl_matk.Value = 0;
            this.nswl_matk.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // nswl_peva
            // 
            this.nswl_peva.LabelText = "P.Eva";
            this.nswl_peva.Location = new System.Drawing.Point(2, 132);
            this.nswl_peva.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_peva.Maximum = 99;
            this.nswl_peva.Name = "nswl_peva";
            this.nswl_peva.Size = new System.Drawing.Size(210, 35);
            this.nswl_peva.TabIndex = 4;
            this.nswl_peva.Value = 0;
            this.nswl_peva.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // nswl_phit
            // 
            this.nswl_phit.LabelText = "P.Hit";
            this.nswl_phit.Location = new System.Drawing.Point(4, 103);
            this.nswl_phit.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_phit.Maximum = 99;
            this.nswl_phit.Name = "nswl_phit";
            this.nswl_phit.Size = new System.Drawing.Size(210, 35);
            this.nswl_phit.TabIndex = 3;
            this.nswl_phit.Value = 0;
            this.nswl_phit.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // nswl_pdef
            // 
            this.nswl_pdef.LabelText = "P.Def";
            this.nswl_pdef.Location = new System.Drawing.Point(4, 74);
            this.nswl_pdef.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_pdef.Maximum = 99;
            this.nswl_pdef.Name = "nswl_pdef";
            this.nswl_pdef.Size = new System.Drawing.Size(210, 35);
            this.nswl_pdef.TabIndex = 2;
            this.nswl_pdef.Value = 0;
            this.nswl_pdef.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // nswl_patk
            // 
            this.nswl_patk.LabelText = "P.Atk";
            this.nswl_patk.Location = new System.Drawing.Point(4, 45);
            this.nswl_patk.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_patk.Maximum = 99;
            this.nswl_patk.Name = "nswl_patk";
            this.nswl_patk.Size = new System.Drawing.Size(210, 35);
            this.nswl_patk.TabIndex = 1;
            this.nswl_patk.Value = 0;
            this.nswl_patk.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // nswl_Points
            // 
            this.nswl_Points.LabelText = "Points";
            this.nswl_Points.Location = new System.Drawing.Point(4, 3);
            this.nswl_Points.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.nswl_Points.Maximum = 99;
            this.nswl_Points.Name = "nswl_Points";
            this.nswl_Points.Size = new System.Drawing.Size(210, 35);
            this.nswl_Points.TabIndex = 0;
            this.nswl_Points.Value = 99;
            this.nswl_Points.ValueChanged += new System.EventHandler(this.nswl_ValueChanged);
            // 
            // StatSliders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nswl_meva);
            this.Controls.Add(this.nswl_mhit);
            this.Controls.Add(this.nswl_mdef);
            this.Controls.Add(this.nswl_matk);
            this.Controls.Add(this.nswl_peva);
            this.Controls.Add(this.nswl_phit);
            this.Controls.Add(this.nswl_pdef);
            this.Controls.Add(this.nswl_patk);
            this.Controls.Add(this.nswl_Points);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StatSliders";
            this.Size = new System.Drawing.Size(214, 289);
            this.ResumeLayout(false);

        }

        #endregion

        private NumericSliderWithLabel nswl_Points;
        private NumericSliderWithLabel nswl_patk;
        private NumericSliderWithLabel nswl_pdef;
        private NumericSliderWithLabel nswl_phit;
        private NumericSliderWithLabel nswl_peva;
        private NumericSliderWithLabel nswl_matk;
        private NumericSliderWithLabel nswl_mdef;
        private NumericSliderWithLabel nswl_mhit;
        private NumericSliderWithLabel nswl_meva;
    }
}
