using AgendaDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.ConstrainedExecution;

namespace AgendaDeContatos.EntityFramework.Configurations
{
    public class TblContactsEFConfiguration : IEntityTypeConfiguration<ContactModel>
    {


        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.Email)
                .IsRequired();
            builder.Property(x => x.Phone)
                .IsRequired();
            builder.Property(x => x.CEP);
            builder.Property(x => x.Address)
                .IsRequired();
            builder.Property(x => x.Number);
            builder.Property(x => x.Complement);
            builder.Property(x => x.Region);
            builder.Property(x => x.City);
            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}
