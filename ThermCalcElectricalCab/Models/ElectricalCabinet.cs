using ElCalcLib;
using static ElCalcLib.ThermalCalcs;

namespace ThermCalcElectricalCab.Model
{
    /// <summary>
    /// Defines an electrical panel in terms of its thermal characteristics
    /// </summary>
    public class ElectricalCabinet
    {
        private double _height;
        public double Height { get => _height; set => _height = value; }

        private double _width;
        public double Width { get => _width; set => _width = value; }

        private double _depth;
        public double Depth { get => _depth; set => _depth = value; }

        private double _heatTransferCoeff;
        public double HeatTransferCoeff { get => _heatTransferCoeff; set => _heatTransferCoeff = value; }

        private ElCabsLayout _layout;
        public ElCabsLayout Layout { get => _layout; set => _layout = value; }

        private double _componentsPower;
        public double ComponentsPower { get => _componentsPower; set => _componentsPower = value; }

        private double _maxInTemp;
        public double MaxInTemp { get => _maxInTemp; set => _maxInTemp = value; }

        private double _minInTemp;
        public double MinInTemp { get => _minInTemp; set => _minInTemp = value; }

        private double _maxOutTemp;
        public double MaxOutTemp { get => _maxOutTemp; set => _maxOutTemp = value; }

        private double _minOutTemp;
        public double MinOutTemp { get => _minOutTemp; set => _minOutTemp = value; }

        private double _maxInTempWOCooling;
        public double MaxInTempWOCooling => _maxInTempWOCooling;

        private double _minInTempWOHeating;
        public double MinInTempWOHeating => _minInTempWOHeating;

        private double _effectiveHeatEchangeArea;
        
        private double _excessHeatOutput;

        private double _requiredAirflowValue;
        public double RequiredAirflowValue => _requiredAirflowValue;
        public double RequiredAirflowValue_w_1_grid { get => _requiredAirflowValue / 0.7; }
        public double RequiredAirflowValue_w_2_grid { get => _requiredAirflowValue / 0.8; }
        public double RequiredAirflowValue_w_3_grid { get => _requiredAirflowValue / 0.9; }

        private bool _isHeaterNeeded;
        public bool IsHeaterNeeded => _isHeaterNeeded;

        private bool _isCoolerNeeded;
        public bool IsCoolerNeeded => _isCoolerNeeded;

        private double _requiredHeaterPower;
        public double RequiredHeaterPower => _requiredHeaterPower;

        public ElectricalCabinet()
        {
            
        }

        public void Recalc()
        {
            _effectiveHeatEchangeArea = ThermalCalcs.EffectiveHeatExchangeArea(_height, _width, _depth, _layout);
            _maxInTempWOCooling = ThermalCalcs.InsideTemp(_componentsPower, _heatTransferCoeff, _effectiveHeatEchangeArea, _maxOutTemp);
            _minInTempWOHeating = ThermalCalcs.InsideTemp(_componentsPower, _heatTransferCoeff, _effectiveHeatEchangeArea, _minOutTemp);
            _excessHeatOutput = ThermalCalcs.ExcessHeatOutput(_componentsPower, _heatTransferCoeff, _effectiveHeatEchangeArea, 
                _maxInTemp, _maxOutTemp);
            _isHeaterNeeded = _minInTempWOHeating < _minInTemp;
            _isCoolerNeeded = _maxInTempWOCooling > _maxInTemp;
            if (_isHeaterNeeded)
            {
                _requiredHeaterPower = ThermalCalcs.RequiredHeaterPower(_componentsPower, _minInTemp, _minOutTemp,
                    _effectiveHeatEchangeArea, _heatTransferCoeff);
            }
            else _requiredHeaterPower = 0;
            if (_isCoolerNeeded)
            {
                _requiredAirflowValue = ThermalCalcs.RequiredAirflowValue(_excessHeatOutput, _maxInTemp, _maxOutTemp);
            }
            else _requiredAirflowValue = 0;
        }
    }
}
