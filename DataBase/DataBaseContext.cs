using AgendaDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatos.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> dbOptions) : base(dbOptions)
        {

        }

        public DbSet<ContactModel> TblContacts { get; set; }  
    }
}
