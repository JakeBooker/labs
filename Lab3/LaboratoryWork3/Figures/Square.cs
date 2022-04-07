using System;

namespace LaboratoryWork3
{
    public class Square : Figure
    {
        public int Side { get; }

        public Square(int side)
        {
            Type = FigureType.Square;
            Side = side;
        }

        public Square(int side, int thick)
        {
            Type = FigureType.Square;
            Side = side;
            FrameThick = thick;
        }

        public override double CalculateArea()
        {
            return Side * Side - FrameThick;
        }
    }
}