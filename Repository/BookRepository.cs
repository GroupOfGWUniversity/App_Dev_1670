using App_Dev_1670.Data;
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;

namespace App_Dev_1670.Repository
{
    public class BookRepository : Repository<Book>, IBook

    {
        private readonly ApplicationDatabase _db;
        public BookRepository(ApplicationDatabase db) : base(db)
        {
            _db = db;
        }
        public void Update(Book book)
        {
            _db.Update(book);
        }
    }
}
