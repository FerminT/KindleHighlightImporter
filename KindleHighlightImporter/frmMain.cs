using System;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace KindleHighlightImporter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            txtFrom.Text = ConfigManager.GetAttribute("inputFile");
            txtTo.Text   = ConfigManager.GetAttribute("outputFile");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
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
