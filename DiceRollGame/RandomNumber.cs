

// generate random number
class RandomNumber
{
    public static int RollDice() {
        Random random = new();
        return random.Next(1, 6);
    }
}

