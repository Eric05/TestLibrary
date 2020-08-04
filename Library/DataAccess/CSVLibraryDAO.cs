using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace Library
{
    public class CSVLibrary : ILibraryDAO
    {
        private static string path = GlobalConfig.CsvPath;
        private List<string> booklist = new List<string>();

        public CSVLibrary()
        {
            booklist = File.ReadAllLines(path).ToList();
        }
        public void Add(Book b)
        {
            string text = b.Author + ',' + b.Title + ',' + b.Pages + b.Genre;
            File.AppendAllText(path, text + Environment.NewLine);
        }

        public List<Book> FindAll()
        {
            List<Book> list = new List<Book>();

            foreach (var b in booklist)
            {
                var cols = b.Split(",");
                Book book = new Book(cols[0], cols[1], Convert.ToInt32(cols[2]), cols[3]);
                list.Add(book);
            }
            return list;
        }

        public void RemoveByTitle(string title)
        {
            int counter = 0;

            foreach (var b in booklist)
            {
                var cols = b.Split(",");
                var cleanTitle = cols[0].Replace("\"", string.Empty);

                if (cleanTitle.Trim().Equals(title))
                {
                    booklist.RemoveAt(counter);
                    File.WriteAllLines(path, booklist.ToArray());
                }
                counter++;
            }
        }

        public List<Book> SearchByAuthor(string author)
        {
            List<Book> list = new List<Book>();

            foreach (var b in booklist)
            {
                var cols = b.Split(",");
                var auth = cols[1].Replace("\"", string.Empty);
                if (auth.Trim().Equals(author))
                {
                    Book book = new Book(cols[0], cols[1], Convert.ToInt32(cols[2]));
                    list.Add(book);
                }
            }
            return list;
        }

        public List<Book> SearchByTitle(string title)
        {
            List<Book> list = new List<Book>();

            foreach (var b in booklist)
            {
                var cols = b.Split(",");
                var cleanTitle = cols[0].Replace("\"", string.Empty);
                if (cleanTitle.Trim().Contains(title))
                {
                    Book book = new Book(cols[0], cols[1], Convert.ToInt32(cols[2]));
                    list.Add(book);
                }
            }
            return list;
        }
    }
}
