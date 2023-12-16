using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace App_Dev_1670.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperty  = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperty = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
    }
}