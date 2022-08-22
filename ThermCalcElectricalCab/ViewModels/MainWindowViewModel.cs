using ElCalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using ThermCalcElectricalCab.Model;
using ThermCalcElectricalCab.ViewModels.Base;

namespace ThermCalcElectricalCab.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Title
        private string _title = "Тепловой расчёт электрического щита";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        } 
        #endregion

        public static Dictionary<string, double> HeatTransferCoeff => ThermalCalcs.HeatTransferCoeff;

        private ThermalCalcs.ElCabsLayout _selectedElCabsLayout;
        public ThermalCalcs.ElCabsLayout SelectedElCabsLayout
        {
            get { return _selectedElCabsLayout; }
            set 
            { 
                _selectedElCabsLayout = value;
                OnPropertyChanged("SelectedElCabsLayout");
            }
        }

        public IEnumerable<ThermalCalcs.ElCabsLayout> ElCabsLayoutsValues
        {
            get
            {
                return Enum.GetValues(typeof(ThermalCalcs.ElCabsLayout)).Cast<ThermalCalcs.ElCabsLayout>();
            }
        }

        private ElectricalCabinet _electricalCabinet;
        public ElectricalCabinet ElectricalCabinet { get => _electricalCabinet; }

        public MainWindowViewModel()
        {
            _electricalCabinet = new ElectricalCabinet();
        }


    }
}
