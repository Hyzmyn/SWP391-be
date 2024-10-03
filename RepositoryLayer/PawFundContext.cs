using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelLayer.Entities;
using RepositoryLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class PawFundContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shelter> Shelters { get; set; }
        public virtual DbSet<ShelterStaff> ShelterStaffs { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        public PawFundContext(DbContextOptions<PawFundContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(GetConnectionString(),
                new MySqlServerVersion(new Version(8, 0, 2))); // Replace with your MySQL version
        }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return configuration.GetConnectionString("DefaultConnection"); // Replace this with your actual connection string key
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.Id))
                    .ValueGeneratedOnAdd();
            }

            modelBuilder.Entity<Certification>()
                .HasOne(c => c.User)
                .WithMany(u => u.Certifications)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Certification>()
                .HasOne(c => c.ShelterStaff)
                .WithMany()
                .HasForeignKey(c => c.ShelterStaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<AdoptionRegistrationForm>()
                .Property(a => a.IncomeAmount)
                .HasColumnType("decimal(16, 4)");

            modelBuilder.Entity<Donation>()
                .Property(a => a.Amount)
                .HasColumnType("decimal(16, 4)");

            modelBuilder.Entity<User>()
                .Property(a => a.TotalDonation)
                .HasColumnType("decimal(16, 4)");

            modelBuilder.Entity<Shelter>()
                .Property(a => a.DonationAmount)
                .HasColumnType("decimal(16, 4)");

            modelBuilder.Entity<Certification>()
                .HasOne(c => c.Pet)
                .WithOne(p => p.Certification)
                .HasForeignKey<Certification>(c => c.PetId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "ShelterStaff" },
                new Role { Id = 3, Name = "Donor" },
                new Role { Id = 4, Name = "Volunteer" },
                new Role { Id = 5, Name = "Adopter" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Admin", Email = "Admin@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 2, Username = "Staff1", Email = "Staff1@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 3, Username = "Staff2", Email = "Staff2@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 4, Username = "Staff3", Email = "Staff3@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 5, Username = "Staff4", Email = "Staff4@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 6, Username = "Donor1", Email = "Donor1@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 7, Username = "Donor2", Email = "Donor2@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 8, Username = "Donor3", Email = "Donor3@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 9, Username = "Donor4", Email = "Donor4@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 10, Username = "Volunteer1", Email = "Volunteer1@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 11, Username = "Volunteer2", Email = "Volunteer2@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 12, Username = "Volunteer3", Email = "Volunteer3@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 13, Username = "Volunteer4", Email = "Volunteer4@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 14, Username = "Adopter1", Email = "Adopter1@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 15, Username = "Adopter2", Email = "Adopter2@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 16, Username = "Adopter3", Email = "Adopter3@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 17, Username = "Adopter4", Email = "Adopter4@email.com", Password = PasswordTools.HashPassword("123456") }

            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId = 1, RoleId = 1 },
                new UserRole { Id = 2, UserId = 2, RoleId = 2 },
                new UserRole { Id = 3, UserId = 3, RoleId = 2 },
                new UserRole { Id = 4, UserId = 4, RoleId = 2 },
                new UserRole { Id = 5, UserId = 5, RoleId = 2 },
                new UserRole { Id = 6, UserId = 6, RoleId = 3 },
                new UserRole { Id = 7, UserId = 7, RoleId = 3 },
                new UserRole { Id = 8, UserId = 8, RoleId = 3 },
                new UserRole { Id = 9, UserId = 9, RoleId = 3 },
                new UserRole { Id = 10, UserId = 10, RoleId = 4 },
                new UserRole { Id = 11, UserId = 11, RoleId = 4 },
                new UserRole { Id = 12, UserId = 12, RoleId = 4 },
                new UserRole { Id = 13, UserId = 13, RoleId = 4 },
                new UserRole { Id = 14, UserId = 14, RoleId = 5 },
                new UserRole { Id = 15, UserId = 15, RoleId = 5 },
                new UserRole { Id = 16, UserId = 16, RoleId = 5 },
                new UserRole { Id = 17, UserId = 17, RoleId = 5 }

            );

            modelBuilder.Entity<Shelter>().HasData(
                new Shelter { Id = 1, Name = "Shelter1", Location = "Tp. HCM", PhoneNumber = "1234567890", Capaxity = 20, Email = "PetShelter1@email.com" },
                new Shelter { Id = 2, Name = "Shelter2", Location = "Ha Noi", PhoneNumber = "0987654321", Capaxity = 20, Email = "PetShelter2@email.com" }
            );

            modelBuilder.Entity<ShelterStaff>().HasData(
                new ShelterStaff { Id = 1, UserId = 2, ShelterId = 1 },
                new ShelterStaff { Id = 2, UserId = 3, ShelterId = 1 },
                new ShelterStaff { Id = 3, UserId = 4, ShelterId = 2 },
                new ShelterStaff { Id = 4, UserId = 5, ShelterId = 2 }

            );

            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, ShelterID = 1, Name = "Buddy", Type = "Dog", UserID = 17 },
                new Pet { Id = 2, ShelterID = 1, Name = "Whiskers", Type = "Cat", UserID = 17 },
                new Pet { Id = 3, ShelterID = 1, Name = "Max", Type = "Dog", UserID = 16 },
                new Pet { Id = 4, ShelterID = 1, Name = "Luna", Type = "Cat", UserID = 14 },
                new Pet { Id = 5, ShelterID = 1, Name = "Bella", Type = "Dog" },
                new Pet { Id = 6, ShelterID = 1, Name = "Lux", Type = "Cat" },
                new Pet { Id = 7, ShelterID = 1, Name = "Dono", Type = "Dog" },
                new Pet { Id = 8, ShelterID = 1, Name = "Linker", Type = "Cat" },
                new Pet { Id = 9, ShelterID = 1, Name = "Dawin", Type = "Dog", UserID = 15 },
                new Pet { Id = 10, ShelterID = 2, Name = "Modor", Type = "Cat" },
                new Pet { Id = 11, ShelterID = 2, Name = "Pingking", Type = "Dog" },
                new Pet { Id = 12, ShelterID = 2, Name = "Seto", Type = "Cat" },
                new Pet { Id = 13, ShelterID = 2, Name = "kaiba", Type = "Dog" },
                new Pet { Id = 14, ShelterID = 2, Name = "Asuka", Type = "Cat" },
                new Pet { Id = 15, ShelterID = 2, Name = "Jax", Type = "Dog" },
                new Pet { Id = 16, ShelterID = 2, Name = "Jihn", Type = "Cat" },
                new Pet { Id = 18, ShelterID = 2, Name = "Kaisa", Type = "Dog" },
                new Pet { Id = 19, ShelterID = 2, Name = "Bump", Type = "Dog" },
                new Pet { Id = 20, ShelterID = 2, Name = "Rasko", Type = "Dog" }


            );
            modelBuilder.Entity<Donation>().HasData(
                new Donation { Id = 1, DonorId = 6, ShelterId = 1, Amount = 100000 },
                new Donation { Id = 2, DonorId = 7, ShelterId = 1, Amount = 200000 },
                new Donation { Id = 3, DonorId = 8, ShelterId = 2, Amount = 543333 },
                new Donation { Id = 4, DonorId = 9, ShelterId = 2, Amount = 632229 },
                new Donation { Id = 5, DonorId = 7, ShelterId = 2, Amount = 760000 }

            );
            modelBuilder.Entity<Status>().HasData(
                  new Status
                  {
                      Id = 1,
                      PetId = 1,
                      Date = new DateTime(2024, 1, 15),
                      Disease = "Parvovirus Infection",
                      Vaccine = "Parvovirus Vaccine"
                  },
                  new Status
                  {
                      Id = 2,
                      PetId = 3,
                      Date = new DateTime(2024, 2, 20),
                      Disease = "Distemper Virus",
                      Vaccine = "Distemper Vaccine"
                  },
                  new Status
                  {
                      Id = 3,
                      PetId = 5,
                      Date = new DateTime(2024, 3, 10),
                      Disease = "Rabies Virus",
                      Vaccine = "Rabies Vaccine"
                  },
                  new Status
                  {
                      Id = 4,
                      PetId = 2,
                      Date = new DateTime(2024, 4, 5),
                      Disease = "FeLV",
                      Vaccine = "FeLV Vaccine"
                  },
                  new Status
                  {
                      Id = 5,
                      PetId = 4,
                      Date = new DateTime(2024, 5, 12),
                      Disease = "FIV",
                      Vaccine = "None"
                  }
            );
        }
    }
}
