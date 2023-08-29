public class Dice
{
    readonly int _numberOfSides;
    public Dice(int numberOfSides = 6)
    {
        _numberOfSides = numberOfSides;
    }

    public int Roll()
    {
        var _random = new Random();
        // lower bound inclusive; upper bound exclusive
        return _random.Next(1, _numberOfSides + 1);
    }
}
