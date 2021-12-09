/*
Розробити модуль програмного забезпечення, що використовується у бібліотеці,
який буде дозволяти читачу користуватися послугами електронного каталогу тільки у випадку,
якщо у даного читача є власний логін у цьому програмному забезпеченні. 
У протилежному випадку модуль повинен пропонувати читачу зареєструватися у програмі.
*/
using System;
using static System.Console;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstr_Library library = new Checker();
            Reader reader1 = new Reader(0, "Marchelino Brynkovian", 16, true);
            Reader reader2 = new Reader(1, "Alexander Kostyliev", 45, false);
            Reader reader3 = new Reader(2, "Ekaterina Drobotenko", 18, true);
            library.GetLibraryBooksList(reader1);
            library.GetLibraryBooksList(reader2);
            library.GetLibraryBooksList(reader3);
        }
    }

    class Reader
    {
        private int id;
        public int Id { get { return id; } set { if (value > 0) { id = value; } } }
        public string name;
        private int age;
        public int Age { get { return age; } set { if (value > 0) { age = value; } } }
        public bool hasLogin = false;
        public Reader(int id , string name, int age, bool hasLogin)
        {
            Id = id;
            this.name = name;
            Age = age;
            this.hasLogin = hasLogin;
        }
    }

    abstract class Abstr_Library
    {
        public abstract void GetLibraryBooksList(Reader reader);
    }

    class Book
    {
        public int id;
        public string name;
        public string author;
        public int publishedDate;

        public Book(int id, string name, string author, int publishedDate)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.publishedDate = publishedDate;
        }

        public override string ToString()
        {
            return $"({id}) - '{name}', {author} - {publishedDate}";
        }
    }

    class BooksList
    {
        public List<Book> CreateBooksList()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book(1, "The Lord of Rings", "J.R.R Tolkien", 1937));
            books.Add(new Book(2, "Witch 2", "Tom Cruise", 2021));
            books.Add(new Book(3, "Kateryna", "Taras Shevchenko", 1865));
            books.Add(new Book(4, "The Great Gatsby", "F. Scott Fitzerald", 1925));
            books.Add(new Book(5, "The Godfather", "Mario Puzo", 1995));
            books.Add(new Book(6, "The Black Swan", "Nassim Nicholas Taleb", 2000));
            books.Add(new Book(7, "Ivanhoe", "Walter Scott", 1819));
            books.Add(new Book(8, "Im Westen nichts Neues", "Erich Maria Remarque", 1937));
            books.Add(new Book(9, "Human, All Too Human", "Friedrich Nietzsche", 1887));
            books.Add(new Book(10, "1984", "George Orwell", 1847));
            return books;
        }
    }

    class Library : Abstr_Library
    {
        public override void GetLibraryBooksList(Reader reader)
        {
            WriteLine($"Hi, {reader.name}!\nWelcome to our library :)");
            WriteLine("Enter 'search' to choose a book.");
            List<Book> books = new BooksList().CreateBooksList();
            if (ReadLine() == "search")
            {
                foreach (Book book in books)
                {
                    WriteLine(book.ToString());
                }
                WriteLine("Which one would you like to read?");
                int id = 0;
                if (int.TryParse(ReadLine(), out id) && id >= 1 && id <= books.Count)
                {
                    WriteLine($"Excellent choise! Have a nice day");
                }
                else
                {
                    WriteLine($"Oops, we don't have any books with this number! \nPlease, try again.");
                }
            }
            else
            {
                WriteLine("\nOoops, unknown command!\nPlease, try again.");
            }
        }
    }

    class Checker : Abstr_Library
    {
        Library library = new Library();
        public override void GetLibraryBooksList(Reader reader)
        {
            if (reader.hasLogin)
            {
                library.GetLibraryBooksList(reader);
            }
            else
            {
                WriteLine($"\nOops, user {reader.name}, you are not logged in!\nPlease, log in and try again.\n");
            }
        }
    }
}
