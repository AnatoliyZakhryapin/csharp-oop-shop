using static csharp_oop_shop.Program;

namespace csharp_oop_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Product product1 = new Product();
            product1.Name = "Banana";
            product1.Description = "Una fruta";
            product1.Price = -100.00M;


            product1.PrintBaseInformation();
            product1.PrintPriceWithVat();
            product1.PrintNameExtended();

            Product product2 = new Product("Mela", "Una frutta", -200M, 10);

            product2.PrintBaseInformation();
            product2.PrintPriceWithVat();
            product2.PrintNameExtended();

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

            public decimal GetPriceWithVat()
            {
                decimal result = (this.price * ((decimal)this.Vat / 100 )) + this.price;

                return decimal.Parse(result.ToString("0.00"));
            }

            public string GetNameExtended()
            {
                string result = this.productCode + this.Name;

                return result;
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
        }
    }
}
