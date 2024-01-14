using Streams.Extensions;

namespace Streams.Output
{
    public class Encryptor : OutputStreamDecorator
    {
        private List<byte> _shuffledList;

        public Encryptor(IOutputStream outputStream, byte key) : base(outputStream)
        {
            _shuffledList = new List<byte>();
            for (byte i = byte.MinValue; i < byte.MaxValue; i++)
            {
                _shuffledList.Add(i);
            }
            _shuffledList.Shuffle(key);
        }

        public override void WriteByte(byte data)
        {
            _outputStream.WriteByte(_shuffledList[data]);
        }

        public override void WriteBlock(List<byte> srcData, int dataSize)
        {
            foreach (var item in srcData)
            {
                WriteByte(item);
            }
        }
    }
}
