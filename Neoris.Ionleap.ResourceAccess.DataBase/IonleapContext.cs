using Neoris.Ionleap.CrossCutting.Configuration;
using Neoris.Ionleap.ResourceAccess.Entities.Business;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;

namespace Neoris.Ionleap.ResourceAccess.DataBase
{
    public class IonleapContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolesPermissions { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationModule.ConnectionStrings.DatabaseContext);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateDummyTestData(modelBuilder);
        }

        private static void CreateDummyTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Identity = 1,
                    Active = true,
                    Name = "test",
                    DateCreated = new DateTime(),
                    Email = "test",
                    IsAdmin = true,
                    Password = "fbwH0d4qexF+eBHYk6aQjzjtJawdPZcNzUd3Wo5CI6g=",
                    PasswordSalt = "I5YIl4ReQNAbYxMl9i7gBPhqSS+DukLWR0TEzp/90nA=",
                    ProfilePictureUrl = "test",
                    Surname = "test",
                    DateBirth = new DateTime(),
                    EmployeeFileNumber = 1,
                    Username = "test",
                    DateModified = null,
                });


            modelBuilder.Entity<Brand>().HasData(
                new Brand()
                {
                    Identity = 1,
                    Description = "Xiaomi",
                },
                new Brand()
                {
                    Identity = 2,
                    Description = "Acer",
                },
                new Brand()
                {
                    Identity = 3,
                    Description = "Lenovo",
                },
                new Brand()
                {
                    Identity = 4,
                    Description = "Netmak",
                },
                new Brand()
                {
                    Identity = 5,
                    Description = "Asus",
                },
                new Brand()
                {
                    Identity = 6,
                    Description = "Gygabyte",
                },
                new Brand()
                {
                    Identity = 7,
                    Description = "SFX",
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Identity = 1,
                    Description = "Laptops",
                },
                new Category()
                {
                    Identity = 2,
                    Description = "Camaras",
                },
                new Category()
                {
                    Identity = 3,
                    Description = "Adaptadores",
                },
                new Category()
                {
                    Identity = 4,
                    Description = "Headsets",
                },
                new Category()
                {
                    Identity = 5,
                    Description = "Discos",
                },
                new Category()
                {
                    Identity = 6,
                    Description = "Monitores",
                },
                new Category()
                {
                    Identity = 7,
                    Description = "Motherboards",
                },
                new Category()
                {
                    Identity = 8,
                    Description = "Memorias",
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Identity = 1,
                    Name = "Juan Carlos",
                    Surname = "Gomez",
                    Description = "JC Gmz",
                    BusinessPrice = false,
                    Address = "",
                    DateCreated = DateTime.Now,
                    DateModified = null,
                    Email = "",
                    Mobile = "",
                    PersonalId = 0, 
                },
                new Customer()
                {
                    Identity = 2,
                    Name = "Arnold",
                    Surname = "Schwarzenegger",
                    Description = "Arnoldo",
                    BusinessPrice = true,
                    Address = "",
                    DateCreated = DateTime.Now,
                    DateModified = null,
                    Email = "",
                    Mobile = "",
                    PersonalId = 0,
                },
                new Customer()
                {
                    Identity = 3,
                    Name = "Silvester",
                    Surname = "Stallone",
                    Description = "Caratorcida",
                    BusinessPrice = true,
                    Address = "",
                    DateCreated = DateTime.Now,
                    DateModified = null,
                    Email = "",
                    Mobile = "",
                    PersonalId = 0,
                },
                new Customer()
                {
                    Identity = 4,
                    Name = "Jean Claude",
                    Surname = "Van Damme",
                    Description = "Patadita",
                    BusinessPrice = true,
                    Address = "",
                    DateCreated = DateTime.Now,
                    DateModified = null,
                    Email = "",
                    Mobile = "",
                    PersonalId = 0,
                },
                new Customer()
                {
                    Identity = 5,
                    Name = "Carol",
                    Surname = "Danvers",
                    Description = "Captain Marvel",
                    BusinessPrice = false,
                    Address = "",
                    DateCreated = DateTime.Now,
                    DateModified = null,
                    Email = "",
                    Mobile = "",
                    PersonalId = 0,
                },
                new Customer()
                {
                    Identity = 6,
                    Name = "Betty",
                    Surname = "Kane",
                    Description = "Batgirl",
                    BusinessPrice = false,
                    Address = "",
                    DateCreated = DateTime.Now,
                    DateModified = null,
                    Email = "",
                    Mobile = "",
                    PersonalId = 0,
                },
                new Customer()
                {
                    Identity = 7,
                    Name = "Kristin",
                    Surname = "Wells",
                    Description = "Superwoman",
                    BusinessPrice = false,
                    Address = "",
                    DateCreated = DateTime.Now,
                    DateModified = null,
                    Email = "",
                    Mobile = "",
                    PersonalId = 0,
                },
                new Customer()
                {
                    Identity = 8,
                    Name = "Natasha",
                    Surname = "Romanoff",
                    Description = "Black Widow",
                    BusinessPrice = false,
                    Address = "",
                    DateCreated = DateTime.Now,
                    DateModified = null,
                    Email = "",
                    Mobile = "",
                    PersonalId = 0,
                }
           );

        }
    }
}