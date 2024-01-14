namespace AdapterObjectApp.ModernGraphicsLib
{
    public class RGBAColor
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
        public float Alpha { get; set; }

        public RGBAColor(float red, float green, float blue, float alpha = 1)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public uint ParseToInt()
        {
            return (uint)(0x10000 * Red + 0x100 * Green + Blue);
        }
    }
}
