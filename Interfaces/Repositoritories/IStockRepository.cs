using file.Entities;

namespace file.Interfaces.Repositoritories
{
    public interface IStockRepository
    {
         void Add(Stock stock);
        void SaveStocks(List<Stock> stocks);
        public void Delete(int stockId);
        List<Stock>? GetAllStocks();
        Stock GetStock(int id);
    }
}