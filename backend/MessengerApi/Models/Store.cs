using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.Models
{
    public class Store : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }

        public Store(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}