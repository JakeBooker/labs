using System;

namespace LaboratoryWork3
{
    public enum FigureType
    {
        None = 0,
        Circle = 1,
        Square = 2, 
        Ellipse = 3,
        Rectangle = 4
    }

    public abstract class Figure
    {
        protected FigureType _figureType;
        public int FrameThick { get; protected set; }

        public FigureType Type
        {
            get => _figureType;
            set
            {
                _figureType = value;
            }
        }

        public Figure(){}

        public abstract double CalculateArea(); 

        public override string ToString()
        {
            return $"{Figures.FigureNames[(int)Type]}. Толщина рамки - {FrameThick} Площадь - {String.Format("{0:0.00}", CalculateArea())}";
        }
    }
}