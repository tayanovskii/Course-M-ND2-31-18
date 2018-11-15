using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Repositories
{
    public class PostRepository : IRepository<Post>
    {

        private readonly ApplicationDbContext dbContext;

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            using (dbContext)
            {
                return await dbContext.Posts.ToListAsync();
            }
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            using (dbContext)
            {
                return await dbContext.Posts.FirstOrDefaultAsync(post => post.Id == id);
            }
        }

        public async Task CreateAsync(Post item)
        {
            using (dbContext)
            {
                await dbContext.Posts.AddAsync(item);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Post item)
        {
            using (dbContext)
            {
                dbContext.Attach(item);
                dbContext.Entry(item).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (dbContext)
            {
                var post = new Post() { Id = id };
                dbContext.Posts.Attach(post);
                dbContext.Entry(post).State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> Find(Expression<Func<Post, bool>> predicate)
        {
            using (dbContext)
            {
                return await dbContext.Posts.Where(predicate).ToListAsync();
            }
        }
    }

}