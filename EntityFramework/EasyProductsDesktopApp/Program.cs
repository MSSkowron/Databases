using System;
using System.Threading;

namespace MateuszSkowronEFProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("---------- PRODUKTY ----------");
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Wyswietl produkty");
            Console.WriteLine("3. Zakoncz");

            int check = Int32.Parse(Console.ReadLine());
            if(check == 1)
            {
                Console.Clear();
                Console.WriteLine("Podaj nazwe produktu");
                string prodName = Console.ReadLine();
                Console.WriteLine("Podaj ilosc");
                int prodUnitsOnStock = Int32.Parse(Console.ReadLine());
                ProductContext productContext = new ProductContext();
                Product product = new() { ProductName = prodName, UnitsOnStock = prodUnitsOnStock };
                productContext.Products.Add(product);
                productContext.SaveChanges();

                Console.Clear();
                Console.WriteLine("Pomyslnie zapisano produkt ", prodName, " w ilosci ", prodUnitsOnStock, ".");
                Thread.Sleep(2000);
                Main(args);
            }
            else if(check == 2)
            {
                Console.Clear();
                Console.WriteLine("Poniżej lista produktow zarejestrowanych w naszej bazie danych");
                ProductContext productContext = new ProductContext();
                var query = from prod in productContext.Products select prod.ProductName;
               
                foreach (var pName in query)
                {
                    Console.WriteLine(pName);
                }
                Console.WriteLine("");
                Console.WriteLine("Nacisnij ENTER aby zakonczyc");
                string any = Console.ReadLine();
                Main(args);
            }
            else if(check == 3)
            {
                Console.Clear();
                Console.WriteLine("Bye Bye!");    
                Thread.Sleep(2000);
                return;
            }
            else
            {
                Console.WriteLine("Wrong option!");
                Thread.Sleep(2000);
                Main(args);
            }
          
        }
    }
}