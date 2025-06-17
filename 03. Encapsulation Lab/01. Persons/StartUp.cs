namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Person> people = new();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new(tokens[0], tokens[1], int.Parse(tokens[2]));

                people.Add(person);
            }

            foreach (Person person in people.OrderBy(p => p.FirstName).ThenBy(p => p.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
}