using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Demo.Services;

namespace Demo.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20160826041344_addProductDatabaseMigration2")]
    partial class addProductDatabaseMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Demo.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("TblCategory");
                });

            modelBuilder.Entity("Demo.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Details");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TblProduct");
                });

            modelBuilder.Entity("Demo.Models.Product", b =>
                {
                    b.HasOne("Demo.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
