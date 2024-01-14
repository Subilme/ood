using Xunit;

namespace GumballMachineWithFillingTests
{
    public class GumballMachineTest
    {
        [Fact]
        public void GumballMachine_InsertQuarter_CallsStateMethod()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            StateMock stateMock = new StateMock();
            machineMock.BaseState = stateMock;

            Assert.False(stateMock.QuarterInserted);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.CrankTurned);
            Assert.False(stateMock.Filled);

            machineMock.InsertQuarter();

            Assert.True(stateMock.QuarterInserted);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.CrankTurned);
            Assert.False(stateMock.Filled);
        }

        [Fact]
        public void GumballMachine_EjectQuarter_CallsStateMethod()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            StateMock stateMock = new StateMock();
            machineMock.BaseState = stateMock;
            Assert.False(stateMock.QuarterInserted);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.CrankTurned);
            Assert.False(stateMock.Filled);

            machineMock.EjectQuarter();

            Assert.True(stateMock.QuarterEjected);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterInserted);
            Assert.False(stateMock.CrankTurned);
            Assert.False(stateMock.Filled);
        }

        [Fact]
        public void GumballMachine_TurnCrank_CallsStateMethods()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            StateMock stateMock = new StateMock();
            machineMock.BaseState = stateMock;
            Assert.False(stateMock.QuarterInserted);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.CrankTurned);
            Assert.False(stateMock.Filled);

            machineMock.TurnCrank();

            Assert.True(stateMock.CrankTurned);
            Assert.True(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.QuarterInserted);
            Assert.False(stateMock.Filled);
        }

        [Fact]
        public void GumballMachine_InsertBalls_CallsStateMethods()
        {
            GumballMachineMock machineMock = new GumballMachineMock(5);
            StateMock stateMock = new StateMock();
            machineMock.BaseState = stateMock;
            Assert.False(stateMock.QuarterInserted);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.CrankTurned);
            Assert.False(stateMock.Filled);

            machineMock.InsertBalls(5);

            Assert.True(stateMock.Filled);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.QuarterInserted);
            Assert.False(stateMock.CrankTurned);
        }
    }
}
