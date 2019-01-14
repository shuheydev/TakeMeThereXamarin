using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace TakeMeThere.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private double _magneticNorth;
        public double MagneticNorth
        {
            get => _magneticNorth;
            set => SetProperty(ref _magneticNorth, value);
        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            Compass.ReadingChanged += Compass_ReadingChanged;
            Compass.Start(SensorSpeed.UI);

        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var data = e.Reading;

            MagneticNorth = 360-data.HeadingMagneticNorth;
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            Compass.Stop();
        }
    }
}
