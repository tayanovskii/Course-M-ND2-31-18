using System;
using StudentNewsSite.DAL.Entities;

namespace StudentNewsSite.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Comment> Comments { get; }
        IRepository<Post> Posts { get; }
        IRepository<Student> Students { get; }
        IRepository<Tag> Tags { get; }
        void Save();
    }
}