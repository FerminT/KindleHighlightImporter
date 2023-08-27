using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using VersOne.Epub;

namespace KindleHighlightImporter
{
    public static class EpubManager
    {
        public static void DivideInChapters(List<Book> books, IDictionary<string, EpubBook> epubBooks)
        {
            foreach (Book b in books)
            {
                string bookTitle = b.Title;
                if (!epubBooks.ContainsKey(bookTitle))
                {
                    MessageBox.Show("Could not find epub file for book " + bookTitle);
                    continue;
                }
                EpubBook epubBook = epubBooks[bookTitle];
                List<Highlight> highlights = b.Highlights;
                highlights.Sort();

                Chapter chapter = null;
                bool newChapter = false;
                foreach (Highlight h in highlights)
                {

                }
            }
            throw new System.NotImplementedException();
        }
        public static IDictionary<string, EpubBook> GetAllBooks(string dir)
        {
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("Invalid path for epub books");
                Application.Exit();
            }

            IDictionary<string, EpubBook> epubBooks = new Dictionary<string, EpubBook>();
            string[] files = Directory.GetFileSystemEntries(dir);
            LookForBooks(files, epubBooks);

            return epubBooks;
        }
        private static void LookForBooks(string[] files, IDictionary<string, EpubBook> epubBooks)
        {
            foreach (string fileName in files)
            {
                if (File.Exists(fileName) && Path.GetExtension(fileName) == ".epub")
                {
                    EpubBook book = EpubReader.ReadBook(fileName);
                    epubBooks.Add(book.Title, book);
                }
                else if (Directory.Exists(fileName))
                {
                    files = Directory.GetFileSystemEntries(fileName);
                    LookForBooks(files, epubBooks);
                }
            }
        }
    }
}
