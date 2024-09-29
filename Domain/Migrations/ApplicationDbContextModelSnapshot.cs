﻿// <auto-generated />
using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Siegfried", b =>
                {
                    b.Property<Guid>("SiegfriedID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("LastUpdateId")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SiegfriedTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp");

                    b.HasKey("SiegfriedID");

                    b.HasIndex("SiegfriedTypeId");

                    b.ToTable("SIEGFRIED");
                });

            modelBuilder.Entity("Domain.Models.UserType", b =>
                {
                    b.Property<Guid>("SiegfriedTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("SiegfriedType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SiegfriedTypeId");

                    b.ToTable("SIEGFRIED_TYPE");
                });

            modelBuilder.Entity("Domain.Models.Users", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("LastUpdateId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SiegfriedID")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp");

                    b.HasKey("UserId");

                    b.HasIndex("SiegfriedID")
                        .IsUnique();

                    b.ToTable("SIGRID_USER");
                });

            modelBuilder.Entity("Domain.Models.Siegfried", b =>
                {
                    b.HasOne("Domain.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("SiegfriedTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Domain.Models.Users", b =>
                {
                    b.HasOne("Domain.Models.Siegfried", "Siegfried")
                        .WithOne("Users")
                        .HasForeignKey("Domain.Models.Users", "SiegfriedID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Siegfried");
                });

            modelBuilder.Entity("Domain.Models.Siegfried", b =>
                {
                    b.Navigation("Users")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
