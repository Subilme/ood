namespace Streams.Input
{
    public class InputStreamDecorator : IInputStream
    {
        protected IInputStream _inputStream;

        protected InputStreamDecorator(IInputStream inputStream)
        {
            _inputStream = inputStream;
        }

        public virtual bool IsEof()
        {
            return _inputStream.IsEof();
        }

        public virtual byte ReadByte()
        {
            return _inputStream.ReadByte();
        }

        public virtual void ReadBlock(ref List<byte> dstData, int size)
        {
            _inputStream.ReadBlock(ref dstData, size);
        }
    }
}
