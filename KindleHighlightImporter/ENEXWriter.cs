using System;
using System.Collections.Generic;
using System.Xml;

namespace KindleHighlightImporter
{
    public class ENEXWriter
    {
        public static void WriteToFile(List<Book> books, string destination_file)
        {
            XmlWriter xmlWriter = XmlWriter.Create(destination_file);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteDocType("en-export", null, "http://xml.evernote.com/pub/evernote-export2.dtd", null);

            // Escribo encabezado
            xmlWriter.WriteStartElement("en-export");
            xmlWriter.WriteAttributeString("export-date", GetCurrentDate());
            xmlWriter.WriteAttributeString("application", "Evernote/Windows");
            xmlWriter.WriteAttributeString("version", "6.x");

            foreach (Book b in books)
            {
                // Una nota por libro
                xmlWriter.WriteStartElement("note");

                xmlWriter.WriteStartElement("title");
                xmlWriter.WriteString(b.Title);
                xmlWriter.WriteEndElement();

                // Escribo encabezado
                xmlWriter.WriteStartElement("content");
                xmlWriter.WriteRaw("<![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine);
                xmlWriter.WriteRaw("<!DOCTYPE en-note SYSTEM \"http://xml.evernote.com/pub/enml2.dtd\">");
                xmlWriter.WriteStartElement("en-note");
                xmlWriter.WriteStartElement("div");
                xmlWriter.WriteStartElement("ul");

                // Los ordeno según su ubicación
                b.SortHighlights();
                // Cada highlight es un bullet de una lista
                foreach (Highlight h in b.Highlights)
                {
                    xmlWriter.WriteStartElement("li");
                    xmlWriter.WriteStartElement("div");

                    xmlWriter.WriteStartElement("i");
                    xmlWriter.WriteRaw(h.Text);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteString(" (" + h.Location + ") ");
                    xmlWriter.WriteString("(" + h.Date + ")");

                    // Cierro div
                    xmlWriter.WriteEndElement();
                    // Cierro li
                    xmlWriter.WriteEndElement();
                }

                // Cierro ul
                xmlWriter.WriteEndElement();
                // Cierro div
                xmlWriter.WriteEndElement();
                // Cierro 'en-note'
                xmlWriter.WriteEndElement();
                xmlWriter.WriteRaw("]]>");

                // Cierro 'content'
                xmlWriter.WriteEndElement();

                // Agrego al autor del libro
                xmlWriter.WriteStartElement("tag");
                xmlWriter.WriteString(b.Author);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("note-attributes");
                xmlWriter.WriteStartElement("author");
                xmlWriter.WriteString("Fermín Travi");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();

                // Cierro 'note'
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private static string GetCurrentDate()
        {
            // Formato: yyyymmddThhmmssZ
            string date = DateTime.UtcNow.ToString("s");
            string[] trimValues = { "-", ":" };
            foreach (string c in trimValues)
                date = date.Replace(c, String.Empty);
            date += 'Z';

            return date;
        }
    }
}
