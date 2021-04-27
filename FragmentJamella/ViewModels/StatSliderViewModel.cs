using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FragmentJamella.ViewModels
{
    public class StatSliderViewModel : ViewModelBase
    {
        public NumericSliderViewModel Points { get; }

        public ObservableCollection<NumericSliderViewModel> Stats { get; }

        public StatSliderViewModel()
        {
            Points = new NumericSliderViewModel("Points");
            
            Stats = new ObservableCollection<NumericSliderViewModel>
            {
                new NumericSliderViewModel("P. Atk"),
                new NumericSliderViewModel("P. Def"),
                new NumericSliderViewModel("P. Acc"),
                new NumericSliderViewModel("P. Eva"),
                new NumericSliderViewModel("M. Atk"),
                new NumericSliderViewModel("M. Def"),
                new NumericSliderViewModel("M. Acc"),
                new NumericSliderViewModel("M. Eva")
            };
            Points.WhenAnyValue(x => x.Value).Subscribe(x => updateMaximum());
            foreach (NumericSliderViewModel nsvm in Stats)
                nsvm.WhenAnyValue(x => x.Value).Subscribe(x => updateMaximum());  
        }

        private int PointsSpent()
        {
            int sum = 0;
            foreach (NumericSliderViewModel nsvm in Stats)
                sum += nsvm.Value;
            return sum;
        }

        private void updateMaximum()
        {
            Points.Value = Points.Maximum - PointsSpent();
            foreach (NumericSliderViewModel nsvm in Stats)
                nsvm.Maximum = nsvm.Value + Points.Value;
        }

        public int[] GetSliders()
        {
            return Stats.Select(x => x.Value).ToArray();    
        }

        public void SetBonusStats(int[] bonus = null)
        {
            bonus = bonus ?? new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i =0; i < Stats.Count; i++)
            {
                Stats[i].Bonus = bonus[i];
            }
        }

        public int[] GetBonusStats()
        {
            return Stats.Select(x => x.Bonus).ToArray();
        }
    }
}
