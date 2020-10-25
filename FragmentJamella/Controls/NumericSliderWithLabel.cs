using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FragmentJamella.Controls
{
    public partial class NumericSliderWithLabel : UserControl
    {
        private int _max = 99;
        private int _value = 0;
        private string _label = "Label";
        [Description("The maximum value for the position of the slider on the track bar"),Category("Behavior")]
        public int Maximum
        {
            get => _max;
            set
            {
                if (value >= 0 && value < 100)
                {
                    _max = value;
                    numUpDown.Maximum = _max;
                }
            }
        }
        [Description(""),Category("Behavior")]
        public int Value
        {
            get => _value;
            set
            {
                if (value >= 0 && value <= _max) _value = value;
                else if (value > _max) _value = _max;
                else _value = 0;
                numUpDown.Value = _value;
                slider.Value = _value;
            }
        }
        [Description(""),Category("Appearance")]
        public string LabelText
        {
            get => _label;
            set
            {
                _label = value;
                lbl_Name.Text = _label;
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the value of the NumericUpDown or Slider is changed")]
        public event EventHandler ValueChanged;

        public NumericSliderWithLabel()
        {
            InitializeComponent();
        }

        protected void OnValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private void NumSliderValueChanged(object sender, EventArgs e)
        {
            switch (sender)
            {
                case TrackBar tb:
                    if (tb.Value > _max) tb.Value = _max;
                    else if (tb.Value < 0) tb.Value = 0;
                    numUpDown.Value = tb.Value;
                    Value = tb.Value;
                    break;
                case NumericUpDown nud:
                    if (nud.Value < 0) nud.Value = 0;
                    slider.Value = (int)nud.Value;
                    Value = (int)nud.Value;
                    break;
            }
            OnValueChanged(this, e);
        }
    }
}
