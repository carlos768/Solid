class Program
{
    public abstract class Cellphone
    {
        protected string model;
        protected int price;
        protected short year;

        public abstract void UnlockByFingerprint();
        public abstract void MakeCall();

    }

    public class Samsung : Cellphone
    {
        public Samsung(string model, int price, short year)
        {
            this.model = model;
            this.price = price;
            this.year = year;
        }

        public override void UnlockByFingerprint()
        {
            Console.WriteLine("Desbloqueado por huella dactilar");
        }

        public override void MakeCall()
        {
            Console.WriteLine("Hacer llamada telefónica");
        }
    }

    public class BlackBerry : Cellphone
    {
        public BlackBerry(string model, int price, short year)
        {
            this.model = model;
            this.price = price;
            this.year = year;
        }

        public override void UnlockByFingerprint()
        {
            throw new NotImplementedException();
        }

        public override void MakeCall()
        {
            Console.WriteLine("Hacer llamada telefónica");
        }
    }
    public static void Main(string[] args)
    {
        Cellphone samsungCellphone = new Samsung("Galaxy J7 Prime", 100000, 2016);
        samsungCellphone.MakeCall();
        samsungCellphone.UnlockByFingerprint();

        // Esta clase no puede hacer lo mismo que su clase padre, por lo que no puede reemplazarla
        Cellphone blackberryCellphone = new BlackBerry("Blackberry Storm 9500", 120000, 2008);
        blackberryCellphone.MakeCall();
        blackberryCellphone.UnlockByFingerprint(); // Error
    }
}