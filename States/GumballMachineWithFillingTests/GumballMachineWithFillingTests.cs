using Xunit;
using GumballMachineWithFilling;

namespace GumballMachineWithFillingTests
{
    public class GumballMachineWithFillingTests
    {
        [Fact]
        public void TryInsertQuarter_SoldOutState_FailedToInsert()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(0);

            machine.InsertQuarter();
            string expected = "You can't insert a quarter, the machine is sold out\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryEjectQuarter_SoldOutState_FailedToEject()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(0);

            machine.EjectQuarter();
            string expected = "You can't eject, you haven't inserted a quarter yet\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryTurnCrank_SoldOutState_FailedToTurn()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(0);

            machine.TurnCrank();
            string expected = "You turned but there's no gumballs\r\nNo gumball dispensed\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryInsertGumball_SoldOutState_AddGumball()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(0);

            machine.InsertBalls(4);
            string expected = "Inventory: 4 gumballs\r\nQuarters in machine: 0\r\nMachine is waiting for quarter\r\n";

            Assert.Equal(expected, machine.ToString());
        }

        [Fact]
        public void TryInsertQuarter_NoQuarterState_QuarterInserted()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(5);

            machine.InsertQuarter();
            string expected = "You inserted a quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryEjectQuarter_NoQuarterState_FailedToEject()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(5);

            machine.EjectQuarter();
            string expected = "You haven't inserted a quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryTurnCrank_NoQuarterState_FailedToTurn()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(5);

            machine.TurnCrank();
            string expected = "You turned but there's no quarter\r\nYou need to pay first\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryInsertGumball_NoQuarterState_AddGumball()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(2);

            machine.InsertBalls(4);
            string expected = "Inventory: 6 gumballs\r\nQuarters in machine: 0\r\nMachine is waiting for quarter\r\n";

            Assert.Equal(expected, machine.ToString());
        }

        [Fact]
        public void TryInsertQuarter_HasQuarterState_InsertedAnotherQuarter()
        {
            GumballMachine machine = new GumballMachine(5);

            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.InsertQuarter();
            string expected = "You inserted another quarter\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryEjectQuarter_HasQuarterState_QuarterEjected()
        {
            GumballMachine machine = new GumballMachine(5);

            machine.InsertQuarter();
            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.EjectQuarter();
            string expected = "Quarter returned\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryEjectQuarter_HasQuarterState_NoGumball_EjectsAllQuarters()
        {
            GumballMachine machine = new GumballMachine(1);

            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.TurnCrank();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.EjectQuarter();
            string expected = "Quarter returned\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryInsertGumball_HasQuarterState_AddGumball()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(3);

            machine.InsertQuarter();
            machine.InsertBalls(4);
            string expected = "Inventory: 7 gumballs\r\nQuarters in machine: 1\r\nMachine is waiting for turn of crank\r\n";

            Assert.Equal(expected, machine.ToString());
        }

        [Fact]
        public void TryTurnCrank_HasQuarterState_GumballDelivered()
        {
            GumballMachine machine = new GumballMachine(5);

            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.TurnCrank();
            string expected = "You turned...\r\nA gumball comes rolling out the slot...\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryInsertQuarter_MaxQuartersState_FailedToInsert()
        {
            GumballMachine machine = new GumballMachine(5);

            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.InsertQuarter();
            string expected = "You can`t insert another quarter: max is 5\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryEjectQuarter_MaxQuartersState_EjectAllQuarters()
        {
            GumballMachine machine = new GumballMachine(5);

            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.EjectQuarter();
            string expected = "Quarter returned\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryTurnCrank_MaxQuartersState_GumballDelivered()
        {
            GumballMachine machine = new GumballMachine(5);

            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            machine.TurnCrank();
            string expected = "You turned...\r\nA gumball comes rolling out the slot...\r\n";

            Assert.Equal(expected, writer.ToString());
        }

        [Fact]
        public void TryInsertGumball_MaxQuarterState_AddGumball()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            GumballMachine machine = new GumballMachine(2);

            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertQuarter();
            machine.InsertBalls(4);
            string expected = "Inventory: 6 gumballs\r\nQuarters in machine: 5\r\nMachine is filled in. Waiting for turn of crank\r\n";

            Assert.Equal(expected, machine.ToString());
        }
    }
}
