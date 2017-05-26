using ContactsManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions options) : base(options) { }

        public DbSet<ContactCompany> Companies { get; set; }
        public DbSet<ContactPerson> Persons { get; set; }
    }
}