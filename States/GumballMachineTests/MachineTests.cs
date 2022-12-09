using Xunit;

namespace GumballMachineTests
{
    // TODO: Тесты для классов состояний
    public class MachineTests
    {
        [Fact]
        public void TryInsertQuarter_SoldOutState_FailedToInsert()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine.GumballMachine machine = new(0);

            machine.InsertQuarter();
            string expected = "You can't insert a quarter, the machine is sold out\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryEjectQuarter_SoldOutState_FailedToEject()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine.GumballMachine machine = new(0);

            machine.EjectQuarter();
            string expected = "You can't eject, you haven't inserted a quarter yet\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryTurnCrank_SoldOutState_FailedToTurn()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine.GumballMachine machine = new(0);

            machine.TurnCrank();
            string expected = "You turned but there's no gumballs\r\nNo gumball dispensed\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryInsertQuarter_NoQuarterState_QuarterInserted()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine.GumballMachine machine = new(5);

            machine.InsertQuarter();
            string expected = "You inserted a quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryEjectQuarter_NoQuarterState_FailedToEject()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine.GumballMachine machine = new(5);

            machine.EjectQuarter();
            string expected = "You haven't inserted a quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryTurnCrank_NoQuarterState_FailedToTurn()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine.GumballMachine machine = new(5);

            machine.TurnCrank();
            string expected = "You turned but there's no quarter\r\nYou need to pay first\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryInsertQuarter_HasQuarterState_FailedToInsert()
        {
            GumballMachine.GumballMachine machine = new(5);

            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.InsertQuarter();
            string expected = "You can`t insert another quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryEjectQuarter_HasQuarterState_QuarterEjected()
        {
            GumballMachine.GumballMachine machine = new(5);

            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.EjectQuarter();
            string expected = "Quarter returned\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryTurnCrank_HasQuarterState_GumballDelivered()
        {
            GumballMachine.GumballMachine machine = new(5);

            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.TurnCrank();
            string expected = "You turned...\r\nA gumball comes rolling out the slot...\r\n";

            Assert.Equal(expected, writer.ToString());
        }
    }
}
