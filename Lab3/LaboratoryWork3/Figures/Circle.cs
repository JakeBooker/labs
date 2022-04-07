using System;

namespace LaboratoryWork3
{
    public class Circle : Figure
    {
        public int Radius { get; }

        public Circle(int radius)
        {
            Type = FigureType.Circle;
            Radius = radius;
        }

        public Circle(int radius, int thick)
        {
            Type = FigureType.Circle;
            Radius = radius;
            FrameThick = thick;
        }

        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI - FrameThick;
        }
    }
}