using GumballMachine.State;
using GumballMachine.State.Impl;
using System.Text;

namespace GumballMachine
{
    public class GumballMachine : IGumballMachine
    {
        private uint _count = 0;
        private SoldState _soldState;
        private SoldOutState _soldOutState;
        private NoQuarterState _noQuarterState;
        private HasQuarterState _hasQuarterState;
        private IState _state;

        public uint BallCount => _count;

        public GumballMachine(uint numBalls)
        {
            _count = numBalls;
            _soldState = new SoldState(this);
            _soldOutState = new SoldOutState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuarterState = new HasQuarterState(this);
            _state = _count > 0 ? _noQuarterState : _soldOutState;
        }

        public void InsertQuarter()
        {
            _state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            _state.EjectQuarter();
        }

        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Inventory: {_count} gumball{(_count != 1 ? "s" : "")}");
            stringBuilder.AppendLine($"Machine is {_state.ToString()}");

            return stringBuilder.ToString();
        }

        void IGumballMachine.ReleaseBall()
        {
            if (_count != 0)
            {
                Console.WriteLine("A gumball comes rolling out the slot...");
                _count--;
            }
        }

        void IGumballMachine.SetHasQuarterState()
        {
            _state = _hasQuarterState;
        }

        void IGumballMachine.SetNoQuarterState()
        {
            _state = _noQuarterState;
        }

        void IGumballMachine.SetSoldOutState()
        {
            _state = _soldOutState;
        }

        void IGumballMachine.SetSoldState()
        {
            _state = _soldState;
        }
    }
}
