using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKEPractic
{
    public class TriangleSide
    {
        public double Value { get; private set; } = 0;
        public TriangleSide(string StrValue)
        {
            if (!double.TryParse(StrValue, out double value)) throw new TriangleExeption("Сторона не подходит к условию задачи");
            if (value <= 0) throw new TriangleExeption("Сторона не подходит к условию задачи");
            else Value = value;
        }
        public void SetValue(double value)
        {
            Value = value;
        }
    }
    public class TriangleExeption : Exception
    {
        public TriangleExeption(string message) : base(message) { }
    }
}
