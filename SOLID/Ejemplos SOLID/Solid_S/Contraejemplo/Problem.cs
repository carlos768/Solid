namespace Single_responsibility_principle
{
    class Program
    {
        //La clase Product se encarga de la información del producto y también de tareas en la base de datos
        public class Product
        {
            public string Name { get; set; }

            public Product(string Name)
            {
                this.Name = Name;
            }

            public void SaveProductDB()
            {
                Console.WriteLine($"{ Name } stored in database");
            }

            public void DeleteProductDB()
            {
                Console.WriteLine($"Deleting {Name}");
            }
        }

        static void Main(string[] args)
        {
            Product product = new Product("Apple");
            product.SaveProductDB();
        }
    }
}