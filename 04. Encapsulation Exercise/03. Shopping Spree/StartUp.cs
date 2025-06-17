using _03.ShoppingSpree.Models;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new();
            List<Product> products = new();

            try
            {
                string[] nameMoneyPairs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string nameMoneyPair in nameMoneyPairs)
                {
                    string[] nameMoney = nameMoneyPair.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Person person = new(nameMoney[0], decimal.Parse(nameMoney[1]));

                    people.Add(person);
                }

                string[] productCostPairs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string productCostPair in productCostPairs)
                {
                    string[] productCost = productCostPair.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Product product = new(productCost[0], decimal.Parse(productCost[1]));

                    products.Add(product);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return;
            }

            string command;

            while((command = Console.ReadLine()) != "END")
            {
                string[] personProduct = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = personProduct[0];
                string productName = personProduct[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (person != null && product != null)
                {
                    Console.WriteLine(person.AddProduct(product));
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}