namespace CookieCookbook.Ingredients
{
    public abstract class Ingredient
    {
        public static List<Ingredient> All { get; } = new List<Ingredient>();

        public abstract string Id { get; }
        public abstract string Name { get; }
        public abstract string Instructions { get; }

        public Ingredient()
        {
            All.Add(this);
        }
        public static Ingredient GetIngredientById(string id)
        {
            return All.Find(x => x.Id == id);
        }

        public void PrintIngredient() =>
            Console.WriteLine($"{Id}. {Name}");
        public void PrintIngredientInstructions() =>
            Console.WriteLine(Instructions);
    }

    public class Butter : Ingredient
    {
        public override string Id => "1";
        public override string Name => "Butter";
        public override string Instructions => "Melt on low heat. Add to other ingredients";
    }

    public class Chocolate : Ingredient
    {
        public override string Id => "2";
        public override string Name => "Chocolate";
        public override string Instructions => "Melt in double boiler. Add to other ingredients";
    }

    public class Cinnamon : Ingredient
    {
        public override string Id => "3";
        public override string Name => "Cinnamon";
        public override string Instructions => "Add half teaspoon to other ingredients";
    }

    public class Nuts : Ingredient
    {
        public override string Id => "4";
        public override string Name => "Nuts";
        public override string Instructions => "Gently crush and sprinkle over dough before baking.";
    }

    public class Sugar : Ingredient
    {
        public override string Id => "5";
        public override string Name => "Sugar";
        public override string Instructions => "Add to other ingredients";
    }

    public class WheatFlour : Ingredient
    {
        public override string Id => "6";
        public override string Name => "Wheat Flour";
        public override string Instructions => "Sieve. Add to other ingredients";
    }


}