namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable circle = new Circle(3);
            IDrawable rectangle = new Rectangle(4, 5);

            circle.Draw();
            rectangle.Draw();
        }
    }
}