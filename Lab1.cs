using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp2
{

    class Book
    {
        public string Date { get; set; }
        public string Author_Name { get; set; } 
        public string Book_Name { get; set; }
        public override string ToString()
        {
            return $"({Date }, {Author_Name}, {Book_Name})";
        }
    }

    class Library 
    {
        public List<Book> list_book = new List<Book>();

        public void Add_book(Book book)
        {
            list_book.Add(book);
        }
        public void Delete_book()
        {
            Console.WriteLine("Введите номер книги когорую хотите удалить");
            int ind = Convert.ToInt32(Console.ReadLine());
            
            foreach (var item in list_book)
            {
                
                if (list_book.IndexOf(item) == ind)
                {
                    list_book.RemoveAt(ind);
                    break;
                }
                
            }
        }
        public void Show_book()
        {
            foreach (var item in list_book)
            {
                Console.WriteLine(item);
            }
            
        }
        
        public void Sort_Book()
        {
            
            Console.WriteLine("По какому признаку хотите сортировать?");
            Console.WriteLine("1. По дате");
            Console.WriteLine("2. По имени автора");
            Console.WriteLine("3. По названии книги");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    list_book.Sort((a, b) => a.Date.CompareTo(b.Date));
                    break;
                case 2:
                    list_book.Sort((a, b) => a.Author_Name.CompareTo(b.Author_Name));
                    break;
                case 3:
                    list_book.Sort((a, b) => a.Book_Name.CompareTo(b.Book_Name));
                    break;
            }
            
        }

       
        public Book Find_by_Date(string date)
        {
            foreach (var item in list_book)
            {
                if (item.Date == date)
                {
                    Console.WriteLine(item);
                    return item;
                }
            }
                return null;
        }
        public Book Find_by_AuthorName(string author_name)
        {
            foreach (var item in list_book)
            {
                if (item.Author_Name == author_name)
                {
                    Console.WriteLine(item);
                    return item;
                }
            }
            return null;
        }
        
        public Book Find_by_BookName(string book_name)
        {
            foreach (var item in list_book)
            {
                if (item.Book_Name == book_name)
                {
                    Console.WriteLine(item);
                    return item;
                }
            }
            return null;
        }
           
        
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            Library _Books = new Library();
            BACK:
            Console.WriteLine("Введите действие которое хотите совершить");
            Console.WriteLine("1. Найти книгу по году");
            Console.WriteLine("2. Найти книгу по автору");
            Console.WriteLine("3. Найти книгу по ее названию");
            Console.WriteLine("4. Добавить книгу");
            Console.WriteLine("5. Удалить книгу");
            Console.WriteLine("6. Посмотреть имеющиеся книги");
            Console.WriteLine("7. Сортировка");
            Console.WriteLine("8. Выйти");
            int _Var = Convert.ToInt32(Console.ReadLine());
            switch (_Var)
            {
                case 1:
                    _Books.Find_by_Date(Console.ReadLine());
                    goto BACK;
                case 2:
                    _Books.Find_by_AuthorName(Console.ReadLine());
                    goto BACK;
                case 3:
                    _Books.Find_by_BookName(Console.ReadLine());
                    goto BACK;
                case 4:
                    Console.WriteLine("Введите год издания, имя автора, название книги");
                    _Books.Add_book(new Book
                    {
                        Date = Console.ReadLine(),
                        Author_Name = Console.ReadLine(),
                        Book_Name = Console.ReadLine()
                    });
                    goto BACK;
                case 5:
                    _Books.Delete_book();
                    goto BACK;
                case 6:
                    _Books.Show_book();
                    goto BACK;
                case 7:
                    _Books.Sort_Book();
                    goto BACK;
                case 8:
                    break;
            }

            Console.ReadKey();
        }
    }
}
