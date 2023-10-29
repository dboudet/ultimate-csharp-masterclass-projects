using DiceGameHersToBeTested;
using Game;
using Moq;
using NUnit.Framework;
using UserCommunication;

namespace DiceGameHersTests
{
    [TestFixture]
    public class GuessingGameTests
    {
        Mock<IDice> _diceMock;
        Mock<IUserCommunication> _userCommunicationMock;
        GuessingGame _cut;

        [SetUp]
        public void SetUp()
        {
            _diceMock = new Mock<IDice>();
            _userCommunicationMock = new Mock<IUserCommunication>();
            _cut = new GuessingGame(
                _diceMock.Object, _userCommunicationMock.Object);
        }

        [Test]
        public void Play_ShallReturnVictory_IfUserGuessesCorrectlyOnFirstTry()
        {
            const int numberRolled = 3;
            _diceMock.Setup(m => m.Roll()).Returns(numberRolled);
            _userCommunicationMock
                .Setup(m => m.ReadInteger(It.IsAny<string>()))
                .Returns(numberRolled);

            var gameResult = _cut.Play();


            Assert.AreEqual(GameResult.Victory, gameResult);
        }

        [Test]
        public void Play_ShallReturnLoss_IfUserNeverGuessesNumber()
        {
            const int numberRolled = 3;
            _diceMock.Setup(m => m.Roll()).Returns(numberRolled);
            const int userGuess = 1;
            _userCommunicationMock
                .Setup(m => m.ReadInteger(It.IsAny<string>()))
                .Returns(userGuess);

            var gameResult = _cut.Play();


            Assert.AreEqual(GameResult.Loss, gameResult);
        }

        [Test]
        public void Play_ShallReturnVictory_IfUserGuessesCorrectlyOnThirdTry()
        {
            SetupUserGuessingTheNumberOnThirdTry();

            var gameResult = _cut.Play();

            Assert.AreEqual(GameResult.Victory, gameResult);
        }

        private void SetupUserGuessingTheNumberOnThirdTry(int numberRolled = 3)
        {
            _diceMock.Setup(m => m.Roll()).Returns(numberRolled);
            _userCommunicationMock
                .SetupSequence(m => m.ReadInteger(It.IsAny<string>()))
                .Returns(8)
                .Returns(8)
                .Returns(numberRolled);
        }

        [TestCase(GameResult.Victory, "You win!")]
        [TestCase(GameResult.Loss, "You lose :(")]
        public void PrintResult_ShallShowProperMessageForGameResult(
            GameResult gameResult, string expectedMessage)
        {
            _cut.PrintResult(gameResult);
            _userCommunicationMock.Verify(
                mock => mock.ShowMessage(expectedMessage));
        }

        [Test]
        public void Play_ShallShowWelcomeMessage()
        {
            var gameResult = _cut.Play();

            _userCommunicationMock.Verify(
                mock => mock.ShowMessage(
                    "Dice rolled. Guess what number it shows in 3 tries."),
                Times.Once());
        }

        [Test]
        public void Play_ShallAskForNumberThreeTimes_IfUserGuessesIncorrectly()
        {
            const int numberRolled = 3;
            SetupUserGuessingTheNumberOnThirdTry(numberRolled);

            var gameResult = _cut.Play();

            _userCommunicationMock.Verify(
                m => m.ReadInteger(
                    Resource.EnterNumberMessage),
                Times.Exactly(numberRolled));
        }

        [Test]
        public void Play_ShallShowWrongNumberTwice_IfUserGuessesRightOnThirdTry()
        {
            SetupUserGuessingTheNumberOnThirdTry();

            var gameResult = _cut.Play();

            _userCommunicationMock.Verify(
                m => m.ShowMessage("Wrong number."),
                Times.Exactly(2));
        }
    }
}