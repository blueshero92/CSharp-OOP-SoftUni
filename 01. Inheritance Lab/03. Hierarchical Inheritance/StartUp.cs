namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Cat cat = new();
            Dog dog = new Dog();

            dog.Bark();
            cat.Eat();
            dog.Eat();
            cat.Meow();
        }
    }
}