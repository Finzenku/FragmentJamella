using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FragmentJamella.Controls
{
    public partial class StatSliders : UserControl
    {

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the value of a NumericUpDown or Slider is changed")]

        public event EventHandler ValueChanged;

        public StatSliders()
        {
            InitializeComponent();
        }

        protected void OnValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        public int[] GetSliders()
        {
            return new int[] {nswl_patk.Value, nswl_pdef.Value, nswl_phit.Value, nswl_peva.Value,
                              nswl_matk.Value, nswl_mdef.Value, nswl_mhit.Value, nswl_meva.Value};
        }

        private int totalPointsSpent()
        {
            return nswl_patk.Value + nswl_pdef.Value + nswl_phit.Value + nswl_peva.Value
                 + nswl_matk.Value + nswl_mdef.Value + nswl_mhit.Value + nswl_meva.Value;
        }

        private void setMaximums()
        {
            nswl_patk.Maximum = nswl_patk.Value + nswl_Points.Value;
            nswl_pdef.Maximum = nswl_pdef.Value + nswl_Points.Value;
            nswl_phit.Maximum = nswl_phit.Value + nswl_Points.Value;
            nswl_peva.Maximum = nswl_peva.Value + nswl_Points.Value;
            nswl_matk.Maximum = nswl_matk.Value + nswl_Points.Value;
            nswl_mdef.Maximum = nswl_mdef.Value + nswl_Points.Value;
            nswl_mhit.Maximum = nswl_mhit.Value + nswl_Points.Value;
            nswl_meva.Maximum = nswl_meva.Value + nswl_Points.Value;
        }

        private void nswl_ValueChanged(object sender, EventArgs e)
        {
            nswl_Points.Value = nswl_Points.Maximum - totalPointsSpent();
            setMaximums();
            OnValueChanged(this, e);
        }
    }
}
