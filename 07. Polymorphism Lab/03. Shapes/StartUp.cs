namespace Shapes
{
   public class StartUp
    {
        static void Main()
        {
            Rectangle rectangle = new(2, 4);
            Circle circle = new(6);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
        }
    }
}