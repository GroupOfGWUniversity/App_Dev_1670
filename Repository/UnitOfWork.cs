using App_Dev_1670.Data;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDatabase _db;
        public IBook Book { get; set; }
        public ICategory Category { get; set; }
        // public ISeller Seller { get; set; }
        public UnitOfWork(ApplicationDatabase db)
        {
            _db = db;
            Book = new BookRepository(_db);
            Category = new CategoryRepository(_db);
            //    Seller = new SellerRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}