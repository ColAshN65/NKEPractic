using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKEPractic
{
    public class Triangle
    {
        public TriangleSide [] Sides { get; private set; }
        public TriangleSide PolPerimeter { get; private set; }

        private string _type = "Разносторонний", _type2 = "Остроугольный";
        private double _area;
        public Triangle(string[] sides)
        {
            Sides = new TriangleSide[3];
            for (int i = 0; i < 3; i++)
            {
                Sides[i] = new TriangleSide(sides[i]);
            }

            if (Sides[0].Value >= Sides[1].Value + Sides[2].Value ||
                Sides[1].Value >= Sides[0].Value + Sides[2].Value ||
                Sides[2].Value >= Sides[1].Value + Sides[0].Value) throw new TriangleExeption("Такой треугольник не существует");

            PolPerimeter = new TriangleSide($"{(Sides[0].Value + Sides[1].Value + Sides[2].Value)/2}");
        }
        public string GetTypeOfTriangle()
        {
            if (Sides[0].Value == Sides[1].Value || Sides[1].Value == Sides[2].Value || Sides[0].Value == Sides[2].Value) _type = "Равнобедренный";

            if (Sides[0].Value == Sides[1].Value && Sides[1].Value == Sides[2].Value) _type = "Равносторонний";
            
            return _type;
        }
        public string GetAngleTriangleType()
        {
            TriangleSide bufferSide = new TriangleSide("1");
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 3; j++)
                {
                    if (Sides[i].Value > Sides[j].Value)
                    {
                        bufferSide.SetValue(Sides[i].Value);
                        Sides[i].SetValue(Sides[j].Value);
                        Sides[j].SetValue(bufferSide.Value);
                    }
                }
            }
            if (Math.Pow(Sides[2].Value, 2) == Math.Pow(Sides[0].Value, 2) + Math.Pow(Sides[1].Value, 2)) _type2 = "Прямоугольный";
            if (Math.Pow(Sides[2].Value, 2) > Math.Pow(Sides[0].Value, 2) + Math.Pow(Sides[1].Value, 2)) _type2 = "Тупоугольный";
            return _type2;
        }
        public double GetArea()
        {
            _area = Math.Sqrt(PolPerimeter.Value * (PolPerimeter.Value - Sides[0].Value) * (PolPerimeter.Value - Sides[1].Value) * (PolPerimeter.Value - Sides[2].Value));
            return _area;
        }
    }
}
