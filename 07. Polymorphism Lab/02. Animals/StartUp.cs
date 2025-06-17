namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            Animal cat = new Cat("Sivcho", "Whiskas");
            Animal dog = new Dog("Gogo", "Konserva");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());

        }
    }
}