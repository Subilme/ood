using Xunit;

namespace GumballMachineTests
{
    // TODO: Тесты для классов состояний
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

            machineMock.InsertQuarter();

            Assert.True(stateMock.QuarterInserted);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.CrankTurned);
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

            machineMock.EjectQuarter();

            Assert.True(stateMock.QuarterEjected);
            Assert.False(stateMock.Dispensed);
            Assert.False(stateMock.QuarterInserted);
            Assert.False(stateMock.CrankTurned);
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

            machineMock.TurnCrank();

            Assert.True(stateMock.CrankTurned);
            Assert.True(stateMock.Dispensed);
            Assert.False(stateMock.QuarterEjected);
            Assert.False(stateMock.QuarterInserted);
        }
    }
}
