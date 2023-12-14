using App_Dev_1670.Data;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDatabase _db;
        public IBook Book { get; set; }
        public ICategory Category { get; set; }
<<<<<<< HEAD
        public ISeller Seller { get; set; }
=======
        // public ISeller Seller { get; set; }
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621
        public UnitOfWork(ApplicationDatabase db)
        {
            _db = db;
            Book = new BookRepository(_db);
            Category = new CategoryRepository(_db);
<<<<<<< HEAD
            Seller = new SellerRepository(_db);
=======
            //    Seller = new SellerRepository(_db);
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}