using GumballMachine.State;
using GumballMachine.State.Impl;
using Xunit;

namespace GumballMachineTests
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
            string expected = "You can`t insert another quarter\r\n";

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
        public void HasQuarterState_ToString_ReturnsCorrectValue()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState hasQuarterState = new HasQuarterState(machineMock);
            string expected = "waiting for turn of crank";

            Assert.Equal(expected, hasQuarterState.ToString());
        }
    }
}
