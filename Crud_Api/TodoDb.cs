using System;
using Microsoft.EntityFrameworkCore;
namespace Crud_Api
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
    }
}
