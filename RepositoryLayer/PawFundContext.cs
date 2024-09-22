using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelLayer.Entities;
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


            modelBuilder.Entity<Certification>()
                .HasOne(c => c.User)
                .WithMany(u => u.Certifications)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
