using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_new.Model
{
    public class HospitalDataContext : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }


        public HospitalDataContext(DbContextOptions<HospitalDataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Diagnose>().HasKey(s => new { s.Id, s.Symptoms });

            modelBuilder.Entity<Diagnose>().ToTable("DiagnosesInfo");
            modelBuilder.Entity<Doctor>().ToTable("DoctorInfo");
            modelBuilder.Entity<Patient>().ToTable("PatientInfo");



            var doctors = modelBuilder.Entity<Doctor>();
            var diagnoses = modelBuilder.Entity<Diagnose>();
            var patients = modelBuilder.Entity<Patient>();

            //moje pk's
            diagnoses.HasKey(x => x.Id);
            doctors.HasKey(x => x.Id);
            patients.HasKey(x => x.Id);


            modelBuilder.Entity<Diagnose>()
                .HasOne(x => x.Patient)
                .WithOne(x => x.Diagnose)
                .HasForeignKey<Patient>(x => x.Id);


            patients.Property(x => x.DoctorId).IsRequired();

            modelBuilder.Entity<Patient>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.Patients)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Diagnose>()
                  .HasOne(x => x.Doctor)
                  .WithMany(x=>x.Diagnoses);
                  
                


         


        }



    }
}
