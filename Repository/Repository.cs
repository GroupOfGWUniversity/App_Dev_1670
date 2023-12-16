using App_Dev_1670.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using App_Dev_1670.Data;
using App_Dev_1670.Models.ViewModels;

namespace App_Dev_1670.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDatabase _dbContext;
        internal DbSet<T> dbSet { get; set; }
        public Repository(ApplicationDatabase dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
            _dbContext.Books.Include(u => u.Category).Include(u => u.CategoryID);
            _dbContext.Books.Include(u => u.Seller).Include(u => u.SellerID);

        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperty = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
              query = dbSet;
              
            }
            else
            {
               query = dbSet.AsNoTracking();
                

            }
            
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var includeProp in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

    }
}
