namespace file.Entities
{
    public class Product
    {
        public int Id{get; set;}
        public string Name {get; set;}
        public double QuantityAvailable {get; set;}
        public string Description {get; set;}
        public bool IsDeleted {get; set;}
        public Measurement UnitOfMeasurement{get; set;}
        public double CostPrice {get; set;}
        public double SellingPrice {get; set;}

    }

    public enum Measurement{
        Kg,
        Litre
    }
}