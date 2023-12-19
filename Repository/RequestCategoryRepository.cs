using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class RequestCategoryRepository : Repository<RequestCategory>, IRequest
    {
        private ApplicationDatabase _db;
        public RequestCategoryRepository(ApplicationDatabase db) : base(db)
        {
            _db = db;
        }
        public void Update(RequestCategory requestCategory)
        {
            _db.Update(requestCategory);
        }
    }
}
