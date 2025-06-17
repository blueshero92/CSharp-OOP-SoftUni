namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            string[] pizzaTokens = Console.ReadLine().Split();
            string[] doughTokens = Console.ReadLine().Split();

            string pizzaName = pizzaTokens[1];

            string flourType = doughTokens[1];
            string bakingTechnique = doughTokens[2];
            double doughWeigth = double.Parse(doughTokens[3]);

            try
            {
                Dough dough = new(flourType, bakingTechnique, doughWeigth);

                Pizza pizza = new(pizzaName, dough);

                string command = string.Empty;

                while((command = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = command.Split();

                    string toppingType = toppingTokens[1];
                    double toppingWeigth = double.Parse((toppingTokens[2]));

                    Topping topping = new(toppingType, toppingWeigth);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}