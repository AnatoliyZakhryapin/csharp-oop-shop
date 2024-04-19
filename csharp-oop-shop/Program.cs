using System.Globalization;
using static csharp_oop_shop.Program;

namespace csharp_oop_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = {
                new Product("Pasta", "Scatola da 1 kg", 1.55m, 22),
                new Product("Olio", "Bottiglia da 1 litro", 10.99m, 22),
                new Product("Gelato", "Scatola da 0.5 kg", 5m, 22),
            };

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Seleziona opzione:");
                Console.WriteLine();
                Console.WriteLine("1. Voglio creare i prodotti per negozio");
                Console.WriteLine("2. Voglio guardare la lista dei prodotti del negozio");
                Console.WriteLine();
                Console.WriteLine("0. Esci");

                // Prendiamo l'input dell'utente
                Console.WriteLine();
                string input = Console.ReadLine();

                // Converte l'input in un numero intero
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 0:
                            // Uscita dal programma
                            return;
                        case 1:
                            CreateProductsList();
                            break;
                        case 2:
                            ShowProductsList(products);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input non valido. Riprova.");
                }
            }
        }

        public static void CreateProductsList()
        {
            Console.WriteLine();
            Console.WriteLine("Crea lista dei prodotti");
        }

        public static void ShowProductsList(Product[] products)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Stampa lista dei prodotti");

                foreach (Product product in products)
                {
                    product.PrintBaseInformation();
                    product.PrintPriceWithVat();
                    product.PrintNameExtended();
                    Console.WriteLine($"ProductCode padded: {product.GetPaddedProductCode()}");
                }

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Vuoi tornare al menu precedente? (S/N)");
                    Console.WriteLine();
                    string input = Console.ReadLine();

                    if (input.ToUpper() == "S")
                    {
                        return; // Ritorna al menu precedente
                    }
                    else if (input.ToUpper() == "N")
                    {
                        continue; // Continua a visualizzare la lista dei prodotti
                    }
                    else
                    {
                        Console.WriteLine("Input non valido. Riprova.");
                    }
                }
            }
        }

        public class Product
        {
            private int productCode;
            public string Name {  get; set; }
            public string Description { get; set; }

            public decimal price;

            private int vat;

            // -----------
            // Costruttore
            // -----------
            public Product()
            {
                Random rnd = new Random();
                this.productCode = rnd.Next(1000);
                this.Vat = 22;
            }
            public Product(string name, string desctiption, decimal price, int vat)
            {
                Random rnd = new Random();
                this.productCode = rnd.Next(1000);
                this.Name = name;
                this.Description = desctiption;
                this.price = Math.Abs(price);
                this.Vat = vat;
            }

            // ---------
            // Get e Set
            // ----------
            public int ProductCode
            {
                get { return productCode; }
            }

            public decimal Price
            {
                get { return price; }
                set { price = Math.Abs(value); }
            }

            public int Vat
            {
                get { return vat; }
                set { vat = SetVat(value); }
            }

            // --------
            // Funzioni
            // --------

            public void PrintBaseInformation()
            {
                Console.WriteLine();
                Console.WriteLine(this.GetType().Name);
                Console.WriteLine($"Code: {ProductCode}");
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Description: {Description}");
                Console.WriteLine($"Price: {Price} euro");
                Console.WriteLine($"Vat: {Vat} %");
            }
            
            public void PrintPriceWithVat()
            {
                Console.WriteLine($"Price with vat: {GetPriceWithVat()} euro");      
            }

            public void PrintNameExtended()
            {
                Console.WriteLine($"Name extended: {GetNameExtended()}");
            }

            public decimal GetPriceWithVat()
            {
                decimal result = (this.price * ((decimal)this.Vat / 100)) + this.price;

                return decimal.Parse(result.ToString("0.00"));
            }

            public string GetNameExtended()
            {
                string result = this.productCode + this.Name;

                return result;
            }

            private int SetVat(int vat)
            {
                if (Math.Abs(vat) > 0 && Math.Abs(vat) < 100)
                {
                    return Math.Abs(vat);
                }
                else
                {
                    Console.WriteLine("Vat non è corretto");
                    return 0;
                }
            }

            public string GetPaddedProductCode()
            {
                string paddedCode = this.productCode.ToString().PadLeft(8, '0');

                return paddedCode;
            }
        }
    }
}
