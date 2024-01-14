namespace Streams.Output
{
    public class Compressor : OutputStreamDecorator
    {
        private byte _currByte;
        private byte _currByteCount;

        public Compressor(IOutputStream outputStream) : base(outputStream) { }

        public override void WriteByte(byte data)
        {
            if (data == _currByte)
            {
                if (_currByteCount == 255)
                {
                    Flush();
                    _currByteCount = 0;
                }
                _currByteCount++;
            }
            else
            {
                Flush();
                _currByte = data;
                _currByteCount = 1;
            }
        }

        private void Flush()
        {
            if (_currByteCount == 0)
            {
                return;
            }

            _outputStream.WriteByte(_currByteCount);
            _outputStream.WriteByte(_currByte);
        }

        public override void WriteBlock(List<byte> srcData, int dataSize)
        {
            foreach (byte item in srcData)
            {
                WriteByte(item);
            }
        }

    }
}
