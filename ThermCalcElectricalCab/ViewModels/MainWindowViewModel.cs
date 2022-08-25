using ElCalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ThermCalcElectricalCab.Model;
using ThermCalcElectricalCab.ViewModels.Base;
using static ElCalcLib.ThermalCalcs;

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

        public static Dictionary<string, double> HeatTransferCoeffs => ThermalCalcs.HeatTransferCoeff;

        #region Layouts
        public IEnumerable<ThermalCalcs.ElCabsLayout> ElCabsLayoutsValues
        {
            get
            {
                return Enum.GetValues(typeof(ThermalCalcs.ElCabsLayout)).Cast<ThermalCalcs.ElCabsLayout>();
            }
        }
        #endregion

        #region Layout
        private ElCabsLayout _layout;
        public ElCabsLayout Layout
        {
            get => _layout;
            set
            {
                _electricalCabinet.Layout = value;
                Set(ref _layout, value);
            }
        }
        #endregion

        #region Height
        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                _electricalCabinet.Height = value / 1000;
                Set(ref _height, value);
            }
        }
        #endregion

        #region Width
        private double _width;
        public double Width
        {
            get => _width;
            set
            {
                _electricalCabinet.Width = value / 1000;
                Set(ref _width, value);
            }
        }
        #endregion

        #region Depth
        private double _depth;
        public double Depth
        {
            get => _depth;
            set
            {
                _electricalCabinet.Depth = value / 1000;
                Set(ref _depth, value);
            }
        }
        #endregion

        #region ComponentsPower
        private double _componentsPower;
        public double ComponentsPower
        {
            get => _componentsPower;
            set
            {
                _electricalCabinet.ComponentsPower = value;
                Set(ref _componentsPower, value);
            }
        }
        #endregion

        #region HeatTransferCoeff
        private double _heatTransferCoeff;
        public double HeatTransferCoeff
        {
            get => _heatTransferCoeff;
            set
            {
                _electricalCabinet.HeatTransferCoeff = value;
                Set(ref _heatTransferCoeff, value);
            }
        }
        #endregion

        #region MaxInTemp
        private double _maxInTemp;
        public double MaxInTemp
        {
            get => _maxInTemp;
            set
            {
                _electricalCabinet.MaxInTemp = value;
                Set(ref _maxInTemp, value);
            }
        }
        #endregion

        #region MinInTemp
        private double _minInTemp;
        public double MinInTemp
        {
            get => _minInTemp;
            set
            {
                _electricalCabinet.MinInTemp = value;
                Set(ref _minInTemp, value);
            }
        }
        #endregion

        #region MaxOutTemp
        private double _maxOutTemp;
        public double MaxOutTemp
        {
            get => _maxOutTemp;
            set
            {
                _electricalCabinet.MaxOutTemp = value;
                Set(ref _maxOutTemp, value);
            }
        }
        #endregion

        #region MinOutTemp
        private double _minOutTemp;
        public double MinOutTemp
        {
            get => _minOutTemp;
            set
            {
                _electricalCabinet.MinOutTemp = value;
                Set(ref _minOutTemp, value);
            }
        }
        #endregion

        private ElectricalCabinet _electricalCabinet;

        public MainWindowViewModel()
        {
            _electricalCabinet = new ElectricalCabinet();
            Height = 2000;
            Width = 600;
            Depth = 400;
            HeatTransferCoeff = ThermalCalcs.HeatTransferCoeff["MetallicPainted"];
            Layout = ElCabsLayout.NearWall;
            ComponentsPower = 800;
            MinInTemp = 10;
            MaxInTemp = 50;
            MinOutTemp = -40;
            MaxOutTemp = 40;
        }

        protected override bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            bool result = base.Set(ref field, value, PropertyName);
            if (result)
            {
                _electricalCabinet.Recalc();
                OnPropertyChanged("MaxInTempWOCooling");
                OnPropertyChanged("MinInTempWOHeating");
                OnPropertyChanged("RequiredAirflowValue");
                OnPropertyChanged("RequiredAirflowValue_w_1_grid");
                OnPropertyChanged("RequiredAirflowValue_w_2_grid");
                OnPropertyChanged("RequiredAirflowValue_w_3_grid");
                OnPropertyChanged("IsCoolerNeeded");
            }
            return result;
        }

        public double MaxInTempWOCooling
        {
            get => _electricalCabinet.MaxInTempWOCooling;
        }

        public double MinInTempWOHeating
        {
            get => _electricalCabinet.MinInTempWOHeating;
        }

        public double RequiredAirflowValue
        {
            get => _electricalCabinet.RequiredAirflowValue;
        }

        public double RequiredAirflowValue_w_1_grid
        {
            get => _electricalCabinet.RequiredAirflowValue_w_1_grid;
        }

        public double RequiredAirflowValue_w_2_grid
        {
            get => _electricalCabinet.RequiredAirflowValue_w_2_grid;
        }

        public double RequiredAirflowValue_w_3_grid
        {
            get => _electricalCabinet.RequiredAirflowValue_w_3_grid;
        }

        public bool IsCoolerNeeded
        {
            get => _electricalCabinet.IsCoolerNeeded;
        }
    }
}
