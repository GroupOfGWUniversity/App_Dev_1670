using App_Dev_1670.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Repository.IRepository
{
    public interface IBook : IRepository<Book>
    {
        void Update(Book book);
    }
}