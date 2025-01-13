using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SqlFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(SqlUtility.ConnectionString);
        }

        public static List<T> GetSqlResults<T>(string query) where T : class, new()
        {
            List<T> lst = new();
            using (var c = new AppDbContext())
            {
                lst = c.Set<T>().FromSqlRaw(query).ToList();
            }
            return lst;
        }
    }
}
