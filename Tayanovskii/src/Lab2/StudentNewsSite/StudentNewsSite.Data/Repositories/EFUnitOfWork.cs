using System;
using StudentNewsSite.Data.EF;
using StudentNewsSite.Data.Entities;
using StudentNewsSite.Data.Interfaces;

namespace StudentNewsSite.Data.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private  StudentNewsSiteContext dbContext;
        private CommentRepository commentRepository;
        private PostRepository postRepository;
        private StudentRepository studentRepository;
        private TagRepository tagRepository;

        public EFUnitOfWork( )
        {
            dbContext = new StudentNewsSiteContext();
        }

        public IRepository<Comment> Comments => commentRepository ?? (commentRepository = new CommentRepository(dbContext));
        public IRepository<Post> Posts => postRepository ?? (postRepository = new PostRepository(dbContext));
        public IRepository<Student> Students => studentRepository ?? (studentRepository = new StudentRepository(dbContext));
        public IRepository<Tag> Tags => tagRepository ?? (tagRepository = new TagRepository(dbContext));
        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}