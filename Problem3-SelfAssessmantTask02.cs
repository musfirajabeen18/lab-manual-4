using System;
using System.Collections.Generic;

namespace Lab4_Task02
{
    class Product
    {
        public string name;
        public int price;

               public float calculateTax()
        {
            return price * 0.1f;
        }
    }

    class Customer
    {
        public string CustomerName;
        public List<Product> products = new List<Product>();

        public void addProduct(Product p)
        {
            products.Add(p);
        }

       
        public float calculateTotalTaxOfPurchases()
        {
            float totalTaxAmount = 0;

            
            foreach (Product p in products)
            {
             
                totalTaxAmount = totalTaxAmount + p.calculateTax();
            }

            return totalTaxAmount;
        }
    
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Customer myCustomer = new Customer();
            myCustomer.CustomerName = "Hamza";

            Product p1 = new Product();
            p1.name = "Keyboard";
            p1.price = 2000;

            Product p2 = new Product();
            p2.name = "Monitor";
            p2.price = 15000;

           
            myCustomer.addProduct(p1);
            myCustomer.addProduct(p2);

           
            float resultTax = myCustomer.calculateTotalTaxOfPurchases();

            Console.WriteLine("Customer Name: " + myCustomer.CustomerName);
            Console.WriteLine("Total Items: " + myCustomer.products.Count);
            Console.WriteLine("Total Tax for all purchased items: " + resultTax);

            Console.ReadKey();
        }
    }
}