using AgendaDeContatos.EntityFramework.Configurations;
using AgendaDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatos.EntityFramework.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> dbOptions) : base(dbOptions) {}

        public DbSet<ContactModel> TblContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TblContactsEFConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
