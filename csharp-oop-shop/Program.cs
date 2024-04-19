namespace csharp_oop_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public class Product
        {
            private int productCode;
            public string Name {  get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Vat { get; set; }

            // Costruttore
            public Product()
            {
                Random rnd = new Random();
                this.productCode = rnd.Next(1000);
            }

            // Get e Set
            public int ProductCode
            {
                get { return productCode; }
            }

        }
    }
}
