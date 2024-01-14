using GumballMachine.State;
using GumballMachine.State.Impl;
using Xunit;

namespace GumballMachineTests
{
    public class SoldOutStateTests
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
        public void SoldOutState_ToString_ReturnsCorrectValue()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldOutState = new SoldOutState(machineMock);
            string expected = "sold out";

            Assert.Equal(expected, soldOutState.ToString());
        }
    }
}
