using Magazin.Business;
using Magazin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Presentation
{
    public class Application
    {
        private void ShowConsoleOptions()
        {
            Console.WriteLine(new string('-',40));
            Console.WriteLine(new string(' ',16)+"Options"+new string(' ',16));
            Console.WriteLine("1. Show all products.");
            Console.WriteLine("2. Show a product by certain ID.");
            Console.WriteLine("3. Add new product.");
            Console.WriteLine("4. Update a product by certain ID.");
            Console.WriteLine("5. Delete a product by certain ID.");
            Console.WriteLine("6. Close application.");
        }
        public void ConsoleApp()
        {
            int option = -1;
            do
            {
                ShowConsoleOptions();
                Console.WriteLine(new string(' ', 40));
                Console.Write("Choose an option from above by writing a number:");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1: DisplayAll(); break;
                    case 2: ShowOneProduct(); break;
                    case 3: Add(); break;
                    case 4: Update(); break;
                    case 5: Delete(); break;
                    default: break;
                }
            }
            while (option!=6);
        }
        private void DisplayAll()
        {
            ProductCommands command=new ProductCommands();
            command.ShowAll();
        }
        private void ShowOneProduct()
        {
            ProductCommands command=new ProductCommands();
            Console.Write("Enter product ID:");
            int id=int.Parse(Console.ReadLine());
            Product product=command.ShowCertainProduct(id);
            Console.WriteLine("Name:"+product.Name);
            Console.WriteLine("Price:"+product.Price);
            Console.WriteLine("Stock:"+product.Stock);
        }
        private void Add()
        {
            Product product=new Product();
            Console.WriteLine("Enter ID:");
            product.ID=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name:");
            product.Name=Console.ReadLine();
            Console.WriteLine("Enter price:");
            product.Price=decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount:");
            product.Stock=int.Parse(Console.ReadLine());
            ProductCommands newProduct=new ProductCommands();
            newProduct.Add(product);
        }
        private void Update()
        {
            ProductCommands command= new ProductCommands();
            Console.Write("Enter product ID:");
            int id=int.Parse(Console.ReadLine());
            Product product = command.ShowCertainProduct(id);
            if (product!=null)
            {
                Product newProduct=new Product();
                newProduct.ID=product.ID;
                Console.Write("Enter new product name:");
                newProduct.Name=Console.ReadLine();
                Console.Write("Enter new product price:");
                newProduct.Price=decimal.Parse(Console.ReadLine());
                Console.Write("Enter new amount of product:");
                newProduct.Stock=int.Parse(Console.ReadLine());
                command.Update(newProduct);
            }
            else Console.WriteLine("Product does not exist.");
        }
        private void Delete()
        {
            ProductCommands command= new ProductCommands();
            Console.WriteLine("Enter product ID:");
            int id= int.Parse(Console.ReadLine());
            command.Delete(id);
            Console.WriteLine("Action has been completed succesfully.");
        }
        public Application()
        {
            ConsoleApp();
        }
    }
}
