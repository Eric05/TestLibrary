using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class LibraryService
    {

        private static ILibraryDAO libraryDAO = GetDataConnection(GlobalConfig.dataConnection);

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

        internal static ILibraryDAO GetDataConnection(string data)
        {
            ILibraryDAO libraryDAO;

            switch (data)
            {
                case "nosql":
                    libraryDAO = new NoSqlLibrary();
                    break;
                case "csv":
                    libraryDAO = new CSVLibrary();
                    break;
                default:
                    libraryDAO = new InMemoryLibraryDAO();
                    break;
            }
            return libraryDAO;
        }
    }
}
