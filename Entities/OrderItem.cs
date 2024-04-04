namespace file.Entities
{
    public class OrderItem
    {
        public int Id{get; set;}
        public int ProductId{get; set;}
        public double Quantity {get; set;}
        public double UnitPrice {get; set;}
        public double Vat {get; set;}
        public double TotalVat => UnitPrice * Vat/100D * Quantity;
        
        public double TotalPrice => Quantity * UnitPrice + TotalVat;
    }
}