namespace DiceRollGameV2.Game
{
    public class Dice
    {
        readonly int _numberOfSides;
        public Dice(int numberOfSides)
        {
            if (numberOfSides > 0)
            {
                _numberOfSides = numberOfSides;
            }
            else
            {
                Console.WriteLine("Invalid number of sides provided. Using default of 6");
                _numberOfSides = 6;
            }
        }

        public int Roll()
        {
            var _random = new Random();
            // lower bound inclusive; upper bound exclusive
            return _random.Next(1, _numberOfSides + 1);
        }
    }
}