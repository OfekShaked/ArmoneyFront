using Microsoft.EntityFrameworkCore;
using System;
namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=DESKTOP-BPO49OV;Initial Catalog=BuyMeDB;Integrated Security=True");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.BirthDate)
                .IsRequired()
                .HasColumnType("smalldatetime")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Owner)
                .WithMany(s => s.ProductsCreated)
                .HasForeignKey(p => p.OwnerId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(s => s.ProductsAdded)
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Product>()
                .Property(p => p.Title)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.ShortDescription)
                .HasColumnType("nvarchar(500)")
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.LongDescription)
                .HasColumnType("nvarchar(4000)")
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Date)
                .HasColumnType("smalldatetime")
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.State)
                .IsRequired(); 

            base.OnModelCreating(modelBuilder);

        }
    }
}
