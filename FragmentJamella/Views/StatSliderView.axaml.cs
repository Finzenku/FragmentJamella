using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FragmentJamella.Views
{
    public class StatSliderView : UserControl
    {
        public StatSliderView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
