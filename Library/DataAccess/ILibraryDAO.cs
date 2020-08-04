using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    interface ILibraryDAO
    {
        void RemoveByTitle(string title);
        void Add(Book b);

        List<Book> SearchByTitle(string title);

        List<Book> SearchByAuthor(string author);

        List<Book> FindAll();
    }
}
