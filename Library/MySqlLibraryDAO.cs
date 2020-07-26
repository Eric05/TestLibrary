using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    // TODO implement real DB connection (mysql?)
    class MySqlLibraryDao : ILibraryDAO
    {
        private List<Book> books;

        public MySqlLibraryDao()
        {
            books = new List<Book>()
                {
                     new Book("Win 10", "gates", 460, Genre.SCIENCE),
                     new Book("harry", "jk", 500),
                     new Book("JCVD", "van Damme", 120, Genre.ACTION),
                     new Book("herr", "tolkien", 900),
                     new Book("Patterns", "fritz", 300, Genre.SCIENCE),
                     new Book("fitness", "eric", 300, Genre.SCIENCE),
                     new Book("bahnhof", "franz", 450, Genre.ACTION)
                };
        }
        public List<Book> FindAll()
        {
            return books;
        }

        void ILibraryDAO.Add(Book b)
        {
            books.Add(b);
        }

        void ILibraryDAO.RemoveByTitle(string title)
        {
            books.RemoveAll(b => b.Title == title);
        }

        List<Book> ILibraryDAO.SearchByTitle(string title)
        {
            List<Book> titleContains = books.Where(b => b.Title.Contains(title)).ToList();
            return titleContains;
        }

        List<Book> ILibraryDAO.SearchByAuthor(string author)
        {
            List<Book> bookFrom = books.Where(b => b.Author == author).ToList();
            return bookFrom;
        }
    }
}
