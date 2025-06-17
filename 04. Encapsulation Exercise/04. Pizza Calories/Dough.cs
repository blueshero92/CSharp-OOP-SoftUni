namespace _04.PizzaCalories
{
    public class Dough
    {
        private double BaseCaloriesPerGram = 2;
        private string DoughArgumentExceptionMessage = "Invalid type of dough.";
        private string WeigthArgumentExceptionMessage = "Dough weight should be in the range [1..200].";

        private double MinWeigth = 1;
        private double MaxWeigth = 200;

        private string flourType;
        private string bakingTechnique;
        private double weigth;

        private Dictionary<string, double> flourTypesCalories;
        private Dictionary<string, double> bakingTechniquesCalories;

        public Dough(string flourType, string bakingTechnique, double weigth)
        {
            flourTypesCalories = new Dictionary<string, double> { { "white", 1.5 }, {"wholegrain", 1.0 } };
            bakingTechniquesCalories = new Dictionary<string, double> { {"crispy", 0.9 }, {"chewy", 1.1 }, {"homemade", 1.0 } };

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weigth = weigth;

        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (!flourTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughArgumentExceptionMessage);
                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (!bakingTechniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughArgumentExceptionMessage);
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public double Weigth
        {
            get { return this.weigth;}
            private set
            {
                if(value < MinWeigth || value > MaxWeigth)
                {
                    throw new ArgumentException(WeigthArgumentExceptionMessage);
                }

                this.weigth = value;
            }
        }

        public double Calories
        {
            get
            {
                double flourTypeModifier = flourTypesCalories[this.FlourType];
                double bakingTechniqueModifier = bakingTechniquesCalories[this.BakingTechnique];

                return BaseCaloriesPerGram * Weigth * flourTypeModifier * bakingTechniqueModifier;
            }
        }

    }
}
