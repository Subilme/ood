using Command.Document;

namespace Command.App
{
    public class Editor
    {
        private Menu _menu;
        private IDocument _document;
        private HTMLSaver _saver;

        public Editor()
        {
            _menu = new Menu();
            _document = new Document.Document();
            _saver = new HTMLSaver();

            _menu.AddCommand("insert_paragraph", "Insert paragraph in document", InsertParagraph);
            _menu.AddCommand("insert_image", "Insert image in document", InsertImage);
            _menu.AddCommand("set_title", "Set title of document", SetTitle);
            _menu.AddCommand("list", "Show document content", (string command) => { ShowDocument(); });
            _menu.AddCommand("replace_text", "Replace text in paragraph", ReplaceText);
            _menu.AddCommand("resize_image", "Resize image", ResizeImage);
            _menu.AddCommand("delete_item", "Delete item", DeleteItem);
            _menu.AddCommand("undo", "Undo last change", (string command) => { Undo(); });
            _menu.AddCommand("redo", "Redo last undo", (string command) => { Redo(); });
            _menu.AddCommand("save", "Save and exit", Save);
            _menu.AddCommand("help", "Show all commands", (string command) => { _menu.ShowCommands(); });
            _menu.AddCommand("exit", "Exit from program", (string command) => { _menu.Exit(); });
        }

        public void Run()
        {
            _menu.Run();

            _document.Dispose();
        }

        private void InsertParagraph(string command)
        {
            try
            {
                var line = command.Split(" ");
                int index = (line[1] == "end") ? _document.GetItemsCount() : int.Parse(line[1]);
                string text = String.Join(" ", line.Skip(2));

                _document.InsertParagraph(text, index);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void InsertImage(string command)
        {
            try
            {
                var line = command.Split(" ");
                int index = (line[1] == "end") ? _document.GetItemsCount() : int.Parse(line[1]);
                int width = int.Parse(line[2]);
                int height = int.Parse(line[3]);
                string path = line[4];

                _document.InsertImage(path, width, height, index);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetTitle(string command)
        {
            try
            {
                string title = command.Split(" ")[1];
                _document.Title = title;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowDocument()
        {
            Console.WriteLine($"Title: {_document.Title}");
            for (int i = 0; i < _document.GetItemsCount(); i++)
            {
                Console.Write($"{i}. ");
                if (_document.GetConstItem(i).Paragraph != null)
                {
                    Console.WriteLine($"Paragraph: {_document.GetConstItem(i).Paragraph.Text}");
                }
                else
                {
                    var img = _document.GetConstItem(i).Image;
                    Console.WriteLine($"Image: {img.Width}x{img.Height}, src: {img.Path}");
                }
            }
        }

        private void ReplaceText(string command)
        {
            try
            {
                var line = command.Split(" ");
                int index = int.Parse(line[1]);
                string text = string.Join(" ", line.Skip(2));

                _document.ReplaceText(index, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ResizeImage(string command)
        {
            try
            {
                var line = command.Split(" ");
                int index = int.Parse(line[1]);
                int width = int.Parse(line[2]);
                int height = int.Parse(line[3]);

                _document.ResizeImage(index, width, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteItem(string command)
        {
            try
            {
                var line = command.Split(" ");
                int index = int.Parse(line[1]);

                _document.RemoveItem(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Undo()
        {
            if (_document.CanUndo())
            {
                _document.Undo();
            }
            else
            {
                Console.WriteLine("No operations to undo");
            }
        }

        private void Redo()
        {
            if (_document.CanRedo())
            {
                _document.Redo();
            }
            else
            {
                Console.WriteLine("No operations to redo");
            }
        }

        private void Save(string command)
        {
            try
            {
                var line = command.Split(" ");
                string path = line[1];

                _saver.Save(path, _document);
                _menu.Exit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
