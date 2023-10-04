using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using NapoSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapoSport.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category 1", DisplayOrder = 1, Thumbnail = "" },
                new Category { Id = 2, Name = "Category 2", DisplayOrder = 2, Thumbnail = "" },
                new Category { Id = 3, Name = "Category 3", DisplayOrder = 3, Thumbnail = "" }
                );
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Brand 1", LogoUrl = "", Description = "Day la brand 1", Website = ""},
                new Brand { Id = 2, Name = "Brand 2", LogoUrl = "", Description = "Day la brand 2", Website = ""},
                new Brand { Id = 3, Name = "Brand 3", LogoUrl = "", Description = "Day la brand 3", Website = ""}
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Code = 123123,
                    MarketPrice = 10000,
                    Price = 8000,
                    Discount = 12,
                    Offers = "",
                    ProductInfo = "Product Info 1",
                    RecommendedUsage = "Huong dan su dung san pham 1",
                    ImageUrl = "",
                    CategoryId = 1,
                    BrandId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Code = 123123,
                    MarketPrice = 10000,
                    Price = 8000,
                    Discount = 12,
                    Offers = "",
                    ProductInfo = "Product Info 2",
                    RecommendedUsage = "Huong dan su dung san pham 2",
                    ImageUrl = "",
                    CategoryId = 2,
                    BrandId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Code = 123123,
                    MarketPrice = 10000,
                    Price = 8000,
                    Discount = 12,
                    Offers = "",
                    ProductInfo = "Product Info 3",
                    RecommendedUsage = "Huong dan su dung san pham 3",
                    ImageUrl = "",
                    CategoryId = 3,
                    BrandId = 3
                }
                );
        }
    }
}
