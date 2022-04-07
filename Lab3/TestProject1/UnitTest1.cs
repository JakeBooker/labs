using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaboratoryWork3;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FigureInicializeTest()
        {
            var figure = new Circle(4);
            Assert.AreEqual(4, figure.Radius);
        }

        [TestMethod]
        public void FigureParentTest()
        {
            var square = new Square(5);
            Assert.IsTrue(square is Figure);
        }

        [TestMethod]
        public void CircleAreaCalculationTest()
        {
            var circle = new Circle(4);
            Assert.AreEqual(50.26548245743669, circle.CalculateArea());
        }

        [TestMethod]
        public void EllipseAreaCalculationTest()
        {
            var ellipse = new Ellipse(4, 6);
            Assert.AreEqual(75.39822368615503, ellipse.CalculateArea());
        }

        [TestMethod]
        public void RectangleAreaCalculationTest()
        {
            var rectangle = new Rectangle(10, 5);
            Assert.AreEqual(50, rectangle.CalculateArea());
        }

        [TestMethod]
        public void SquareAreaCalculationTest()
        {
            var square = new Square(2);
            Assert.AreEqual(4, square.CalculateArea());
        }

        [TestMethod]
        public void RealtimeAverageAreaTest()
        {
            var figures = new Figures(new Square(4));
            Assert.AreEqual(16, GraphicEditor.AverageFiguresArea);
            figures.AddFigure(new Rectangle(3, 4));
            Assert.AreEqual((16 + 12) / 2, GraphicEditor.AverageFiguresArea);
        }
    }
}
