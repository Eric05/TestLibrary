using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class Library
    {
        public static List<Book> Books = new List<Book>();
       
        public Library(List<Book> booklist)
        {
            Books = booklist;
        }

        public static List<Book> GetAllBooks()
        {
            return Books;
        }

        public static void RemoveByTitle(string title)
        {
            Books.RemoveAll(b => b.Title == title);
        }

        public static List<Book> SearchByAuthor(string author)
        {
            List<Book> bookFrom = Books.Where(b => b.Author == author).ToList();
            return bookFrom;
        }

        public static List<Book> SearchByTitle(string title)
        {
            List<Book> titleContains = Books.Where(b => b.Title.Contains(title)).ToList();
            return titleContains;
        }
    }
}
