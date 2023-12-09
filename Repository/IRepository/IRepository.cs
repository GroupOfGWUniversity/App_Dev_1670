using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace App_Dev_1670.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? incluProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? incluProperties = null);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}
