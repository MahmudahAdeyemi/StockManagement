using file.Entities;

namespace file.RequestModel
{
    public class ProductRequestModel
    {
        public string Name {get; set;}
        public double QuantityAvailable {get; set;}
        public string Description {get; set;}
        public Measurement UnitOfMeasurement{get; set;}
        public double Price {get; set;}
    }
}