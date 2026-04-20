using System;
using System.Collections.Generic;

namespace BookstoreSimulation
{
   
    class Book
    {
        public string title;
        public string ISBN;
        public float price;
        public int stock;
        public string publisher;
        public int year;

        public Book(string t, string i, float p, int s, string pub, int y)
        {
            title = t; ISBN = i; price = p; stock = s; publisher = pub; year = y;
        }

        public void showDetails()
        {
            Console.WriteLine("Title: " + title + " | ISBN: " + ISBN + " | Price: $" + price + " | Stock: " + stock);
        }
    }

   
    class Member
    {
        public string name;
        public int memberID;
        public int booksCount = 0;
        public float totalSpentInCycle = 0; 
        public Member(string n, int id)
        {
            name = n;
            memberID = id;
        }
    }

    
    class Program
    {
        static List<Book> inventory = new List<Book>();
        static List<Member> members = new List<Member>();
        static float totalStoreSales = 0;
        static float totalFeesCollected = 0;

        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 10)
            {
                Console.WriteLine("\n********** BOOKSTORE MENU **********");
                Console.WriteLine("1. Add a Book           2. Search Book (Title)   3. Search Book (ISBN)");
                Console.WriteLine("4. Update Stock         5. Add a Member          6. Search Member");
                Console.WriteLine("7. Update Member Info   8. Purchase a Book       9. Display Stats");
                Console.WriteLine("10. Exit");
                Console.Write("Enter Option: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                 AddBook();
                else if (choice == 2) 
                SearchByTitle();
                else if (choice == 3)
                 SearchByISBN();
                else if (choice == 4)
                 UpdateStock();
                else if (choice == 5)
                 AddMember();
                else if (choice == 6) 
                SearchMember();
                else if (choice == 7) 
                UpdateMember();
                else if (choice == 8) 
                PurchaseBook();
                else if (choice == 9)
                 DisplayStats();
            }
        }

        static void AddBook()
        {
            Console.Write("Title: "); 
            string t = Console.ReadLine();
            Console.Write("ISBN: "); 
            string i = Console.ReadLine();
            Console.Write("Price: "); 
            float p = float.Parse(Console.ReadLine());
            Console.Write("Stock: "); 
            int s = int.Parse(Console.ReadLine());
            inventory.Add(new Book(t, i, p, s, "Default Pub", 2023));
            Console.WriteLine("Book added to inventory.");
        }

        static void SearchByTitle()
        {
            Console.Write("Enter title: ");
            string t = Console.ReadLine();
            foreach (Book b in inventory)
            {
                if (b.title.ToLower() == t.ToLower()) 
                { 
                    b.showDetails(); 
                return; 
                }

            }
            Console.WriteLine("Not found.");
        }

        static void SearchByISBN()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            foreach (Book b in inventory)
            {
                if (b.ISBN == isbn) 
                {
                     b.showDetails();
                 return; 
                }
            }
            Console.WriteLine("Not found.");
        }

        static void UpdateStock()
        {
            Console.Write("Enter ISBN to update: ");
            string isbn = Console.ReadLine();
            foreach (Book b in inventory)
            {
                if (b.ISBN == isbn)
                {
                    Console.Write("Add(+) or Subtract(-) how many? ");
                    int change = int.Parse(Console.ReadLine());
                    b.stock += change;
                    Console.WriteLine("Stock Updated.");
                    return;
                }
            }
        }

        static void AddMember()
        {
            Console.Write("Member Name: ");
             string n = Console.ReadLine();
            Console.Write("Member ID (0 for Occasional): "); 
            int id = int.Parse(Console.ReadLine());
            members.Add(new Member(n, id));
            if (id > 0) 
            totalFeesCollected += 10; 
            Console.WriteLine("Member registered.");
        }

        static void SearchMember()
        {
            Console.Write("Enter ID to search: ");
            int id = int.Parse(Console.ReadLine());
            foreach (Member m in members)
            {
                if (m.memberID == id) 
                { 
                    Console.WriteLine("Found: " + m.name);
                 return; 
                }
            }
            Console.WriteLine("Member not found.");
        }

        static void UpdateMember()
        {
            Console.Write("Enter Member ID to update: ");
            int id = int.Parse(Console.ReadLine());
            foreach (Member m in members)
            {
                if (m.memberID == id)
                {
                    Console.Write("Enter new name: "); m.name = Console.ReadLine();
                    return;
                }
            }
        }

        static void PurchaseBook()
        {
            Console.Write("Enter Member ID (0 if non-member): ");
            int mID = int.Parse(Console.ReadLine());
            Console.Write("Enter Book ISBN to buy: ");
            string isbn = Console.ReadLine();

            Book selectedBook = null;
            foreach (Book b in inventory)
             { if (b.ISBN == isbn) 
             selectedBook = b; 
             }

            if (selectedBook != null && selectedBook.stock > 0)
            {
                Console.Write("Enter Quantity: ");
                int qty = int.Parse(Console.ReadLine());
                if (qty > selectedBook.stock)
                 { 
                    Console.WriteLine("Not enough stock!"); return;
                  }

                float priceToPay = selectedBook.price * qty;

               
                if (mID > 0)
                {
                    Member currentMember = null;
                    foreach (Member m in members) 
                    { if (m.memberID == mID)
                     currentMember = m;
                     }

                    if (currentMember != null)
                    {
                        priceToPay *= 0.95f; 
                        currentMember.booksCount += qty;

                       
                        if (currentMember.booksCount >= 11)
                        {
                            float discount = currentMember.totalSpentInCycle / 10;
                            priceToPay -= discount;
                            currentMember.totalSpentInCycle = 0; 
                            currentMember.booksCount = 0;
                            Console.WriteLine("11th Book Perk Applied! Discount: $" + discount);
                        }
                        else
                        {
                            currentMember.totalSpentInCycle += priceToPay;
                        }
                    }
                }

                selectedBook.stock -= qty;
                totalStoreSales += priceToPay;
                Console.WriteLine("Purchase Successful! Final Price: $" + priceToPay);
            }
            else { Console.WriteLine("Book not found or out of stock."); }
        }

        static void DisplayStats()
        {
            Console.WriteLine("--- STORE STATS ---");
            Console.WriteLine("Total Sales: $" + totalStoreSales);
            Console.WriteLine("Total Members: " + members.Count);
            Console.WriteLine("Total Membership Fees Collected: $" + totalFeesCollected);
        }
    }
}