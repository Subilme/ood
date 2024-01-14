using MultiGumballMachine.State;
using MultiGumballMachine.State.Impl;
using Xunit;

namespace MultiGumballMachineTests.MultiGumballMachine
{
    public class MaxQuartersStateTests
    {
        [Fact]
        public void MaxQuartersState_Dispense_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState maxQuarterState = new MaxQuartersState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            maxQuarterState.Dispense();
            string expected = "No gumball dispensed\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void MaxQuartersState_InsertQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState maxQuarterState = new MaxQuartersState(machineMock);
            maxQuarterState.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            maxQuarterState.InsertQuarter();
            string expected = "You can`t insert another quarter: max is 5\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void MaxQuartersState_TurnCrank_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState maxQuarterState = new MaxQuartersState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            maxQuarterState.TurnCrank();
            string expected = "You turned...\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.True(machineMock.BaseState is SoldState);
        }

        [Fact]
        public void MaxQuartersState_EjectQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState maxQuarterState = new MaxQuartersState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            maxQuarterState.EjectQuarter();
            string expected = "Quarter returned\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.True(machineMock.BaseState is NoQuarterState);
        }

        [Fact]
        public void MaxQuartersState_ToString_ReturnsCorrectValue()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState maxQuarterState = new MaxQuartersState(machineMock);
            string expected = "filled in. Waiting for turn of crank";

            Assert.Equal(expected, maxQuarterState.ToString());
        }
    }
}
