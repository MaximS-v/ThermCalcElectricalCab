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

        private double _effectiveHeatEchangeArea;
        

        public void Recalc()
        {
            _effectiveHeatEchangeArea = ThermalCalcs.EffectiveHeatExchangeArea(_height, _width, _depth, _layout);
            _maxInTempWOCooling = ThermalCalcs.InsideTemp(_componentsPower, _heatTransferCoeff, _effectiveHeatEchangeArea, _maxOutTemp);
        }
    }
}
