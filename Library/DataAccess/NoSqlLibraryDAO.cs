using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

namespace Library
{
    class NoSqlLibrary : ILibraryDAO
    {
        private List<Book> books = new List<Book>();

        public List<Book> FindAll()
        {
            List<Book> all = new List<Book>();

            using (var db = new LiteDatabase(@"Library.db"))
            {
                var books = db.GetCollection<Book>("books");

                foreach (var b in books.FindAll())
                {
                    all.Add(b);
                }
            }
            return all;
        }

        void ILibraryDAO.Add(Book b)
        {
            using (var db = new LiteDatabase(@"Library.db"))
            {
                var books = db.GetCollection<Book>("books");

                books.Insert(b);
            }
        }

        void ILibraryDAO.RemoveByTitle(string title)
        {
            using (var db = new LiteDatabase(@"Library.db"))
            {
                var books = db.GetCollection<Book>("books");

                books.DeleteMany(b => b.Title == title);
            }
        }

        List<Book> ILibraryDAO.SearchByTitle(string title)
        {
            List<Book> titleContains = new List<Book>();

            using (var db = new LiteDatabase(@"Library.db"))
            {
                var books = db.GetCollection<Book>("books");

                foreach (var b in books.FindAll())
                {
                    if (b.Title.Contains(title))
                    {
                        titleContains.Add(b);
                    }
                }
                return titleContains;
            }
        }

        List<Book> ILibraryDAO.SearchByAuthor(string author)
        {
            List<Book> bookFrom = new List<Book>();

            using (var db = new LiteDatabase(@"Library.db"))
            {
                var books = db.GetCollection<Book>("books");

                foreach (var b in books.FindAll())
                {
                    if (b.Author == author)
                    {
                        bookFrom.Add(b);
                    }
                }
                return bookFrom;
            }
        }
    }
}
