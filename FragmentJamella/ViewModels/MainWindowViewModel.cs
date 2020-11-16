using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using Avalonia.Data.Converters;
using FragmentJamella.Models;
using System.Reactive;

namespace FragmentJamella.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _updateStats;
        private int _sclass, _smodel, _scolor, _sheight, _swidth;
        private string _smodelname;
        
        public bool UpdateStats { get => _updateStats; set => this.RaiseAndSetIfChanged(ref _updateStats, value); }
        public int SelectedClass { get => _sclass; set => this.RaiseAndSetIfChanged(ref _sclass, value); }
        public int SelectedModel { get => _smodel; set => this.RaiseAndSetIfChanged(ref _smodel, value); }
        public int SelectedColor { get => _scolor; set => this.RaiseAndSetIfChanged(ref _scolor, value); }
        public int SelectedHeight { get => _sheight; set => this.RaiseAndSetIfChanged(ref _sheight, value); }
        public int SelectedWidth { get => _swidth; set => this.RaiseAndSetIfChanged(ref _swidth, value); }
        public string SelectedModelName { get => _smodelname; set => this.RaiseAndSetIfChanged(ref _smodelname, value); }
        public string ModelImage { get => $"/Resources/Portraits/{SelectedModelName}.jpeg"; }

        public ObservableCollection<string> Classes { get; set; }
        public ObservableCollection<string> Models { get; set; }
        public ObservableCollection<string> Colors { get; set; }
        public ObservableCollection<string> Heights { get; set; }
        public ObservableCollection<string> Widths { get; set; }

        public StatSliderViewModel StatSlider { get; }

        private JamellaLogic logic;

        public ReactiveCommand<Unit, Unit> ResetModel { get; }
        public ReactiveCommand<Unit, Unit> UpdateCharacter { get; }

        public MainWindowViewModel()
        {
            StatSlider = new StatSliderViewModel();
            logic = new JamellaLogic();
            UpdateStats = true;
            Models = new ObservableCollection<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            Classes = new ObservableCollection<string>() { "Twin Blade", "Blademaster", "Heavy Blade", "Heavy Axe", "Long Arm", "Wavemaster"};
            Colors = new ObservableCollection<string>() { "Red (Fire)", "Blue (Water)", "Yellow (Thunder)", "Green (Wood)", "Brown (Earth)", "Purple (Darkness)" };
            Heights = new ObservableCollection<string>() { "Short", "Medium", "Tall" };
            Widths = new ObservableCollection<string>() { "Small", "Medium", "Large" };

            ResetToCurrentModel();

            ResetModel = ReactiveCommand.Create(ResetToCurrentModel);
            UpdateCharacter = ReactiveCommand.Create(UpdateCharacterModel);

            this.WhenAnyValue(x => x.SelectedClass).Subscribe(x => UpdateModelCountBasedOnSelectedClass());
            this.WhenAnyValue(x => x.SelectedClass, x => x.SelectedModel, x => x.SelectedColor, x => x.SelectedHeight, x => x.SelectedWidth,
                (cl, mo, co, he, wi) => logic.GetModelFromData(cl, mo, co, he, wi))
                .Subscribe(x =>
                 {
                     SelectedModelName = x;
                     this.RaisePropertyChanged("ModelImage");
                     UpdateBonusStats();
                 });
            this.WhenAnyValue(x => x.StatSlider.Points.Value).Subscribe(x => UpdateBonusStats());
        }

        private void UpdateCharacterModel()
        {
            logic.updateCharcter(SelectedClass, SelectedModel, SelectedColor, SelectedHeight, SelectedWidth);
            if (UpdateStats) logic.updateStats(StatSlider.GetSliders());
        }

        private void UpdateBonusStats()
        {
            StatSlider.SetBonusStats(logic.GetBonusStats(SelectedModelName, StatSlider.GetSliders()));
        }

        private void ResetToCurrentModel()
        {
            int[] modelnums = logic.GetModelValues();
            SelectedClass = modelnums[0];
            SelectedModel = modelnums[1];
            SelectedColor = modelnums[2];
            SelectedHeight = modelnums[3];
            SelectedWidth = modelnums[4];
        }

        private void UpdateModelCountBasedOnSelectedClass()
        {
            int count = logic.GetModelCountFromClass(SelectedClass), ind = SelectedModel;
            Models.Clear();
            for (int i = 0; i < count; i++)
            {
                Models.Add(((char)('A' + i)).ToString());
            }
            if (ind < count && ind != -1) SelectedModel = ind;
            else SelectedModel = 0;
        }
    }
}
