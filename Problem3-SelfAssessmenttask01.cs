using System;
using System.Collections.Generic;

namespace Lab4_Task01
{
    
    class Product
    {
        public string name;
        public string category;
        public int price;

        public float calculateTax()
        {
          
            return price * 0.1f;
        }
    }

       class Customer
    {
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerContact;
        
       
        public List<Product> products = new List<Product>();

        public void addProduct(Product p)
        {
            products.Add(p);
        }

        public List<Product> getAllProducts()
        {
            return products;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Customer myCustomer = new Customer();
            myCustomer.CustomerName = "Zahid";
            myCustomer.CustomerAddress = "UET Lahore";
            myCustomer.CustomerContact = "0321-0000000";

            
            Product item1 = new Product();
            item1.name = "Programming Book";
            item1.category = "Education";
            item1.price = 1500;

          
            Product item2 = new Product();
            item2.name = "Scientific Calculator";
            item2.category = "Stationery";
            item2.price = 3000;

            myCustomer.addProduct(item1);
            myCustomer.addProduct(item2);

           
            List<Product> purchasedItems = myCustomer.getAllProducts();

            Console.WriteLine("Customer Name: " + myCustomer.CustomerName);
            Console.WriteLine("--- Purchased Items ---");

            foreach (Product p in purchasedItems)
            {
                Console.WriteLine("Product: " + p.name + " | Price: " + p.price + " | Tax: " + p.calculateTax());
            }

            Console.ReadKey();
        }
    }
}