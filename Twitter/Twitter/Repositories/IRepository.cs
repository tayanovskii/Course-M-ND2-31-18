using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Repositories
{
        public interface IRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task CreateAsync(T item);
            Task UpdateAsync(T item);
            Task DeleteAsync(int id);
            Task<IEnumerable<T>> Find(Expression<Func<Post, bool>> predicate);
    }
}