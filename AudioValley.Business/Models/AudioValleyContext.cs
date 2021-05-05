using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AudioValley.Business.Models
{
    public partial class AudioValleyContext : DbContext
    {
        public AudioValleyContext()
        {
        }

        public AudioValleyContext(DbContextOptions<AudioValleyContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.ToTable("Adress");

                entity.Property(e => e.AdressId)
                    .ValueGeneratedNever()
                    .HasColumnName("AdressID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CountryCode).ValueGeneratedOnAdd();

                entity.Property(e => e.Street).IsRequired();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Adresses)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Adress_Contact");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.ContactId)
                    .ValueGeneratedNever()
                    .HasColumnName("ContactID");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
