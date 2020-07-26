using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Library
{
    class Program
    {
        static bool isRunning = true;
        static void Main()
        {
            Init();
        }

        static void Init()
        {
            new LibraryService();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("\t\tWelcome to our Bookshop");
            Console.WriteLine("__________________________________________________________");

            while (isRunning)
            {
                HandleInput();
            }
        }

        static void PrintAllBooks()
        {
            var list = LibraryService.GetAllBooks().GroupBy(b => b.Genre);

            foreach (var group in list)
            {
                Console.WriteLine(group.Key + ":");
                foreach (var item in group)
                {
                    Console.WriteLine($" '{item.Title}' by '{item.Author}' with {item.Pages} pages");
                }
                Console.WriteLine("");
            }
        }

        static void RemoveByTitle()
        {
            if (!CheckAdmin())
            {
                Console.WriteLine("you are not allowed to delete");
                return;
            }

            Console.WriteLine("Enter title:");
            string title = Console.ReadLine();
            LibraryService.RemoveByTitle(title);
            Console.WriteLine($"book with {title} removed");
        }

        static void PrintSearchResult()
        {
            Console.WriteLine("Enter author:");
            string title = Console.ReadLine();

            var res = LibraryService.SearchByAuthor(title);

            if (res.Count < 1)
            {
                Console.WriteLine("sorry no book available.");
                return;
            }

            foreach (var r in res)
            {
                Console.WriteLine($"{r.Genre}:  '{r.Title}' by '{r.Author}' with {r.Pages} pages");
            }
        }

        static void PrintSearchResultTitle()
        {
            Console.WriteLine("Enter title:");
            string title = Console.ReadLine();

            var res = LibraryService.SearchByTitle(title);

            if (res.Count < 1)
            {
                Console.WriteLine("sorry no book available.");
                return;
            }

            foreach (var r in res)
            {
                Console.WriteLine($"{r.Genre}:  '{r.Title}' by '{r.Author}' with {r.Pages} pages");
            }
        }

        static void AddBook()
        {
            if (!CheckAdmin())
            {
                Console.WriteLine("you are not allowed to add");
                return;
            }

            try
            {
                Console.WriteLine("enter book");
                var bookDataArr = Console.ReadLine().Split(",").ToArray();
                if (bookDataArr.Length == 3 || bookDataArr.Length == 4)
                {
                    Book bookToAdd = new Book(bookDataArr[0], bookDataArr[1], Convert.ToInt32(bookDataArr[2]));
                    LibraryService.AddBook(bookToAdd);
                }
                else
                {
                    Console.WriteLine("Please enter book with all properties- seperated by comma");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void HandleInput()
        {
            string inp = string.Empty;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;

            try
            {
                Console.WriteLine("\t (s)how all\n\t (f)ind author\n\t (t)itle search\n\t (a)dd new book\n\t (d)elete book");
                inp = Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            Console.ForegroundColor = ConsoleColor.White;

            switch (inp)
            {
                case "a":
                    AddBook();
                    break;
                case "d":
                    RemoveByTitle();
                    break;
                case "f":
                    PrintSearchResult();
                    break;
                case "s":
                    PrintAllBooks();
                    break;
                case "t":
                    PrintSearchResultTitle();
                    break;
                default:
                    isRunning = false;
                    break;
            }

        }
        static bool CheckAdmin()
        {
            if (Admin.IsAdmin == true)
            {
                return true;
            }
            Console.WriteLine("Enter your Username:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            Console.ForegroundColor = ConsoleColor.Black;
            string pass = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (name == Admin.Name && Hash(pass) == Admin.Password)
            {
                Admin.IsAdmin = true;
                return true;
            }
            return false;
        }
        static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
