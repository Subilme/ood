using GumballMachineWithFilling.State;
using GumballMachineWithFilling.State.Impl;
using Xunit;

namespace GumballMachineWithFillingTests
{
    public class SoldOutStateTest
    {
        [Fact]
        public void SoldOutState_Dispense_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldOutState = new SoldOutState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldOutState.Dispense();
            string expected = "No gumball dispensed\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void SoldOutState_EjectQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldOutState = new SoldOutState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldOutState.EjectQuarter();
            string expected = "You can't eject, you haven't inserted a quarter yet\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void SoldOutState_InsertQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldOutState = new SoldOutState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldOutState.InsertQuarter();
            string expected = "You can't insert a quarter, the machine is sold out\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void SoldOutState_TurnCrank_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldOutState = new SoldOutState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldOutState.TurnCrank();
            string expected = "You turned but there's no gumballs\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void SoldOutState_FillCorrectBallCount_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            Assert.Equal((uint)5, machineMock.BallCount);
            IState soldOutState = new SoldOutState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldOutState.AddBalls(5);
            string expected = "You inserted gumball\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.Equal((uint)10, machineMock.BallCount);
        }

        [Fact]
        public void SoldOutState_ToString_ReturnsCorrectValue()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldOutState = new SoldOutState(machineMock);
            string expected = "sold out";

            Assert.Equal(expected, soldOutState.ToString());
        }
    }
}
