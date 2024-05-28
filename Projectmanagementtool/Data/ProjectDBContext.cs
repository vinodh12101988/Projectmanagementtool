using Microsoft.EntityFrameworkCore;
using Projectmanagementtool.Models;
namespace Projectmanagementtool.Data
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions options): base(options) { }

        public DbSet<Products> ProductList { get; set; }
    }
}
