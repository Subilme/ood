using GumballMachineWithFilling;
using GumballMachineWithFilling.State;

namespace GumballMachineWithFillingTests
{
    public class GumballMachineMock : GumballMachine
    {
        public IState BaseState
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public GumballMachineMock(uint ballCount)
            : base(ballCount)
        {
        }
    }
}
