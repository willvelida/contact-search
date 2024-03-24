using ContactSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSearch.Persistence
{
    public class ContactSearchDbContext : DbContext
    {
        public ContactSearchDbContext(DbContextOptions<ContactSearchDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
