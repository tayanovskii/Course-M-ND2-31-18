using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;
using StudentNewsSite.DAL.Contexts;

namespace StudentNewsSite.Data.Repositories
{
    public class CommentRepository:IRepository<Comment>
    {
        private readonly StudentNewsSiteContext dbContext;

        public CommentRepository(StudentNewsSiteContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Comment> GetAll()
        {
            return dbContext.Comments;
        }
        public Comment Get(int id)
        {
            return dbContext.Comments.Find(id);
        }
        public void Create(Comment item)
        {
            dbContext.Comments.Add(item);
        }
        public void Update(Comment item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var deleteComment = dbContext.Comments.Find(id);
            if (deleteComment != null) dbContext.Comments.Remove(deleteComment);
        }
        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return dbContext.Comments.Where(predicate);
        }
    }
}