using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LaboratoryWork3
{
    public class ByAreaComparer : IComparer<Figure>
    {
        public int Compare(Figure x, Figure y)
        {
            var byArea = x.CalculateArea().CompareTo(y.CalculateArea());

            return byArea == 0 ? -x.FrameThick.CompareTo(y.FrameThick) : byArea;
        }
    }

    public class Figures
    {
        public static string[] FigureNames { get; } = new string[] { "Тип не определен", "Круг", "Квадрат", "Эллипс", "Прямоугольник" };

        public Figures(params Figure[] figures)
        {
            foreach (var figure in figures)
            {
                _figures.Add(figure);
            }
            RecalculateAverageArea();
        }
        
        private readonly List<Figure> _figures = new List<Figure>();

        public void AddFigure(Figure figure)
        {
            _figures.Add(figure);
            RecalculateAverageArea();
        }

        public void SortByArea()
        {
            _figures.Sort(new ByAreaComparer());
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            foreach(var figure in _figures)
            {
                strBuilder.Append(figure + "\n");
            }
            strBuilder.Append($"Средняя площадь - {String.Format("{0:0.00}", GraphicEditor.AverageFiguresArea)}");

            return strBuilder.ToString();
        }

        public void PrintFourFiguresTypes()
        {
            for(var i = 0; i < 4; i++)
            {
                Console.WriteLine(_figures[i].Type);
            }
        }

        public void RecalculateAverageArea()
        {
            var sum = 0.0;
            foreach (var figure in _figures)
            {
                sum += figure.CalculateArea();
            }

            GraphicEditor.AverageFiguresArea = sum / _figures.Count;
        }

        public IEnumerable<Figure> GetFigures()
        {
            return _figures;
        }

        public void DrawLastThreeFigures()
        {
            for (var i = _figures.Count - 3; i < _figures.Count; i++)
            {
                if (i < 0)
                    continue;
                switch (_figures[i].Type)
                {
                    case FigureType.Circle:
                        GraphicEditor.PrintCircle((_figures[i] as Circle).Radius);
                        break;

                    case FigureType.Square:
                        GraphicEditor.PrintSquare((_figures[i] as Square).Side);
                        break;

                    case FigureType.Ellipse:
                        GraphicEditor.PrintEllipse((_figures[i] as Ellipse).A, (_figures[i] as Ellipse).B);
                        break;

                    case FigureType.Rectangle:
                        GraphicEditor.PrintRectangle((_figures[i] as Rectangle).A, (_figures[i] as Rectangle).B);
                        break;
                }
            }
        }

        public void ToJson(string fileName)
        {
            File.WriteAllText(
                fileName, JsonConvert.SerializeObject(
                    _figures, Formatting.Indented, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    })
                );
        }

        public static Figures FromJson(string fileName)
        {
            var figuresClass = new Figures();

            var figures = JsonConvert.DeserializeObject<List<Figure>>(
                File.ReadAllText(fileName), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            if (figures != null) figuresClass._figures.AddRange(figures);
            return figuresClass;
        }
    }
}