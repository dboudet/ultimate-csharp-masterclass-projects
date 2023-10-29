using DiceRollGameV2.DiceStore;
using DiceRollGameV2.Game;
using DiceRollGameV2.GameMechanicsStore;
using DiceRollGameV2.UserMessages;

const int diceSides = 6;
const int maxGuesses = 3;


IUserInteraction _userInteraction = new ConsoleUserInteraction();
IGameMechanics _gameMechanics = new GameMechanics(diceSides, maxGuesses);
IDice _dice = new Dice(diceSides, _userInteraction);

var _app = new GuessingGame(_dice, _gameMechanics, _userInteraction);

_app.Play();


_userInteraction.EndGame();
