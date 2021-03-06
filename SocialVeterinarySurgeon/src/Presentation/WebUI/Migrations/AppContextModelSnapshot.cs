﻿// <auto-generated />
using DAL.Implementation.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebUI.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MediaInteractivaEmployee")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Dou",
                            MediaInteractivaEmployee = true
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Sam",
                            LastName = "Horny",
                            MediaInteractivaEmployee = false
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Splinter",
                            LastName = "Teacher",
                            MediaInteractivaEmployee = true
                        });
                });

            modelBuilder.Entity("Model.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dick",
                            OwnerId = 1,
                            Type = "duck"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pussy",
                            OwnerId = 2,
                            Type = "cat"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Leonardo",
                            OwnerId = 3,
                            Type = "turtle"
                        });
                });

            modelBuilder.Entity("Model.Pet", b =>
                {
                    b.HasOne("Model.Employee", "Owner")
                        .WithOne("Pet")
                        .HasForeignKey("Model.Pet", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
