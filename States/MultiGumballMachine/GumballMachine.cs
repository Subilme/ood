using MultiGumballMachine.State;
using MultiGumballMachine.State.Impl;
using System.Text;

namespace MultiGumballMachine
{
    public class GumballMachine : IGumballMachine
    {
        private const uint InternalMaxQuartersCount = 5;

        private uint _count = 0;
        private uint _quartersCount;
        private SoldState _soldState;
        private SoldOutState _soldOutState;
        private NoQuarterState _noQuarterState;
        private HasQuarterState _hasQuarterState;
        private MaxQuartersState _maxQuartersState;
        private IState _state;

        public uint BallCount => _count;
        public uint QuartersCount
        {
            get => _quartersCount;
            set => _quartersCount = value;
        }
        public uint MaxQuartersCount => InternalMaxQuartersCount;

        public GumballMachine(uint numBalls)
        {
            _count = numBalls;
            _quartersCount = 0;
            _soldState = new SoldState(this);
            _soldOutState = new SoldOutState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuarterState = new HasQuarterState(this);
            _maxQuartersState = new MaxQuartersState(this);
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
            stringBuilder.AppendLine($"Quarters in machine: {_quartersCount}");
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

        void IGumballMachine.SetMaxQuartersState()
        {
            _state = _maxQuartersState;
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
