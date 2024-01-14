namespace Command.Content
{
    public class Paragraph : IParagraph
    {
        public string Text { get; private init; }

        public Paragraph(string text)
        {
            Text = text;
        }
    }
}
