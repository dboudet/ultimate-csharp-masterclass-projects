namespace DiceRollGameV2.Game
{
    public class Dice
    {
        private readonly Random _random;
        readonly int _diceSides;
        public Dice(Random random, int numberOfSides = 6)
        {
            _random = random;
            _diceSides = numberOfSides > 0 ? numberOfSides : 6;
        }

        public int Roll()
        {
            // lower bound inclusive; upper bound exclusive
            return _random.Next(1, _diceSides + 1);
        }
    }
}