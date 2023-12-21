using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetails

    {
        private ApplicationDatabase _db;
        public OrderDetailsRepository(ApplicationDatabase db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderDetails orderDetails )
        {
            _db.Update(orderDetails);
        }
    }
}
