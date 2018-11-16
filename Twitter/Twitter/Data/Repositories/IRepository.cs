using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Twitter.Data.Entities;
using Twitter.Models;

namespace Twitter.Data.Repositories
{
        public interface IRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<IEnumerable<T>> GetLastAsync(int count);
        Task<T> GetByIdAsync(int id);
            Task CreateAsync(T item);
            Task UpdateAsync(T item);
            Task DeleteAsync(int id);
            Task<IEnumerable<T>> Find(Expression<Func<Post, bool>> predicate);
            void Dispose();
        }
}