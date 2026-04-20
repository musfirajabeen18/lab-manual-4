using System;
using System.Collections.Generic;

namespace LabTasks
{
    class Book
    {
        public string title;
        public string author;
        public int pages;
        public List<string> chapters = new List<string>();
        public int bookMark;
        public int price;
        public bool isAvailable;

    
        public Book(string t, string a, int p, int pr, bool available)
        {
            title = t;
            author = a;
            pages = p;
            price = pr;
            isAvailable = available;
            bookMark = 0; 
        }

        public bool isBookAvailable()
        {
            return isAvailable;
        }

        public string getChapter(int chapterNumber)
        {
            
            if (chapterNumber >= 0 && chapterNumber < chapters.Count)
            {
                return chapters[chapterNumber];
            }
            return "Chapter not found";
        }

        public int getBookMark()
        {
            return bookMark;
        }
    }

    class Program2
    {
      static void Main(string[] args)
        {
            Book myBook = new Book("OOP with C#", "John Doe", 500, 1500, true);
            myBook.chapters.Add("Introduction");
            myBook.chapters.Add("Classes and Objects");
            myBook.bookMark = 120;

            Console.WriteLine("Book Title: " + myBook.title);
            Console.WriteLine("Is Available: " + myBook.isBookAvailable());
            Console.WriteLine("Chapter 1: " + myBook.getChapter(1));
            Console.WriteLine("Bookmark at page: " + myBook.getBookMark());
        }
    }
}