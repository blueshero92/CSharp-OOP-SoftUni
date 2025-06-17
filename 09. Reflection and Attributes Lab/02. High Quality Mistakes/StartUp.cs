namespace Stealer
{
    internal class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();

            string fullInfo = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            

            Console.WriteLine(fullInfo);
        }
    }
}