using System;

namespace LaboratoryWork3
{
    public class Ellipse : Figure
    {
        public int A { get; }
        public int B { get; }

        public Ellipse(int a, int b)
        {
            Type = FigureType.Ellipse;
            A = a;
            B = b;
        }

        public Ellipse(int a, int b, int thick)
        {
            Type = FigureType.Ellipse;
            A = a;
            B = b;
            FrameThick = thick;
        }

        public override double CalculateArea()
        {
            return Math.PI * A * B - FrameThick;
        }
    }
}