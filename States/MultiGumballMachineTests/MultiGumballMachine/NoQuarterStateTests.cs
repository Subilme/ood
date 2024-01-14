using MultiGumballMachine.State;
using MultiGumballMachine.State.Impl;
using Xunit;

namespace MultiGumballMachineTests.MultiGumballMachine
{
    public class NoQuarterStateTest
    {
        [Fact]
        public void NoQuarterState_Dispense_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState noQuarterState = new NoQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            noQuarterState.Dispense();
            string expected = "You need to pay first\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void NoQuarterState_EjectQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState noQuarterState = new NoQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            noQuarterState.EjectQuarter();
            string expected = "You haven't inserted a quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void NoQuarterState_InsertQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState noQuarterState = new NoQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            noQuarterState.InsertQuarter();
            string expected = "You inserted a quarter\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.True(machineMock.BaseState is HasQuarterState);
        }

        [Fact]
        public void NoQuarterState_TurnCrank_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState noQuarterState = new NoQuarterState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            noQuarterState.TurnCrank();
            string expected = "You turned but there's no quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void NoQuarterState_ToString_ReturnsCorrectValue()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState noQuarterState = new NoQuarterState(machineMock);
            string expected = "waiting for quarter";

            Assert.Equal(expected, noQuarterState.ToString());
        }
    }
}
