using App_Dev_1670.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_Dev_1670.Repository.IRepository
{
    public interface IRequest : IRepository<RequestCategory>
    {
        void Update(RequestCategory requestCategory);
    }
}