using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
   public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; } 

        public Book(string title, string author, int pages, Genre genre = Genre.FANTASY)
        {
            Title = title;
            Author = author;
            Pages = pages;
            Genre = genre;
            
            AddBookToLib(this);
        }

        internal void AddBookToLib(Book b)
        {
            Library.Books.Add(b);
        }
    }
}
