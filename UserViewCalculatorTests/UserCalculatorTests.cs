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
        public void Start_EnterEmptyLine_ShouldWriteFirstMessage()
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
        public void Start_EnterValues_ShouldReturnResultString()
        {
            //Arrange
            Mock<IConsole> mock = new Mock<IConsole>();

            mock.SetupSequence(p => p.ReadLine())
                .Returns("1")
                .Returns("1,2")
                .Returns("1,2,3")
                .Returns("");

            userCalculator = new UserConsoleCalculator(mock.Object);

            //Act
            userCalculator.Start();

            //Assert
            mock.Verify(p => p.WriteLine("You can enter other numbers (enter to exit)?"),Times.Exactly(3));
            mock.Verify(p => p.WriteLine("Result is 1"));
            mock.Verify(p => p.WriteLine("Result is 3"));
            mock.Verify(p => p.WriteLine("Result is 6"));
        }

    }
}