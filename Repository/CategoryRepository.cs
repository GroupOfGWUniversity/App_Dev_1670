using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class CategoryRepository : Repository<Category>, ICategory
    {
        public ApplicationDatabase _db;
        public CategoryRepository(ApplicationDatabase db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
