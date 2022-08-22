using System.Windows;
using ThermCalcElectricalCab.Model;

namespace ThermCalcElectricalCab
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ElectricalCabinet _electricalCabinet;
        private readonly OutsideTemperature _outsideTemperature;

        public App()
        {
            _electricalCabinet = new ElectricalCabinet();
            _outsideTemperature = new OutsideTemperature();
        }
    }
}
