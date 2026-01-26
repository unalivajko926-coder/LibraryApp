using LibraryApp.Models;
using System.Collections.Generic;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Война и мир", "Лев Толстой", 1869, 1225);
            IBorrowable borrowable = book;
            borrowable.Borrow("Иван Иванов");
            borrowable.Borrow("Петр Петров");
            borrowable.Return();
        }
    }
}