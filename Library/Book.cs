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
        public string Genre { get; set; }

        public Book(string title, string author, int pages, string genre = "VARIOUS")
        {
            Title = title;
            Author = author;
            Pages = pages;
            Genre = genre;
        }
    }
}
