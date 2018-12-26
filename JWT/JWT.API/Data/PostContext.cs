using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JWT.API.Models;

namespace JWT.API.Data
{
    public class PostContext : DbContext
    {
        public PostContext (DbContextOptions<PostContext> options)
            : base(options)
        {
        }

        public DbSet<JWT.API.Models.Post> Post { get; set; }
    }
}
