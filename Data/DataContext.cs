using Microsoft.EntityFrameworkCore;
using crudapi.Models;

namespace crudapi.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 


        }
        public DbSet<Producto>? Productos{ get;set; } 
    }
}