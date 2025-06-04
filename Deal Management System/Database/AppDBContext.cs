using Deal_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Deal_Management_System.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options):DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
