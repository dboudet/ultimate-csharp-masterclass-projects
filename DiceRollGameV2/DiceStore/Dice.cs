using DiceRollGameV2.UserMessages;

namespace DiceRollGameV2.DiceStore
{
    public class Dice : IDice
    {
        readonly int _numberOfSides;
        public Dice(int numberOfSides, IUserInteraction userInteraction)
        {
            if (numberOfSides > 0)
            {
                _numberOfSides = numberOfSides;
            }
            else
            {
                userInteraction.DisplayInvalidDice();
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