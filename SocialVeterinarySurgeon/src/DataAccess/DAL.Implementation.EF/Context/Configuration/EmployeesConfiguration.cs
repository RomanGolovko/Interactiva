using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DAL.Implementation.EF.Context.Configuration
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees").HasKey(x => x.Id);
            //builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("INT").IsRequired(true);
            //builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("NVARCHAR").HasMaxLength(50);
            //builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("NVARCHAR").HasMaxLength(50);
            //builder.Property(x => x.MediaInteractivaEmployee).HasColumnName("MediaInteractivaEmployee");

            //builder.HasOne(x => x.Pet).WithOne(x => x.Owner).HasForeignKey<Pet>(e => e.OwnerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
