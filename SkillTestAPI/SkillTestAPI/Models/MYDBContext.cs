using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SkillTestAPI.Models
{
    public partial class MYDBContext : DbContext
    {
        public MYDBContext()
        {
        }

        public MYDBContext(DbContextOptions<MYDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Contact> Contact { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-G03BA7H;Database=MYDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SurName)
                    .HasColumnName("SURNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Tel).HasColumnName("TEL").HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.Cell).HasColumnName("CELL").HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedDate).HasColumnName("UPDATEDDATE");
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
