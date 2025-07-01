using Microsoft.EntityFrameworkCore;
using WepApp2.Models; // تأكد من وجود using للـ namespace الخاص بالموديلات

namespace WepApp2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
