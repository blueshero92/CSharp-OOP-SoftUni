namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy puppy = new();

            puppy.Bark();
            puppy.Eat();
            puppy.Weep();
        }
    }
}