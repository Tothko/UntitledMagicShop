using Microsoft.EntityFrameworkCore;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Infrastructure.SQLData
{
    public class UntitledMagicShopAppContext : DbContext
    {
        public UntitledMagicShopAppContext(DbContextOptions<UntitledMagicShopAppContext> opt) : base(opt)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
             .HasOne(p => p.User)
             .WithMany(u => u.Purchases)
             .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Item>()
             .HasMany(i => i.Images)
             .WithOne(il => il.Item)
             .OnDelete(DeleteBehavior.SetNull);

             modelBuilder.Entity<User>()
                 .HasMany(u => u.Purchases)
                 .WithOne(p => p.User)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ItemImages>()
         .HasKey(Ii => new { Ii.ItemID, Ii.ImageID });

        }
    }
}