using App_Dev_1670.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Repository.IRepository
{
    public interface ICategory : IRepository<Category>
    {
        void Update(Category category);
    }
}