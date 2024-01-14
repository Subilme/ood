using GumballMachineWithFilling.State;
using GumballMachineWithFilling.State.Impl;
using Xunit;

namespace GumballMachineWithFillingTests
{
    public class HasQuarterStateTest
    {
        [Fact]
        public void HasQuarterState_Dispense_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState hasQuarterState = new HasQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            hasQuarterState.Dispense();
            string expected = "No gumball dispensed\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void HasQuarterState_InsertQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState hasQuarterState = new HasQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            hasQuarterState.InsertQuarter();
            string expected = "You inserted another quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void HasQuarterState_TurnCrank_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState hasQuarterState = new HasQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            hasQuarterState.TurnCrank();
            string expected = "You turned...\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.True(machineMock.BaseState is SoldState);
        }

        [Fact]
        public void HasQuarterState_EjectQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState hasQuarterState = new HasQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            hasQuarterState.EjectQuarter();
            string expected = "Quarter returned\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.True(machineMock.BaseState is NoQuarterState);
        }

        [Fact]
        public void HasQuarterState_FillCorrectBallCount_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            Assert.Equal((uint)5, machineMock.BallCount);
            IState hasQuarterState = new HasQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            hasQuarterState.AddBalls(5);
            string expected = "You inserted gumball\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.Equal((uint)10, machineMock.BallCount);
        }

        [Fact]
        public void HasQuarterState_ToString_ReturnsCorrectValue()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState hasQuarterState = new HasQuarterState(machineMock);
            string expected = "waiting for turn of crank";

            Assert.Equal(expected, hasQuarterState.ToString());
        }
    }
}
