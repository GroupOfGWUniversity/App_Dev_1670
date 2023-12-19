using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUser

    {
        private ApplicationDatabase _db;
        public ApplicationUserRepository(ApplicationDatabase db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser)
        {
            _db.Update(applicationUser);
        }
    }
}
