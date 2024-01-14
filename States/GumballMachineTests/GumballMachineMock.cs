using GumballMachine.State;

namespace GumballMachineTests
{
    public class GumballMachineMock : GumballMachine.GumballMachine
    {
        public IState BaseState
        {
            get => _state;
            set => _state = value;
        }

        public GumballMachineMock(uint numBalls)
            : base(numBalls)
        {
        }
    }
}
