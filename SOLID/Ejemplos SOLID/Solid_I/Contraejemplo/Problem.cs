class Program
{
    public static void Main(string[] args)
    {

    }
}
public interface IProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string ExpirationDate { get; set; } 
    public decimal Tax { get; set; }

}

public class Dairy : IProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string ExpirationDate { get; set; }
    public decimal Tax { get; set; }

    public Dairy(string Name, string Description, int Price, string ExpirationDate, decimal Tax)
    {
        this.Name = Name;
        this.Description = Description; 
        this.Price = Price; 
        this.ExpirationDate = ExpirationDate;   
        this.Tax = Tax;
    }
}

// La clase no necesita todas las propiedades de la interfaz
public class Appliance : IProduct
{
    public string Name { get; set ; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string ExpirationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public decimal Tax { get; set; }

    public Appliance(string Name, string Description, int Price, string ExpirationDate, decimal Tax)
    {
        this.Name = Name;
        this.Description = Description;
        this.Price = Price;
        this.ExpirationDate = ExpirationDate;
        this.Tax = Tax;
    }
}