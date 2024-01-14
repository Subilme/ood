using GumballMachine.State;
using GumballMachine.State.Impl;
using Xunit;

namespace GumballMachineTests
{
    public class SoldStateTests
    {
        [Fact]
        public void SoldState_Dispense_BallCountEqualsOne_PrintsCorrectOutputAndChangesStateToSoldOut()
        {
            GumballMachineMock machineMock = new GumballMachineMock(1);
            IState soldState = new SoldState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldState.Dispense();
            string expected = "A gumball comes rolling out the slot...\r\nOops, out of gumballs\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.True(machineMock.BaseState is SoldOutState);
        }

        [Fact]
        public void SoldState_Dispense_BallCountEqualsZero_PrintsCorrectOutputAndChangesStateToSoldOut()
        {
            GumballMachineMock machineMock = new GumballMachineMock(0);
            IState soldState = new SoldState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldState.Dispense();
            string expected = "Oops, out of gumballs\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.True(machineMock.BaseState is SoldOutState);
        }

        [Fact]
        public void SoldState_Dispense_BallCountMoreThanOne_ChangesStateToNoQuarter()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldState = new SoldState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldState.Dispense();
            string expected = "A gumball comes rolling out the slot...\r\n";

            Assert.Equal(expected, writer.ToString());
            Assert.True(machineMock.BaseState is NoQuarterState);
        }

        [Fact]
        public void SoldState_EjectQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldState = new SoldState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldState.EjectQuarter();
            string expected = "Sorry, you already turned the crank\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void SoldState_InsertQuarter_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldState = new SoldState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldState.InsertQuarter();
            string expected = "Please wait, we're already giving you a gumball\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void SoldState_TurnCrank_PrintsCorrectOutput()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldState = new SoldState(machineMock);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            soldState.TurnCrank();
            string expected = "Turning twice doesn't get you another gumball\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void SoldState_ToString_ReturnsCorrectValue()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            IState soldState = new SoldState(machineMock);
            string expected = "delivering a gumball";

            Assert.Equal(expected, soldState.ToString());
        }
    }
}
