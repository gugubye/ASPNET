using Lunch.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lunch.Data
{
    public class LunchContext : DbContext
    {
        public LunchContext(DbContextOptions<LunchContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FoodMenu> FoodMenus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Food> Order_Foods { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(x => x.Phone).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(x => x.Address).HasMaxLength(500);
            modelBuilder.Entity<User>().Property(x => x.Avatar).HasMaxLength(500);
            modelBuilder.Entity<User>().Property(x => x.NickName).HasMaxLength(500);

            modelBuilder.Entity<FoodMenu>().HasKey(x => x.Id);
            modelBuilder.Entity<FoodMenu>().Property(x => x.Name).HasMaxLength(200);
            modelBuilder.Entity<FoodMenu>().Property(x => x.Description).HasMaxLength(500);
            modelBuilder.Entity<FoodMenu>().Property(x => x.ImageType).HasMaxLength(200);

            modelBuilder.Entity<Order>().HasKey(x => x.Id);

            modelBuilder.Entity<Order_Food>().HasKey(x => x.Id);

            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(500);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "荤菜"
                });

            modelBuilder.Entity<Order_Food>().HasData(
                 new Order_Food()
                 {
                     Id = 1,
                     OrderId = 1,
                     FoodId = 1,
                 });

            modelBuilder.Entity<FoodMenu>().HasData(
               new FoodMenu()
               {
                   Id = 1,
                   Name = "testtest",
                   Description = "testtest！",
                   Price = 88.99m,
                   StockCount = 100,
                   CreateTime = DateTime.Now,
                   Type = "荤菜"
               });

            modelBuilder.Entity<Order>().HasData(
              new Order()
              {
                  Id = 1,
                  UserId = 1,
                  Price = 120,
                  CreateTime = DateTime.Now,
                  Status="已付款"
              });

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    RoleId = 2,
                    Name = "ABB",
                    NickName = "Angel",
                    Password = "202cb962ac59075b964b07152d234b70",
                    Phone = "2321241251",
                    Address = "太平洋 中路23号6楼",
                    CreateTime = DateTime.Now
                },

                new User()
                 {
                     Id = 4,
                     RoleId = 1,
                     Name = "Admin",
                     NickName = "admin",
                     Password = "202cb962ac59075b964b07152d234b70",
                     Phone = "24252622424",
                     Address = "ok",
                     CreateTime = DateTime.Now
                 });
        }
    }
}
