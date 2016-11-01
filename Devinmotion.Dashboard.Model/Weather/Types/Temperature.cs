namespace Devinmotion.Dashboard.Model.Weather.Types
{
    public class Temperature
    {
        public double Value { get; }

        public TemperatureUnit Unit { get; }

        public Temperature(double value, TemperatureUnit unit)
        {
            Value = value;
            Unit = unit;
        }
    }
}
