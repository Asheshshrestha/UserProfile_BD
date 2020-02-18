﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProfileDisplay.Data;

namespace ProfileDisplay.Migrations
{
    [DbContext(typeof(UserProfileContext))]
    [Migration("20200218093026_FirstCreate")]
    partial class FirstCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProfileDisplay.Models.UserProfile", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("CoverImage");

                    b.Property<string>("Degree");

                    b.Property<string>("Experience");

                    b.Property<string>("FirstName");

                    b.Property<string>("JobPost");

                    b.Property<string>("LastName");

                    b.Property<string>("ProfileImage");

                    b.Property<string>("University");

                    b.HasKey("UserName");

                    b.ToTable("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
