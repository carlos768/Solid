class Program
{
    public static void Main(string[] args)
    {

    }

    class Shopping {
        // Información del producto
    }
    // Clase de alto nivel (ShoppingBasket) depende de clases de bajo nivel
    class ShoppingBasket
    {
        public void Buy(Shopping shopping)
        {
            SqlDatabase db = new SqlDatabase();
            db.Save(shopping);
            CreditCard creditCard = new CreditCard();
            creditCard.Pay(shopping);
        }
    }
    class SqlDatabase
    {
        public void Save(Shopping shopping)
        {
            Console.WriteLine("Datos guardados en la base de datos");
        }
    }
    class CreditCard
    {
        public void Pay(Shopping shopping)
        {
            Console.WriteLine("Se pagó usando tarjeta de credito");
        }
    }

    // Para cambiar el metodo de pago o base de datos, se tendría que modificar toda la la logica de ShoppingBasket 
}
