using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMO_EFCore
{
    
    class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        //public DbSet<EventItem> EventItems { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Guild> Guilds { get; set; }

        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(ConnectionString);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item>().HasQueryFilter(i => i.SoftDeleted == false);

            builder.Entity<Player>()
                .HasIndex(p => p.Name)
                .HasName("Index_Person_Name")
                .IsUnique();

            //builder.Entity<Player>()
            //    .HasMany(p => p.CreatedItems)
            //    .WithOne(i => i.Creator)
            //    .HasForeignKey(i => i.TestCreatorId);

            builder.Entity<Player>()
                .HasOne(p => p.OwnedItem)
                .WithOne(i => i.Owner)
                .HasForeignKey<Item>(i => i.TestOwnerId);

            builder.Entity<Item>().Property<DateTime>("RecoveredDate");

            //builder.Entity<Item>()
            //    .Property(i => i.JsonData)
            //    .HasField("_jsonData");

            //builder.Entity<Item>()
            //    .OwnsOne(i => i.Option);

            //builder.Entity<Item>()
            //    .OwnsOne(i => i.Option)
            //    .ToTable("ItemOption");

            //builder.Entity<Item>()
            //    .HasDiscriminator(i => i.Type)
            //    .HasValue<Item>(ItemType.NormalItem)
            //    .HasValue<EventItem>(ItemType.EventItem);

            // Table Splitting
            //builder.Entity<Item>()
            //    .HasOne(i => i.Detail)
            //    .WithOne()
            //    .HasForeignKey<ItemDetail>(i => i.ItemDetailId);

            //builder.Entity<Item>().ToTable("Items");
            //builder.Entity<ItemDetail>().ToTable("Items");

            //builder.Entity<Item>()
            //       .Metadata
            //       .FindNavigation("Reviews")
            //       .SetPropertyAccessMode(PropertyAccessMode.Field);

            // DbFunction
            //builder.HasDbFunction(() => Program.GetAverageReviewScore(0));

            //builder.Entity<Item>()
            //    .Property("CreateDate")
            //    .HasDefaultValue(DateTime.Now);

            builder.Entity<Item>()
                .Property("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Player>()
                .Property(p => p.Name)
                .HasValueGenerator((p, e) => new PlayerNameGenerator());
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added);

            foreach(var entity in entities)
            {
                ILogEntity tracked = entity.Entity as ILogEntity;
                if (tracked != null)
                    tracked.SetCreateTime();
            }
            return base.SaveChanges();
        }
    }
}
