using System.Collections.Generic;

namespace SalesApp
{
    public interface IDatabaseService
    {
        void SaveData(Sale sale);
        List<Sale> GetAllData();
    }

    public class DatabaseService : IDatabaseService
    {
        private readonly SalesDbContext _context;

        public DatabaseService(SalesDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void SaveData(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public List<Sale> GetAllData()
        {
            return _context.Sales.ToList();
        }
    }
}
