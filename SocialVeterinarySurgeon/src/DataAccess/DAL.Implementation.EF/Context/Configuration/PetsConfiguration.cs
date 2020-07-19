using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DAL.Implementation.EF.Context.Configuration
{
    public class PetsConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets").HasKey(x => x.Id);
            //builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("INT").IsRequired(true);
            //builder.Property(x => x.OwnerId).HasColumnName("OwnerId").HasColumnType("INT").IsRequired(true);
            //builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("NVARCHAR").HasMaxLength(50);
            //builder.Property(x => x.Type).HasColumnName("Type").HasColumnType("NVARCHAR").HasMaxLength(50);
        }
    }
}
