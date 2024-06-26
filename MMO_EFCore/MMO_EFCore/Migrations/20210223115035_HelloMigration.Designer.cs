﻿// <auto-generated />
using System;
using MMO_EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MMO_EFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210223115035_HelloMigration")]
    partial class HelloMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MMO_EFCore.Guild", b =>
                {
                    b.Property<int>("GuildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GuildName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuildId");

                    b.ToTable("Guild");
                });

            modelBuilder.Entity("MMO_EFCore.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("ItemGreade")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecoveredDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<int>("TestOwnerId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TestOwnerId")
                        .IsUnique();

                    b.ToTable("Item");
                });

            modelBuilder.Entity("MMO_EFCore.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GuildId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PlayerId");

                    b.HasIndex("GuildId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("Index_Person_Name");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("MMO_EFCore.Item", b =>
                {
                    b.HasOne("MMO_EFCore.Player", null)
                        .WithMany("CreatedItems")
                        .HasForeignKey("PlayerId");

                    b.HasOne("MMO_EFCore.Player", "Owner")
                        .WithOne("OwnedItem")
                        .HasForeignKey("MMO_EFCore.Item", "TestOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MMO_EFCore.Player", b =>
                {
                    b.HasOne("MMO_EFCore.Guild", "Guild")
                        .WithMany("Members")
                        .HasForeignKey("GuildId");

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("MMO_EFCore.Guild", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("MMO_EFCore.Player", b =>
                {
                    b.Navigation("CreatedItems");

                    b.Navigation("OwnedItem");
                });
#pragma warning restore 612, 618
        }
    }
}
