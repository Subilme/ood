namespace Streams.Output
{
    public class OutputStreamDecorator : IOutputStream
    {
        protected IOutputStream _outputStream;

        protected OutputStreamDecorator(IOutputStream outputStream)
        {
            _outputStream = outputStream;
        }

        public virtual void WriteByte(byte data)
        {
            _outputStream.WriteByte(data);
        }
     
        public virtual void WriteBlock(List<byte> srcData, int dataSize)
        {
            _outputStream.WriteBlock(srcData, dataSize);
        }
    }
}
