namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = {
                new Rectangle(2, 5),
                new Circle(3, 1),
                new Hexagon(-2, 0)};

            var DrawingVisitor = new DrawingVisitor();
            var GettingAreaVisitor = new GettingAreaVisitor();
            var GettingSideLengthVisitor = new GettingSideLengthVisitor();
            foreach (var figure in figures)
            {
                figure.Accept(DrawingVisitor);
                figure.Accept(GettingAreaVisitor);
                figure.Accept(GettingSideLengthVisitor);
                System.Console.WriteLine();
            }

            System.Console.Read();
        }
    }
}
