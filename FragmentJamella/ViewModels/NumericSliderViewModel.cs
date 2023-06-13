using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace FragmentJamella.ViewModels
{
    public class NumericSliderViewModel : ViewModelBase
    {
        private string _text;
        private int _value, _maximum, _bonus;
        public string BonusText { get => $"+{Bonus / 10}.{Bonus % 10}"; }
        public int Bonus { get => _bonus; set => this.RaiseAndSetIfChanged(ref _bonus, value); }
        public string Text { get => _text; set => this.RaiseAndSetIfChanged(ref _text, value); }
        public int Maximum { get => _maximum; set => this.RaiseAndSetIfChanged(ref _maximum, value); }
        public int Value { get => _value; set => this.RaiseAndSetIfChanged(ref _value, value); }

        public NumericSliderViewModel()
        {
            Text = "";
            Maximum = 99;
            Value = 0;
            Bonus = 0;
        }

        public NumericSliderViewModel(string text, int maximum = 99, int value = 0, int bonus = 0)
        {
            Text = text;
            Maximum = maximum;
            Value = value;
            Bonus = bonus;

            this.WhenAnyValue(x => x.Bonus).Subscribe(x => this.RaisePropertyChanged("BonusText"));
            this.WhenAnyValue(x => x.Value).Where(value => value > Maximum).Subscribe(_ => Value = Maximum);
        }
    }
}
