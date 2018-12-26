using System.Linq;
using JWT.API.Data;
using JWT.API.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace JWT.API.Hubs
{
    public class PostHub : Hub
    {
        private readonly PostContext _context;
        public PostHub(PostContext context)
        {
            _context = context;
        }
        public void createPost(string content)
        {
            var newPost = new Post
            {
                Content = content
            };
            _context.Post.Add(newPost);
            _context.SaveChangesAsync();
        }
    }
}
