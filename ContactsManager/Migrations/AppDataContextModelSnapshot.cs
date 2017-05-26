using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ContactsManager;

namespace ContactsManager.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsManager.Models.ContactCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Email");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<string>("VatNumber");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ContactsManager.Models.ContactPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("DayOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });
        }
    }
}
