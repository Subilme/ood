namespace Streams.Input
{
    public interface IInputStream
    {
        public bool IsEof();

        public int ReadByte();

        public uint ReadBlock(uint dataSize);
    }
}
