class Program
{
    public abstract class Cellphone
    {
        protected string model;
        protected int price;
        protected short year;

        public abstract void MakeCall();

    }

    public abstract class CellphoneWithFingerprintSensor : Cellphone
    {
        public abstract void UnlockByFingerprint();
    }

    public class Samsung : CellphoneWithFingerprintSensor
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

        public override void MakeCall()
        {
            Console.WriteLine("Hacer llamada telefónica");
        }
    }
    public static void Main(string[] args)
    {
        CellphoneWithFingerprintSensor samsungCellphone = new Samsung("Galaxy J7 Prime", 100000, 2016);
        samsungCellphone.MakeCall();
        samsungCellphone.UnlockByFingerprint();


        Cellphone blackberryCellphone = new BlackBerry("Blackberry Storm 9500", 120000, 2008);
        blackberryCellphone.MakeCall();
    }
}