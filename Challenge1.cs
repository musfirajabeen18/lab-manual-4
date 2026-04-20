using System;

namespace BookstoreSystem
{
    class Book
    {
        public string title;
        public string[] authors = new string[4];
        public int authorCount;
        public string publisher;
        public string ISBN;
        public float price;
        public int stock;
        public int year;


        public Book()
        {
            authorCount = 0;
            stock = 0;
        }




        public void setTitle(string t)
         { 
            title = t;
          }
        public string getTitle() 
        { 
            return title; 
        }
        public void showTitle() 
        {
             Console.WriteLine("Title: " + title); 
        }
        public bool isTitleSame(string t)
         { 
            return title.ToLower() == t.ToLower();
          }


        public void setStock(int s) 
        { 
            stock = s; 
        }
        public int getStock()
         { 
            return stock; 
         }
        public void showStock() 
        {
             Console.WriteLine("Copies in Stock: " + stock); 
        }
        public void updateStock(int amount) 
        { 
            stock += amount; 
        }


        public void setISBN(string isbn) 
        { 
            ISBN = isbn; 
        }
        public string getISBN()
         { 
            return ISBN; 
         }


        public void addAuthor(string name)
        {
            if (authorCount < 4)
            {
                authors[authorCount] = name;
                authorCount++;
            }
        }

        public void showBookDetails()
        {
            Console.WriteLine("-----------------------------");
            showTitle();
            Console.Write("Authors: ");
            for (int i = 0; i < authorCount; i++) { Console.Write(authors[i] + (i < authorCount - 1 ? ", " : "")); }
            Console.WriteLine("\nPublisher: " + publisher);
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Price: " + price);
            showStock();
            Console.WriteLine("Year: " + year);
            Console.WriteLine("-----------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Book[] library = new Book[100];
            int totalBooks = 0;
            int choice = 0;

            while (choice != 5)
            {
                Console.WriteLine("\n--- BOOKSTORE MENU ---");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Search by Title");
                Console.WriteLine("3. Search by ISBN");
                Console.WriteLine("4. Update Stock");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    if (totalBooks < 100)
                    {
                        Book b = new Book();
                        Console.Write("Enter Title: "); 
                        b.setTitle(Console.ReadLine());
                        Console.Write("Enter ISBN: ");
                         b.setISBN(Console.ReadLine());
                        Console.Write("Enter Publisher: "); 
                        b.publisher = Console.ReadLine();
                        Console.Write("Enter Price: "); 
                        b.price = float.Parse(Console.ReadLine());
                        Console.Write("Enter Stock: "); 
                        b.setStock(int.Parse(Console.ReadLine()));
                        Console.Write("Enter Year: "); 
                        b.year = int.Parse(Console.ReadLine());

                        Console.Write("How many authors (max 4)? ");
                        int numAuth = int.Parse(Console.ReadLine());
                        for (int i = 0; i < numAuth; i++)
                        {
                            Console.Write("Enter Author " + (i + 1) + ": ");
                            b.addAuthor(Console.ReadLine());
                        }

                        library[totalBooks] = b;
                        totalBooks++;
                        Console.WriteLine("Book added successfully!");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Title to search: ");
                    string searchT = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < totalBooks; i++)
                    {
                        if (library[i].isTitleSame(searchT))
                        {
                            library[i].showBookDetails();
                            found = true;
                        }
                    }
                    if (!found) Console.WriteLine("Book not found.");
                }
                else if (choice == 3)
                {
                    Console.Write("Enter ISBN to search: ");
                    string searchISBN = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < totalBooks; i++)
                    {
                        if (library[i].getISBN() == searchISBN)
                        {
                            library[i].showBookDetails();
                            found = true;
                        }
                    }
                    if (!found) Console.WriteLine("Book not found.");
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Title of book to update stock: ");
                    string t = Console.ReadLine();
                    for (int i = 0; i < totalBooks; i++)
                    {
                        if (library[i].isTitleSame(t))
                        {
                            Console.Write("Enter amount to add (use negative to decrease): ");
                            int change = int.Parse(Console.ReadLine());
                            library[i].updateStock(change);
                            Console.WriteLine("Stock updated.");
                        }
                    }
                }
            }
        }
    }
}