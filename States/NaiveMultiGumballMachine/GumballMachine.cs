using System.Text;

namespace NaiveMultiGumballMachine
{
    internal enum State
    {
        SoldOut,
        NoQuarter,
        HasQuarter,
        MaxQuarters,
        Sold
    }

    public class GumballMachine
    {
        private const uint _maxQuartersCount = 5;

        private uint _count;
        private uint _quartersCount;
        private State _state;

        public GumballMachine(uint count)
        {
            _count = count;
            _quartersCount = 0;
            _state = count > 0 ? State.NoQuarter : State.SoldOut;
        }

        public void InsertQuarter()
        {
            switch (_state)
            {
                case State.SoldOut:
                    Console.WriteLine("You can't insert a quarter, the machine is sold out");
                    break;
                case State.NoQuarter:
                    Console.WriteLine("You inserted a quarter");
                    _quartersCount++;
                    _state = State.HasQuarter;
                    break;
                case State.HasQuarter:
                    Console.WriteLine("You inserted another quarter");
                    _quartersCount++;
                    _state = _quartersCount == _maxQuartersCount ? State.MaxQuarters : _state;
                    break;
                case State.MaxQuarters:
                    Console.WriteLine($"You can`t insert another quarter: max is {_maxQuartersCount}");
                    break;
                case State.Sold:
                    Console.WriteLine("Please wait, we're already giving you a gumball");
                    break;
            }
        }

        public void EjectQuarter()
        {
            switch (_state)
            {
                case State.SoldOut:
                    if (_quartersCount > 0)
                    {
                        Console.WriteLine("Quarter returned");
                        _quartersCount = 0;
                    }
                    else
                    {
                        Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
                    }
                    break;
                case State.NoQuarter:
                    Console.WriteLine("You haven't inserted a quarter");
                    break;
                case State.MaxQuarters:
                case State.HasQuarter:
                    Console.WriteLine($"Quarter returned");
                    _quartersCount = 0;
                    _state = State.NoQuarter;
                    break;
                case State.Sold:
                    Console.WriteLine("Sorry, you already turned the crank");
                    break;
            }
        }

        public void TurnCrank()
        {
            switch (_state)
            {
                case State.SoldOut:
                    Console.WriteLine("You turned, but there is no gumballs");
                    break;
                case State.NoQuarter:
                    Console.WriteLine("You turned, but there is no quarter");
                    break;
                case State.MaxQuarters:
                case State.HasQuarter:
                    Console.WriteLine("You turned...");
                    if (_quartersCount > 0)
                    {
                        _quartersCount--;
                    }
                    _state = State.Sold;
                    Dispense();
                    break;
                case State.Sold:
                    Console.WriteLine("Turning twice doesn`t get you another gumball");
                    break;
            }
        }

        private void Dispense()
        {
            switch (_state)
            {
                case State.MaxQuarters:
                case State.SoldOut:
                case State.HasQuarter:
                    Console.WriteLine("No gumball dispensed");
                    break;
                case State.NoQuarter:
                    Console.WriteLine("You need to pay first");
                    break;
                case State.Sold:
                    Console.WriteLine("A gumball comes rolling out the slot");
                    _count--;
                    if (_count == 0)
                    {
                        Console.WriteLine("Oops, out of gumballs");
                        _state = State.SoldOut;
                    }
                    else
                    {
                        _state = State.NoQuarter;
                    }
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Inventory: {_count} gumball{(_count != 1 ? "s" : "")}");
            stringBuilder.AppendLine($"Quarters in machine: {_quartersCount}");
            stringBuilder.Append("Machine is ");
            stringBuilder.AppendLine((_state == State.SoldOut) ? "sold out" :
                (_state == State.NoQuarter) ? "waiting for quarter" :
                (_state == State.HasQuarter) ? "waiting for turn of crank" : "delivering a gumball");

            return stringBuilder.ToString();
        }
    }
}
