namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("Dido");
            randomList.Add("Pesho");
            randomList.Add("Gosho");

           Console.WriteLine(randomList.RandomString());
        }
    }
}