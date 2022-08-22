using static ElCalcLib.ThermalCalcs;

namespace ThermCalcElectricalCab.Model
{
    /// <summary>
    /// Defines an electrical panel in terms of its thermal characteristics
    /// </summary>
    public class ElectricalCabinet
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }

        public double HeatTransferCoeff { get; set; }

        public ElCabsLayout Layout { get; set; }

        public double ComponentsPower { get; set; }

        public double MaxInTemp { get; set; }
        public double MinInTemp { get; set; }
    }
}
