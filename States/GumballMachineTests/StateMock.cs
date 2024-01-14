using GumballMachine.State;

namespace GumballMachineTests
{
    public class StateMock : IState
    {
        public bool Dispensed { get; set; } = false;
        public bool QuarterEjected { get; set; } = false;
        public bool QuarterInserted { get; set; } = false;
        public bool CrankTurned { get; set; } = false;

        public void Dispense()
        {
            Dispensed = true;
        }

        public void EjectQuarter()
        {
            QuarterEjected = true;
        }

        public void InsertQuarter()
        {
            QuarterInserted = true;
        }

        public void TurnCrank()
        {
            CrankTurned = true;
        }   
    }
}
