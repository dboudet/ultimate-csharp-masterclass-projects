using DiceRollGameV2.Game;
using DiceRollGameV2.UserMessages;

var game = new GameMechanics
{
    MaxGuesses = 3,
    DiceSides = 6
};

DisplayMessage.Intro();

GuessingGame.Play(game);


Console.ReadKey();
