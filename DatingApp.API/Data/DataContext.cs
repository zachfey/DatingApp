using DatingApp.API.models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        
        //Values represents the table name in the database
        public DbSet<Value> Values { get; set; }

        public DbSet<User> Users { get; set; }
    }
}