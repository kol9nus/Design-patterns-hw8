using System;

namespace Homework8
{
    public interface IVisitor
    {
        void Visit(Rectangle figure);
        void Visit(Circle figure);
        void Visit(Hexagon figure);
    }

    public class DrawingVisitor : IVisitor
    {
        public void Visit(Hexagon figure)
        {
            double oneDegree = Math.PI / 180;
            var x = figure.Center.X;
            var y = figure.Center.Y;
            Console.WriteLine(
                $"Рисуем шестиугольник с центром в ({x};{y}), радиусом 1:\n" +
                $"соединяем точки с координатами \n" +
                $"({x};{y - 1})\n" +
                $"({x - Math.Cos(oneDegree * 30)};{y - Math.Sin(oneDegree * 30)})\n" +
                $"({x - Math.Cos(oneDegree * 30)};{y + Math.Sin(oneDegree * 30)})\n" +
                $"({x};{y + 1})\n" +
                $"({x + Math.Cos(oneDegree * 30)};{y + Math.Sin(oneDegree * 30)})\n" +
                $"({x + Math.Cos(oneDegree * 30)};{y - Math.Sin(oneDegree * 30)})"
                );
        }

        public void Visit(Circle figure)
        {
            var x = figure.Center.X;
            var y = figure.Center.Y;
            Console.WriteLine(
                $"Рисуем круг с центром в ({x};{y}), радиусом 1");
        }

        public void Visit(Rectangle figure)
        {
            var x = figure.Center.X;
            var y = figure.Center.Y;
            Console.WriteLine(
                $"Рисуем прямоугольник с центром в ({x};{y}), радиусом 1:\n" +
                $"соединяем точки с координатами \n" +
                $"({x - 1};{y - 1})\n" +
                $"({x - 1};{y + 1})\n" +
                $"({x + 1};{y + 1})\n" +
                $"({x + 1};{y - 1})"
                );
        }
    }

    public class GettingAreaVisitor : IVisitor
    {
        public void Visit(Hexagon figure)
        {
            figure.Area = 3 * Math.Pow(3, 0.5) * figure.Radius * figure.Radius / 2;
            Console.WriteLine($"{figure.Name} имеет площадь {figure.Area}");
        }

        public void Visit(Circle figure)
        {
            figure.Area = Math.PI * figure.Radius * figure.Radius;
            Console.WriteLine($"{figure.Name} имеет площадь {figure.Area}");
        }

        public void Visit(Rectangle figure)
        {
            figure.Area = figure.Radius * 2 * figure.Radius * 2;
            Console.WriteLine($"{figure.Name} имеет площадь {figure.Area}");
        }
    }

    public class GettingSideLengthVisitor : IVisitor
    {
        public void Visit(Hexagon figure)
        {
            figure.SideLength = figure.Radius;
            Console.WriteLine($"{figure.Name} имеет длинну стороны {figure.SideLength}");
        }

        public void Visit(Circle figure)
        {
            figure.SideLength = figure.Radius;
            Console.WriteLine($"{figure.Name} имеет радиус {figure.SideLength}");
        }

        public void Visit(Rectangle figure)
        {
            figure.SideLength = figure.Radius * 2;
            Console.WriteLine($"{figure.Name} имеет длинну стороны {figure.SideLength}");
        }
    }

    public abstract class Figure
    {
        public Point Center { get; }
        public int Radius { get; }
        public Figure(int x, int y)
        {
            Center = new Point(x, y);
            Radius = 1;
        }
        public abstract string Name { get; }
        public double Area { get; set; }
        public double SideLength { get; set; }
        public abstract void Accept(IVisitor visitor);
    }

    public class Hexagon : Figure
    {
        public Hexagon(int x, int y) : base(x, y)
        {
        }

        public override string Name => "Шестиугольник";
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Circle : Figure
    {
        public Circle(int x, int y) : base(x, y)
        {
        }

        public override string Name => "Кргу";

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Rectangle : Figure
    {
        public Rectangle(int x, int y) : base(x, y)
        {
        }

        public override string Name => "Прямоугольник";

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
