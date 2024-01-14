namespace Streams.Input
{
    public class Decompressor : InputStreamDecorator
    {
        private byte _currByte;
        private byte _currByteCount;

        public Decompressor(IInputStream inputStream) : base(inputStream) { }


    }
}
