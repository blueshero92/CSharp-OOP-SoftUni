namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DarkWizard wizard = new DarkWizard("Gandalf", 6);

            Console.WriteLine(wizard);
        }
    }
}