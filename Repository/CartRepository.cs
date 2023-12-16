using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class CartRepository : Repository<Cart>, ICart

    {
        private ApplicationDatabase _db;
        public CartRepository(ApplicationDatabase db) : base(db)
        {
            _db = db;
        }
        public void Update(Cart Cart)
        {
            _db.Update(Cart);
        }
    }
}
