using System;

namespace TowerDefender.Commons
{
    [Serializable]
    public class RangeNumber<T> where T : IComparable<T>
    {
        public RangeNumber()
        {
        }
        public RangeNumber(T min, T max)
        {
            this.Min = min;
            this.Max = max;
        }

        public T Min;
        public T Max;
    }
}