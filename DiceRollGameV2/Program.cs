using DiceRollGameV2.Game;
using DiceRollGameV2.UserCommunication;

var random = new Random();
// optional second parameter to set number of dice sides (defaults to 6)
// var dice = new Dice(random, 20).Roll();
var dice = new Dice(random);

var game = new GuessingGame
{
    MaxGuesses = 3,
    _dice = dice
};


Result gameResult = game.Play();
DisplayMessage.GameResult(gameResult.ToString());

Console.ReadKey();