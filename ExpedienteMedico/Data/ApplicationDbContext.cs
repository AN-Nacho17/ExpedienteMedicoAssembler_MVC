﻿using ExpedienteMedico.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpedienteMedico.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Physician> Physicians { get; set; }

        public DbSet<PhysicianSpecialty> PhysicianSpecialties { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<Suffering> Sufferings { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhysicianSpecialty>()
                .HasKey(bc => new { bc.PhysicianId, bc.SpecialtyId });
            //modelBuilder.Entity<PhysicianSpecialty>()
            //    .HasOne(bc => bc.Physician)
            //    .WithMany(b => b.PhysicianSpecialties)
            //    .HasForeignKey(bc => bc.PhysicianId);
            //modelBuilder.Entity<PhysicianSpecialty>()
            //    .HasOne(bc => bc.Specialty)
            //    .WithMany(c => c.PhysicianSpecialties)
            //    .HasForeignKey(bc => bc.SpecialtyId);

            //modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        }
    }

}

