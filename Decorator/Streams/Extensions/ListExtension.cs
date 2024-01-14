namespace Streams.Extensions
{
    public static class ListExtension
    {
        public static void Shuffle<T>(this List<T> list, byte key)
        {
            Random rand = new Random(key);

            int counter = list.Count;
            while (counter > 0)
            {
                int reposition = rand.Next(counter);
                counter--;
                (list[reposition], list[counter]) = (list[counter], list[reposition]);
            }
        }
    }
}
