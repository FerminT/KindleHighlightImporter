using System;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using VersOne.Epub;

namespace KindleHighlightImporter
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            txtFrom.Text = ConfigManager.GetAttribute("inputFile");
            txtTo.Text   = ConfigManager.GetAttribute("outputFile");
            txtEpubDir.Text = ConfigManager.GetAttribute("epubDir");
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            string file_path   = txtFrom.Text;
            string output_file = txtTo.Text;
            int lastLineRead   = Int32.Parse(ConfigurationManager.AppSettings["lastLineRead"]);
            IDictionary<string, EpubBook> epubBooks = GetAllBooks(txtEpubDir.Text);
            string[] myClippings = File.ReadAllLines(file_path);

            List<Book> books = ClippingsParser.Parse(myClippings, lastLineRead);

            ENEXWriter.WriteToFile(books, output_file);

            ConfigManager.UpdateAttribute("lastLineRead", myClippings.Length.ToString());
            ConfigManager.UpdateAttribute("inputFile", txtFrom.Text);
            ConfigManager.UpdateAttribute("outputFile", txtTo.Text);

            MessageBox.Show("Import was successful.", "Kindle Highlight Importer", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Exit();
        }

        private IDictionary<string, EpubBook> GetAllBooks(string dir)
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

        private void LookForBooks(string[] files, IDictionary<string, EpubBook> epubBooks)
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
