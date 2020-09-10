using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KindleHighlightImporter
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public List<Highlight> Highlights { get; }

        public Book (string title, string author)
        {
            Title = title;
            Author = author;
            Highlights = new List<Highlight>();
        }

        public void AddHighlight (Highlight newHighlight)
        {
            CheckForDuplicateHighlights(newHighlight);
            Highlights.Add(newHighlight);
        }

        public void SortHighlights()
        {
            Highlights.Sort();
        }

        private void CheckForDuplicateHighlights (Highlight newHighlight)
        {
            try
            {
                // Si ya tengo un highlight que es prefijo del highlight a agregar, lo considero un duplicado y lo elimino
                foreach (Highlight h in Highlights.ToList())
                {
                    if (newHighlight.Text.StartsWith(h.Text))
                        Highlights.Remove(h);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fatal al buscar highlights duplicados: " + ex.Message);
                Application.Exit();
            }
        }

        public bool Equals (Book b)
        {
            if (b is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, b))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != b.GetType())
            {
                return false;
            }

            return (Author == b.Author && Title == b.Title);
        }

        public override bool Equals (object obj)
        {
            return this.Equals(obj as Book);
        }

        public static bool operator == (Book b1, Book b2)
        {
            // Check for null on left side.
            if (b1 is null)
            {
                if (b2 is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return b1.Equals(b2);
        }

        public static bool operator != (Book b1, Book b2)
        {
            return !(b1 == b2);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Author.GetHashCode();
                hash = (hash * 16777619) ^ Title.GetHashCode();
                return hash;
            }
        }
        public override string ToString()
        {
            return Title + " (" + Author + ")";
        }
    }
    public class Highlight : IComparable<Highlight>
    {
        public string Text { get; }
        public string Date { get; }
        public string Location { get; }

        public Highlight(string text, string date, string location)
        {
            Text = text;
            Date = date;
            Location = location;
        }

        public override string ToString()
        {
            return Text + " (" + Location + ") (" + Date + ")";
        }

        public int CompareTo(Highlight h)
        {
            if (this > h)
            {
                return 1;
            }
            else if (this < h)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static bool operator <(Highlight h1, Highlight h2)
        {
            char[] locationDelimiters = { ' ', '-' };
            int location_h1 = Int32.Parse(h1.Location.Split(locationDelimiters)[1]);
            int location_h2 = Int32.Parse(h2.Location.Split(locationDelimiters)[1]);
            return (location_h1 < location_h2);
        }
        public static bool operator >(Highlight h1, Highlight h2)
        {
            char[] locationDelimiters = { ' ', '-' };
            int location_h1 = Int32.Parse(h1.Location.Split(locationDelimiters)[1]);
            int location_h2 = Int32.Parse(h2.Location.Split(locationDelimiters)[1]);
            return (location_h1 > location_h2);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Text.GetHashCode();
                hash = (hash * 16777619) ^ Location.GetHashCode();
                hash = (hash * 16777619) ^ Date.GetHashCode();
                return hash;
            }
        }
    }
}
