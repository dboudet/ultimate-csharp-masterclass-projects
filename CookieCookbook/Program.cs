using CookieCookbook.Ingredients;


Console.WriteLine("Create a new cookie recipe! Available Ingredients are:");


var availableIngredients = new List<Ingredient>
{
    new Butter(),
    new Chocolate(),
    new Cinnamon(),
    new Sugar(),
    new WheatFlour()
};

availableIngredients.ForEach(v => v.PrintIngredient());






Console.ReadKey();

