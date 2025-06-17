namespace Stealer
{
    public class StartUp
    {
        static void Main()
        {
            Spy spy = new();

            string privateMethodsResult = spy.RevealPrivateMethods("Stealer.Hacker");

            Console.WriteLine(privateMethodsResult);
        }
    }
}