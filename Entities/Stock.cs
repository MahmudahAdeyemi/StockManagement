namespace file.Entities
{
    public class Stock
    {       
        public int Id{get; set;}
        public DateTime Date {get; set;}
        public int ProductId {get; set;}
        public int Quantity{get; set;}
        public double CostPrice{get; set;}
    }
}