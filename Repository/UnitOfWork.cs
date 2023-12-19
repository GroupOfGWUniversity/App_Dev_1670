using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDatabase _db;
        public IBook Book { get; set; }
        public ICategory Category { get; set; }
         public ICart Cart { get; set; }
        public IApplicationUser ApplicationUser { get; set; }  
        public IRequest Request { get; set; }

        public IOrder Order { get; set; }
        public IOrderDetails OrderDetails { get; set; }
        public UnitOfWork(ApplicationDatabase db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            Book = new BookRepository(_db);
            Category = new CategoryRepository(_db);
            Cart = new CartRepository(_db);
            Request = new RequestCategoryRepository(_db);
            Order = new OrderRepository(_db);
            OrderDetails = new OrderDetailsRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}