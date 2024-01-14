namespace Streams.Output
{
    public interface IOutputStream
    {
        public void WriteByte(uint data);
        public void WriteBlock(uint dataSize);
    }
}
