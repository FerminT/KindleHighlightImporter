using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KindleHighlightImporter
{
    public static class ClippingsParser
    {
        public static List<Book> Parse (string[] myClippings, int lastLineRead)
        {
            if (myClippings.Length <= lastLineRead)
            {
                DialogResult result = MessageBox.Show("The file to import has less lines than the last time it was imported. Import from scratch?", "Change in My Clippings", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    lastLineRead = 0;
                }
                else
                {
                    Application.Exit();
                }
            }
            List<Book> books = LoadBooks(myClippings, lastLineRead);

            foreach (Book currentBook in books)
            {
                int count = 0;
                bool isSameBook = false;
                string date = String.Empty;
                string location = String.Empty;
                string text = String.Empty;

                // Recorro My Clippings.txt y me quedo con aquellos highlights que pertenezcan al libro actual
                foreach (string line in myClippings)
                {
                    count %= 5;
                    if (count == 0 && line != String.Empty)
                        isSameBook = currentBook == GetBookFromLine(line);

                    if (isSameBook)
                    {
                        if (count == 1)
                        {
                            // Obtengo metadata del highlight
                            date     = GetMetadataFromLine(line).date;
                            location = GetMetadataFromLine(line).location;
                        }

                        if (count == 2)
                        {
                            // Salteo espacio en blanco
                        }

                        if (count == 3)
                        {
                            // Obtengo el highlight y lo guardo en el libro
                            text = line;
                            if (text.Length > 0)
                                currentBook.AddHighlight(new Highlight(text, date, location));
                        }
                    }
                    count++;
                }
            }
            return books;
        }

        private static List<Book> LoadBooks(string[] myClippings, int index)
        {
            List<Book> books = new List<Book>();
            int count = 0;
            while (index < myClippings.Length)
            {
                string line = myClippings[index];
                count %= 5;
                if (count == 0 && line != String.Empty)
                {
                    Book currentBook = GetBookFromLine(line);
                    if (!books.Contains(currentBook))
                        books.Add(currentBook);
                }
                count++;
                index++;
            }

            return books;
        }

        private static Book GetBookFromLine (string line)
        {
            string title = String.Empty;
            string author = String.Empty;
            try
            {
                char[] delimiterChars_header = { '(', ')' };
                string[] words_header = line.Split(delimiterChars_header);
                title = words_header[0].Trim(' ');
                author = words_header[words_header.Length - 2];

                // Reemplazo las comas, ya que divide los tags en Evernote
                author = author.Replace(",", " -");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fatal al parsear un título: " + ex.Message);
                Application.Exit();
            }

            return new Book (title, author);
        }

        private static (string date, string location) GetMetadataFromLine (string line)
        {
            string date = String.Empty;
            string location = String.Empty;
            try
            {
                char[] delimiterChars_metadata = { '|' };
                string[] words_metadata = line.Split(delimiterChars_metadata);

                // Fecha
                char[] delimiterChars_date = { ',' };
                date = words_metadata[words_metadata.Length - 1];
                string[] date_components = date.Split(delimiterChars_date);
                date = date_components[1].Trim(' ') + "," + date_components[2] + "," + date_components[3];

                // Ubicación
                string[] words_location = words_metadata[0].Trim(' ').Split(' ');
                int len_location = words_location.Length;
                location = words_location[len_location - 2] + ' ' + words_location[len_location - 1];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fatal al obtener la metadata del highlight: " + ex.Message);
                Application.Exit();
            }

            return (date, location);
        }
    }
}
