using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class LibraryService
    {

        private static ILibraryDAO libraryDAO = new InMemoryLibraryDAO();

        public static List<Book> GetAllBooks()
        {
            return libraryDAO.FindAll();
        }

        public static void RemoveByTitle(string title)
        {
            libraryDAO.RemoveByTitle(title);

        }

        public static List<Book> SearchByAuthor(string author)
        {
            return libraryDAO.SearchByAuthor(author);
        }

        public static List<Book> SearchByTitle(string title)
        {
            return libraryDAO.SearchByTitle(title);
        }

        internal static void AddBook(Book bookToAdd)
        {
            libraryDAO.Add(bookToAdd);
        }
    }
}
