using NUnit.Framework;
using Moq;
using UserViewCalculator;
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
            Mock<IConsole> mock = new Mock<IConsole>();
            mock.Setup(p => p.ReadLine()).Returns("");

            userCalculator = new UserConsoleCalculator(mock.Object);

            //Act
            userCalculator.Start();

            //Assert
            mock.Verify(p => p.WriteLine("Enter comma separated numbers (enter to exit):"));
        }

        [Test]
        public void Start_EnterValue_ShouldReturnSecondMsg()
        {
            //Arrange
            Mock<IConsole> mock = new Mock<IConsole>();
            mock.SetupSequence(p => p.ReadLine())
                .Returns("1,2")
                .Returns("");

            userCalculator = new UserConsoleCalculator(mock.Object);

            //Act
            userCalculator.Start();

            //Assert
            mock.Verify(p => p.WriteLine("You can enter other numbers (enter to exit)?"));
        }
        [Test]
        public void Start_EnterValues_ShouldReturnTwoSecondMsg()
        {
            //Arrange
            Mock<IConsole> mock = new Mock<IConsole>();
            mock.SetupSequence(p => p.ReadLine())
                .Returns("1,2")
                .Returns("4,5")
                .Returns("");


            userCalculator = new UserConsoleCalculator(mock.Object);

            //Act
            userCalculator.Start();

            //Assert
            mock.Verify(p => p.WriteLine("You can enter other numbers (enter to exit)?"),Times.Exactly(2));
        }

        [Test]
        public void Start_EnterValue_ShouldReturnValue()
        {
            //Arrange
            Mock<IConsole> mock = new Mock<IConsole>();

            mock.SetupSequence(p => p.ReadLine())
                .Returns("1")
                .Returns("");

            userCalculator = new UserConsoleCalculator(mock.Object);

            //Act
            userCalculator.Start();

            //Assert
/*            mock.Verify(p => p.WriteLine("You can enter other numbers (enter to exit)?"),Times.Exactly(3));*/
            mock.Verify(p => p.WriteLine("Result is 1"));
        }

        [Test]
        public void Start_EnterValues_ShouldReturnTwiceResultMsg()
        {
            //Arrange
            Mock<IConsole> mock = new Mock<IConsole>();

            mock.SetupSequence(p => p.ReadLine())
                .Returns("1,2")
                .Returns("4,5")
                .Returns("");

            userCalculator = new UserConsoleCalculator(mock.Object);

            //Act
            userCalculator.Start();

            //Assert
            mock.Verify(p => p.WriteLine("Result is 3"));
            mock.Verify(p => p.WriteLine("Result is 9"));
        }

        [Test]
        public void Start_EnterMoreValues_ShouldReturnResult()
        {
            //Arrange
            Mock<IConsole> mock = new Mock<IConsole>();

            mock.SetupSequence(p => p.ReadLine())
                .Returns("1,3,5,7")
                .Returns("");

            userCalculator = new UserConsoleCalculator(mock.Object);

            //Act
            userCalculator.Start();

            //Assert
            mock.Verify(p => p.WriteLine("Result is 16"));
        }
       
    }
}