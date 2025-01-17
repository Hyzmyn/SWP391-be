﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelLayer.Entities;
using ModelLayer.Entities.Momo;
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
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<AdoptionRegistrationForm> Forms { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<SmsMessage> SmsMessages { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<PetStatus> PetStatuses { get; set; }
        public virtual DbSet<VnPayTransaction> VnPayTransaction { get; set; }

        public virtual DbSet<MomoPay> MomoPays { get; set; }

        public PawFundContext(DbContextOptions<PawFundContext> options) : base(options)
        {
        }

        public PawFundContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(GetConnectionString(),
                new MySqlServerVersion(new Version(8, 0, 2)));
        }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return configuration.GetConnectionString("DefaultConnection");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .HasOne(u => u.Shelter)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.ShelterId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EventUser>()
                .HasKey(ur => new { ur.UserId, ur.EventId });

            modelBuilder.Entity<VnPayTransaction>()
                .HasKey(i => i.TransactionId);

            modelBuilder.Entity<EventUser>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.Events)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<EventUser>()
                .HasOne(ur => ur.Event)
                .WithMany(r => r.Users)
                .HasForeignKey(ur => ur.EventId);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<PetStatus>()
                .HasKey(ur => new { ur.PetId, ur.StatusId });

            modelBuilder.Entity<PetStatus>()
                .HasOne(p => p.Pet)
                .WithMany(u => u.Statuses)
                .HasForeignKey(p => p.PetId);

            modelBuilder.Entity<PetStatus>()
                .HasOne(ur => ur.Status)
                .WithMany(r => r.Pet)
                .HasForeignKey(p => p.StatusId);

            modelBuilder.Entity<Donation>()
                .HasOne(d => d.User)
                .WithMany(u => u.Donations)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Donation>()
                .HasOne(d => d.Shelter)
                .WithMany(s => s.Donations)
                .HasForeignKey(d => d.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<AdoptionRegistrationForm>()
                .Property(a => a.IncomeAmount)
                .HasColumnType("decimal(18, 4)");

            modelBuilder.Entity<Donation>()
                .Property(a => a.Amount)
                .HasColumnType("decimal(18, 4)");

            modelBuilder.Entity<User>()
                .Property(a => a.TotalDonation)
                .HasColumnType("decimal(18, 4)");

            modelBuilder.Entity<User>()
                .Property(a => a.wallet)
                .HasColumnType("decimal(18, 4)");

            modelBuilder.Entity<Shelter>()
                .Property(a => a.DonationAmount)
                .HasColumnType("decimal(18, 4)");

            modelBuilder.Entity<Certification>()
                .HasOne(c => c.Pet)
                .WithOne(p => p.Certification)
                .HasForeignKey<Certification>(c => c.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MomoPay>()
                .HasOne(m => m.User)
                .WithMany(u => u.MomoPays)  // nếu User có danh sách MomoPays
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict); // hoặc DeleteBehavior khác phù hợp


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "ShelterStaff" },
                new Role { Id = 3, Name = "Donor" },
                new Role { Id = 4, Name = "Volunteer" },
                new Role { Id = 5, Name = "Adopter" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Admin", Email = "Admin@email.com", Password = PasswordTools.HashPassword("123456") },
                new User { Id = 2, Username = "Staff1", Email = "Staff1@email.com", Password = PasswordTools.HashPassword("123456"), ShelterId = 1 },
                new User { Id = 3, Username = "Staff2", Email = "Staff2@email.com", Password = PasswordTools.HashPassword("123456"), ShelterId = 1 },
                new User { Id = 4, Username = "Staff3", Email = "Staff3@email.com", Password = PasswordTools.HashPassword("123456"), ShelterId = 2 },
                new User { Id = 5, Username = "Staff4", Email = "Staff4@email.com", Password = PasswordTools.HashPassword("123456"), ShelterId = 2 },
                new User { Id = 6, Username = "Donor1", Email = "Donor1@email.com", Password = PasswordTools.HashPassword("123456"), Phone = "123456789", Location = "HCM", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png" },
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
                new UserRole { UserId = 1, RoleId = 1, Status = true },
                new UserRole { UserId = 2, RoleId = 2, Status = true },
                new UserRole { UserId = 3, RoleId = 2, Status = true },
                new UserRole { UserId = 4, RoleId = 2, Status = true },
                new UserRole { UserId = 5, RoleId = 2, Status = true },
                new UserRole { UserId = 6, RoleId = 3, Status = true },
                new UserRole { UserId = 6, RoleId = 4, Status = true },
                new UserRole { UserId = 7, RoleId = 3, Status = true },
                new UserRole { UserId = 7, RoleId = 5, Status = true },
                new UserRole { UserId = 8, RoleId = 3, Status = true },
                new UserRole { UserId = 8, RoleId = 4, Status = true },
                new UserRole { UserId = 8, RoleId = 5, Status = true },
                new UserRole { UserId = 9, RoleId = 3, Status = true },
                new UserRole { UserId = 10, RoleId = 4, Status = true },
                new UserRole { UserId = 10, RoleId = 3, Status = true },
                new UserRole { UserId = 11, RoleId = 4, Status = true },
                new UserRole { UserId = 11, RoleId = 5, Status = true },
                new UserRole { UserId = 12, RoleId = 4, Status = true },
                new UserRole { UserId = 12, RoleId = 3, Status = true },
                new UserRole { UserId = 12, RoleId = 5, Status = true },
                new UserRole { UserId = 13, RoleId = 4, Status = true },
                new UserRole { UserId = 14, RoleId = 5, Status = true },
                new UserRole { UserId = 15, RoleId = 5, Status = true },
                new UserRole { UserId = 15, RoleId = 3, Status = true },
                new UserRole { UserId = 16, RoleId = 5, Status = true },
                new UserRole { UserId = 16, RoleId = 4, Status = true },
                new UserRole { UserId = 17, RoleId = 5, Status = true },
                new UserRole { UserId = 17, RoleId = 4, Status = true },
                new UserRole { UserId = 17, RoleId = 3, Status = true }
            );

            modelBuilder.Entity<Shelter>().HasData(
                new Shelter { Id = 1, Name = "Shelter1", Location = "Quận 1", PhoneNumber = "1234567890", Capacity = 20, Email = "PetShelter1@email.com" },
                new Shelter { Id = 2, Name = "Shelter2", Location = "Bình Dương", PhoneNumber = "0987654321", Capacity = 20, Email = "PetShelter2@email.com" },
                new Shelter { Id = 3, Name = "Shelter3", Location = "Thủ Đức", PhoneNumber = "821638713", Capacity = 20, Email = "PetShelter3@email.com" },
                new Shelter { Id = 4, Name = "Shelter4", Location = "Quận 9", PhoneNumber = "8437587353", Capacity = 20, Email = "PetShelter4@email.com" }

            );


            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, ShelterID = 1, Name = "Buddy", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Adopted", Type = "Dog", UserID = 17 },
                new Pet { Id = 2, ShelterID = 1, Name = "Whiskers", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Cat" },
                new Pet { Id = 3, ShelterID = 1, Name = "Max", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Adopted", Type = "Dog", UserID = 16 },
                new Pet { Id = 4, ShelterID = 1, Name = "Luna", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Adopted", Type = "Cat", UserID = 14 },
                new Pet { Id = 5, ShelterID = 1, Name = "Bella", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Dog" },
                new Pet { Id = 6, ShelterID = 1, Name = "Lux", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Cat" },
                new Pet { Id = 7, ShelterID = 1, Name = "Dono", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Dog" },
                new Pet { Id = 8, ShelterID = 1, Name = "Linker", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Cat" },
                new Pet { Id = 9, ShelterID = 1, Name = "Dawin", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Adopted", Type = "Dog", UserID = 15 },
                new Pet { Id = 10, ShelterID = 2, Name = "Modor", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Cat" },
                new Pet { Id = 11, ShelterID = 2, Name = "Pingking", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Dog" },
                new Pet { Id = 12, ShelterID = 2, Name = "Seto", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Cat" },
                new Pet { Id = 13, ShelterID = 2, Name = "kaiba", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Dog" },
                new Pet { Id = 14, ShelterID = 2, Name = "Asuka", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Cat" },
                new Pet { Id = 15, ShelterID = 2, Name = "Jax", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Dog" },
                new Pet { Id = 16, ShelterID = 2, Name = "Jihn", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Cat" },
                new Pet { Id = 18, ShelterID = 2, Name = "Kaisa", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Dog" },
                new Pet { Id = 19, ShelterID = 2, Name = "Bump", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Dog" },
                new Pet { Id = 20, ShelterID = 2, Name = "Rasko", Image = "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", AdoptionStatus = "Available", Type = "Dog" }


            );

            modelBuilder.Entity<Donation>().HasData(
                new Donation { Id = 1, DonorId = 6, ShelterId = 1, Amount = 100000, Date = new DateTime(2024, 01, 15) },
                new Donation { Id = 2, DonorId = 7, ShelterId = 1, Amount = 200000, Date = new DateTime(2024, 02, 10) },
                new Donation { Id = 3, DonorId = 8, ShelterId = 2, Amount = 543333, Date = new DateTime(2024, 03, 25) },
                new Donation { Id = 4, DonorId = 9, ShelterId = 2, Amount = 632229, Date = new DateTime(2024, 04, 12) },
                new Donation { Id = 5, DonorId = 7, ShelterId = 2, Amount = 760000, Date = new DateTime(2024, 05, 20) }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Date = new DateTime(2024, 1, 15),
                    Disease = "Parvovirus Infection",
                    Vaccine = "Parvovirus Vaccine"
                },
                new Status
                {
                    Id = 2,
                    Date = new DateTime(2024, 2, 20),
                    Disease = "Distemper Virus",
                    Vaccine = "Distemper Vaccine"
                },
                new Status
                {
                    Id = 3,
                    Date = new DateTime(2024, 3, 10),
                    Disease = "Rabies Virus",
                    Vaccine = "Rabies Vaccine"
                },
                new Status
                {
                    Id = 4,
                    Date = new DateTime(2024, 4, 5),
                    Disease = "FeLV",
                    Vaccine = "FeLV Vaccine"
                },
                new Status
                {
                    Id = 5,
                    Date = new DateTime(2024, 5, 12),
                    Disease = "FIV",
                    Vaccine = "None"
                }
            );
            modelBuilder.Entity<PetStatus>().HasData(
                new PetStatus { PetId = 1, StatusId = 1 },
                new PetStatus { PetId = 3, StatusId = 2 },
                new PetStatus { PetId = 5, StatusId = 3 },
                new PetStatus { PetId = 2, StatusId = 4 },
                new PetStatus { PetId = 4, StatusId = 5 }

                );
        }
    }
}
