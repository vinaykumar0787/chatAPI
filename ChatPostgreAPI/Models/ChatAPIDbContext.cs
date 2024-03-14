using Microsoft.EntityFrameworkCore;
using System;

namespace ChatPostgreAPI.Models
{
    public class ChatAPIDbContext : DbContext
    {
        public ChatAPIDbContext(DbContextOptions<ChatAPIDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
