using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FragmentJamella.Views
{
    public class NumericSliderView : UserControl
    {
        public NumericSliderView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
