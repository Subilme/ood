using Streams.Extensions;

namespace Streams.Input
{
    public class Decryptor : InputStreamDecorator
    {
        private List<byte> _shuffledList;

        public Decryptor(IInputStream inputStream, byte key) : base(inputStream)
        {
            _shuffledList = new List<byte>();
            for (byte i = byte.MinValue; i < byte.MaxValue; i++)
            {
                _shuffledList.Add(i);
            }
            _shuffledList.Shuffle(key);
        }

        public override byte ReadByte()
        {
            return (byte)_shuffledList.IndexOf(_inputStream.ReadByte());
        }

        public override void ReadBlock(ref List<byte> dstData, int size)
        {
            dstData = new List<byte>();
            for (int i = 0; i < size; i++)
            {
                dstData.Add(ReadByte());
            }
        }
    }
}
