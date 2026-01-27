
using LibraryApp.Models;
using LibraryApp.Services;

var library = new Library();
bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("=== Библиотека ===");
    Console.WriteLine("1. Добавить книгу");
    Console.WriteLine("2. Добавить журнал");
    Console.WriteLine("3. Показать все");
    Console.WriteLine("4. Поиск по автору");
    Console.WriteLine("5. Выдать книгу");
    Console.WriteLine("0. Выход");
    Console.Write("Выбор: ");
   
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1": AddBook(library); break;
        case "2": AddMagazine(library); break;
        case "3": ShowAll(library); break;
        case "4": SearchByAuthor(library); break;
        case "5": BorrowBook(library); break;
        case "0": running = false; break;
        default:
        Console.WriteLine("Неверный выбор. Нажмите любую клавишу..."); Console.ReadKey(); break;
    }
}

static void AddBook(Library library)
{
    try
    {
        Console.Write("Название: "); string title = Console.ReadLine();
        Console.Write("Автор: "); string author = Console.ReadLine();
        Console.Write("Год: "); int year = int.Parse(Console.ReadLine());
        Console.Write("Страницы: "); int pages = int.Parse(Console.ReadLine());
        library.AddItem(new Book(title, author, year, pages));
        Console.WriteLine("Книга добавлена!");
     }
     catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
    Console.ReadKey();
 }
 
static void AddMagazine(Library library)
{
    try
    {
        Console.Write("Название: "); string title = Console.ReadLine();
        Console.Write("Автор: "); string author = Console.ReadLine();
        Console.Write("Год: "); int year = int.Parse(Console.ReadLine());
        Console.Write("Номер: "); int issueNumber = int.Parse(Console.ReadLine());
        library.AddItem(new Magazine(title, author, year, issueNumber));
        Console.WriteLine("Журнал добавлен!");
     }
     catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
    Console.ReadKey();
}

static void ShowAll(Library library)
{
    Console.WriteLine("=== Все элементы библиотеки ===");
    foreach (var item in library.GetAllItems())
    {
        item.DisplayInfo();
    }
    Console.WriteLine("Нажмите любую клавишу...");
    Console.ReadKey();
}

static void SearchByAuthor(Library library)
{
    Console.Write("Введите имя автора: ");
    string author = Console.ReadLine();
    var results = library.SearchByAuthor(author);
    Console.WriteLine($"=== Результаты поиска по автору: {author} ===");

    bool found = false;
    foreach (var item in results)
    {
        if (item is LibraryItem libraryItem)
        {
            libraryItem.DisplayInfo(); 
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("Ничего не найдено.");
    }

    Console.WriteLine("Нажмите любую клавишу...");
    Console.ReadKey();
}

static void BorrowBook(Library library)
{
    Console.Write("Введите название книги для выдачи: ");
    string title = Console.ReadLine();
    var book = library.GetAllItems()
                      .OfType<Book>()
                      .FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    if (book != null)
    {
        try
        {
            book.Borrow("Пользователь");
            Console.WriteLine("Книга успешно выдана!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Книга не найдена.");
    }
    Console.WriteLine("Нажмите любую клавишу...");
    Console.ReadKey();
}
