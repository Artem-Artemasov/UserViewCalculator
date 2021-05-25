using NUnit.Framework;
using Moq;
using UserViewCalculator;
using StringCalculator;
using UserViewCalculator.Interface;

namespace UserViewCalculatorTests
{
    public class UserConsoleCalculatorTests
    {
        UserConsoleCalculator userCalculator;

        [Test]
        public void Start_EnterEmptyLine_ShouldWriteFirstMsg()
        {
            //Arrange
            Mock<IConsole> mockConsole = new Mock<IConsole>();
            Mock<Calculator> mockCalculator = new Mock<Calculator>();

            mockConsole.Setup(p => p.ReadLine()).Returns("");
            mockCalculator.Setup(p => p.Add("")).Returns(0);

            userCalculator = new UserConsoleCalculator(mockConsole.Object,mockCalculator.Object);

            //Act
            userCalculator.Start();

            //Assert
            mockConsole.Verify(p => p.WriteLine("Enter comma separated numbers (enter to exit):"));
        }

        [Test]
        public void Start_EnterValue_ShouldReturnSecondMsg()
        {
            //Arrange
            Mock<IConsole> mockConsole = new Mock<IConsole>();
            Mock<Calculator> mockCalculator = new Mock<Calculator>();

            mockConsole.SetupSequence(p => p.ReadLine())
                .Returns("1,2")
                .Returns("");
            mockCalculator.Setup(p => p.Add("1,2")).Returns(3);

            userCalculator = new UserConsoleCalculator(mockConsole.Object,mockCalculator.Object);

            //Act
            userCalculator.Start();

            //Assert
            mockConsole.Verify(p => p.WriteLine("You can enter other numbers (enter to exit)?"));
        }
        [Test]
        public void Start_EnterValues_ShouldReturnTwoSecondMsg()
        {
            //Arrange
            Mock<IConsole> mockConsole = new Mock<IConsole>();
            Mock<Calculator> mockCalculator = new Mock<Calculator>();
            mockConsole.SetupSequence(p => p.ReadLine())
                .Returns("1,2")
                .Returns("4,5")
                .Returns("");

            mockCalculator.SetupSequence(p => p.Add(It.IsAny<string>()))
                .Returns(3)
                .Returns(9);

            userCalculator = new UserConsoleCalculator(mockConsole.Object,mockCalculator.Object);

            //Act
            userCalculator.Start();

            //Assert
            mockConsole.Verify(p => p.WriteLine("You can enter other numbers (enter to exit)?"),Times.Exactly(2));
        }

        [Test]
        public void Start_EnterOneValue_ShouldReturnThisValue()
        {
            //Arrange
            Mock<IConsole> mockConsole = new Mock<IConsole>();
            Mock<Calculator> mockCalculator = new Mock<Calculator>();

            mockConsole.SetupSequence(p => p.ReadLine())
                .Returns("1")
                .Returns("");
            mockCalculator.Setup(p => p.Add("1")).Returns(1);

            userCalculator = new UserConsoleCalculator(mockConsole.Object,mockCalculator.Object);

            //Act
            userCalculator.Start();

            //Assert
            mockConsole.Verify(p => p.WriteLine("Result is 1"));
        }


        [Test]
        public void Start_TwiceEnterValues_ShouldReturnTwiceResultMsg()
        {
            //Arrange
            Mock<IConsole> mockConsole = new Mock<IConsole>();
            Mock<Calculator> mockCalculator = new Mock<Calculator>();

            mockConsole.SetupSequence(p => p.ReadLine())
                .Returns("1,2")
                .Returns("4,5")
                .Returns("");

            mockCalculator.Setup(p => p.Add("1,2")).Returns(3);
            mockCalculator.Setup(p => p.Add("4,5")).Returns(9);

            userCalculator = new UserConsoleCalculator(mockConsole.Object,mockCalculator.Object);

            //Act
            userCalculator.Start();

            //Assert
            mockConsole.Verify(p => p.WriteLine("Result is 3"));
            mockConsole.Verify(p => p.WriteLine("Result is 9"));
        }
    }
}