namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            List<string> strings = new List<string>() { "Hi", "Bye", "Shit" };          

            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(strings);

            Console.WriteLine(string.Join(" ", stack));

        }
    }
}