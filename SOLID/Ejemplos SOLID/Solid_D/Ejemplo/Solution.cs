class Program
{
    public static void Main(string[] args)
    {
        
    }

    public interface IPersistence
    {
        public void Save();
    }

    public interface IPaymentMethod
    {
        public void Pay();
    }

    class Shopping {
        // Información del producto
    }
    class ShoppingBasket
    {
        readonly IPersistence _persistence;
        readonly IPaymentMethod _paymenthMethod;
        public ShoppingBasket(IPersistence persistence, IPaymentMethod paymentMethod)
        {
            _persistence = persistence;
            _paymenthMethod = paymentMethod;
        }
        public void Buy(Shopping shopping)
        {
            _persistence.Save();
            _paymenthMethod.Pay();
        }
    }
    class SqlDatabase : IPersistence
    {
        public void Save()
        {
            Console.WriteLine("Datos guardados en la base de datos");
        }
    }
    class CreditCard : IPaymentMethod
    {
        public void Pay()
        {
            Console.WriteLine("Se pagó usando tarjeta de credito");
        }
    }
    // No dependemos del modulo de alto nivel para cambiar la forma de pago o almacenamiento
    class Server : IPersistence
    {
        public void Save()
        {
            Console.WriteLine("Datos guardados en el servidor");
        }
    }
    class Paypal : IPaymentMethod
    {
        public void Pay()
        {
            Console.WriteLine("Se pagó usando Paypal");
        }
    }
}
