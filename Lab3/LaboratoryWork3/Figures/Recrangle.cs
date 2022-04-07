using System;

namespace LaboratoryWork3
{
    public class Rectangle : Figure
    {
        public int A { get; }
        public int B { get; }

        public Rectangle(int a, int b)
        {
            Type = FigureType.Rectangle;
            A = a;
            B = b;
        }

        public Rectangle(int a, int b, int thick)
        {
            Type = FigureType.Rectangle;
            A = a;
            B = b;
            FrameThick = thick;
        }

        public override double CalculateArea()
        {
            return A * B - FrameThick;
        }
    }
}