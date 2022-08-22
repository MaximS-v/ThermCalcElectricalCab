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

        #region HeatTransferCoeff
        private double _selectedHeatTransferCoeff;
        public double SelectedHeatTransferCoeff
        {
            get => _selectedHeatTransferCoeff;
            set
            {
                Set(ref _selectedHeatTransferCoeff, value);
            }
        }

        public static Dictionary<string, double> HeatTransferCoeff => ThermalCalcs.HeatTransferCoeff; 
        #endregion

        #region Layout
        private ThermalCalcs.ElCabsLayout _selectedElCabsLayout;
        public ThermalCalcs.ElCabsLayout SelectedElCabsLayout
        {
            get => _selectedElCabsLayout;
            set
            {
                Set(ref _selectedElCabsLayout, value);
            }
        }

        public IEnumerable<ThermalCalcs.ElCabsLayout> ElCabsLayoutsValues
        {
            get
            {
                return Enum.GetValues(typeof(ThermalCalcs.ElCabsLayout)).Cast<ThermalCalcs.ElCabsLayout>();
            }
        } 
        #endregion

        private ElectricalCabinet _electricalCabinet;
        public ElectricalCabinet ElectricalCabinet { get => _electricalCabinet; }

        public MainWindowViewModel()
        {
            _electricalCabinet = new ElectricalCabinet();
        }


    }
}
