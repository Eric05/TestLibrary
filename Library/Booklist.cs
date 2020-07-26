using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public static class Booklist
    {
        public static List<Book> bookList = new List<Book>()
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
}
