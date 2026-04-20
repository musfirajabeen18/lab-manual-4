using System;
using System.Collections.Generic;

namespace BookstoreSystem
{
    class Member
    {
       
        public string name;
        public int memberID;
        public List<Book> booksBought;
        public int numberOfBooksBought;
        public float moneyInBank;
        public float amountSpent;

      
        public Member()
        {
            name = "Unknown";
            memberID = 0;
            booksBought = new List<Book>();
            numberOfBooksBought = 0;
            moneyInBank = 0.0f;
            amountSpent = 0.0f;
        }

        public Member(string n, int id, float balance) 
        {
            name = n;
            memberID = id;
            moneyInBank = balance;
            booksBought = new List<Book>();
            numberOfBooksBought = 0;
            amountSpent = 0.0f;
        }

       
        public void setName(string n) { name = n; }
        public string getName() { return name; }
        public void showName() { Console.WriteLine("Member Name: " + name); }

        
        public void setMemberID(int id) { memberID = id; }
        public int getMemberID() { return memberID; }

        
        public void setMoneyInBank(float amount) { moneyInBank = amount; }
        public void showFinancials() 
        { 
            Console.WriteLine("Balance: $" + moneyInBank);
            Console.WriteLine("Total Amount Spent: $" + amountSpent);
        }

                public void buyBook(Book b)
        {
            if (moneyInBank >= b.price)
            {
                booksBought.Add(b);
                numberOfBooksBought++;
                amountSpent += b.price;
                moneyInBank -= b.price;
                Console.WriteLine("Book purchased successfully!");
            }
            else
            {
                Console.WriteLine("Insufficient funds in bank!");
            }
        }

        public void showPurchaseStats()
        {
            Console.WriteLine("Total Books Bought: " + numberOfBooksBought);
            Console.WriteLine("Total Spent: $" + amountSpent);
        }

        public void showAllDetails()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("ID: " + memberID);
            showName();
            showFinancials();
            showPurchaseStats();
            Console.WriteLine("-----------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Member currentMember = new Member();
            int choice = 0;

            while (choice != 5)
            {
                Console.WriteLine("\n--- MEMBER MANAGEMENT MENU ---");
                Console.WriteLine("1. Set/Modify Member Info");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Show Member Details");
                Console.WriteLine("4. Simulate Purchase (requires existing book)");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter Name: ");
                    currentMember.setName(Console.ReadLine());
                    Console.Write("Enter Member ID: ");
                    currentMember.setMemberID(int.Parse(Console.ReadLine()));
                }
                else if (choice == 2)
                {
                    Console.Write("Enter amount to deposit: ");
                    float deposit = float.Parse(Console.ReadLine());
                    currentMember.setMoneyInBank(currentMember.moneyInBank + deposit);
                }
                else if (choice == 3)
                {
                    currentMember.showAllDetails();
                }
                else if (choice == 4)
                {
                    
                    Book tempBook = new Book();
                    tempBook.title = "Sample Book";
                    tempBook.price = 50.0f;
                    
                    Console.WriteLine("Buying 'Sample Book' for $50.00...");
                    currentMember.buyBook(tempBook);
                }
            }
        }
    }
}