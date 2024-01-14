using MultiGumballMachine;
using MultiGumballMachine.State;

namespace MultiGumballMachineTests.MultiGumballMachine
{
    public class GumballMachineMock : GumballMachine
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
