namespace Single_responsibility_principle
{
    class Program
    {
        // La clase Product se encarga sólo de darle nombre al producto
        public class Product
        {
            public string Name { get; set; }

            public Product(string Name)
            {
                this.Name = Name;
            }
        }

        // Se separa la lógica de la base de datos en otra clase
        public class ProductDB
        {
            private Product _product;
            public ProductDB(Product product)
            {
                _product = product;
            }
            public void SaveDB(Product product)
            {
                Console.WriteLine($"{ _product.Name } stored in database");
            }

            public void DeleteProductDB(Product product)
            {
                Console.WriteLine($"Deleting { _product.Name }");
            }
    }

        static void Main(string[] args)
        {
            Product product = new Product("Apple");
            ProductDB productDB = new ProductDB(product);
            productDB.SaveDB(product);
        }
    }
}