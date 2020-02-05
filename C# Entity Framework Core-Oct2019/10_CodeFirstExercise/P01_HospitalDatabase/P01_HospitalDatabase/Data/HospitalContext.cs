using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>(e => 
            {
                e.HasKey(d => d.DiagnoseId);

                e.Property(d => d.Name)
                  .HasMaxLength(Constraint.NameMaxLength)
                  .IsRequired(true)
                  .IsUnicode(true);

                e.Property(d => d.Comments)
                  .HasMaxLength(Constraint.CommentsMaxLength)
                  .IsRequired(false)
                  .IsUnicode(true);

                e.HasOne(d => d.Patient)
                  .WithMany(p => p.Diagnoses)
                  .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Doctor>(e => 
            {
                e.HasKey(d => d.DoctorId);

                e.Property(d => d.Name)
                  .HasMaxLength(Constraint.DoctorNameMaxLength)
                  .IsRequired(true)
                  .IsUnicode(true);

                e.Property(d => d.Specialty)
                  .HasMaxLength(Constraint.DoctorSpecialtyMaxLength)
                  .IsRequired(true)
                  .IsUnicode(true);
            });

            modelBuilder.Entity<Medicament>(e => 
            {
                e.HasKey(m => m.MedicamentId);

                e.Property(m => m.Name)
                  .HasMaxLength(Constraint.NameMaxLength)
                  .IsRequired(true)
                  .IsUnicode(true);
            });

            modelBuilder.Entity<Patient>(e => 
            {
                e.HasKey(p => p.PatientId);

                e.Property(p => p.FirstName)
                  .HasMaxLength(Constraint.NameMaxLength)
                  .IsRequired(true)
                  .IsUnicode(true);

                e.Property(p => p.LastName)
                  .HasMaxLength(Constraint.NameMaxLength)
                  .IsRequired(true)
                  .IsUnicode(true);

                e.Property(p => p.Address)
                .HasMaxLength(Constraint.AddressMaxLength)
                .IsRequired(true)
                .IsUnicode(true);

                e.Property(p => p.Email)
                .HasMaxLength(Constraint.EmailMaxLength)
                .IsRequired(false)
                .IsUnicode(false);

                e.Property(p => p.HasInsurance)
                .IsRequired(true);
            });

            modelBuilder.Entity<PatientMedicament>(e => 
            {
                e.HasKey(pm => new
                {
                    pm.PatientId,
                    pm.MedicamentId
                });

                e.HasOne(pm => pm.Patient)
                  .WithMany(p => p.Prescriptions)
                  .HasForeignKey(pm => pm.PatientId);

                e.HasOne(pm => pm.Medicament)
                  .WithMany(m => m.Prescriptions)
                  .HasForeignKey(pm => pm.MedicamentId);
            });

            modelBuilder.Entity<Visitation>(e => 
            {
                e.HasKey(v => v.VisitationId);

                e.Property(v => v.Date)
                  .IsRequired(true)
                  .HasColumnType("DATETIME2")
                  .HasDefaultValueSql("GETDATE()");

                e.Property(v => v.Comments)
                  .HasMaxLength(Constraint.CommentsMaxLength)
                  .IsRequired(false)
                  .IsUnicode(true);

                e.HasOne(v => v.Patient)
                  .WithMany(p => p.Visitations)
                  .HasForeignKey(v => v.PatientId);

                e.HasOne(v => v.Doctor)
                  .WithMany(d => d.Visitations)
                  .HasForeignKey(v => v.DoctorId);
            });
        }
    }
}
