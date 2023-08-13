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
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            // EpubBook book = EpubReader.ReadBook("E:\\Documents\\OneDrive - UBA\\eBooks\\Popular Science\\Behave, The Biology of Humans at Our Best and Worst - Robert M. Sapolsky (2017).epub");
            string file_path   = txtFrom.Text;
            string output_file = txtTo.Text;
            int lastLineRead   = Int32.Parse(ConfigurationManager.AppSettings["lastLineRead"]);
            string[] myClippings = File.ReadAllLines(file_path);

            List<Book> books = ClippingsParser.Parse(myClippings, lastLineRead);

            ENEXWriter.WriteToFile(books, output_file);

            ConfigManager.UpdateAttribute("lastLineRead", myClippings.Length.ToString());
            ConfigManager.UpdateAttribute("inputFile", txtFrom.Text);
            ConfigManager.UpdateAttribute("outputFile", txtTo.Text);

            MessageBox.Show("Import was successful.", "Kindle Highlight Importer", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Exit();
        }
    }
}
