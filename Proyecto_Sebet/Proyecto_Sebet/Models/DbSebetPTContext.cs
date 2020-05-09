using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_Sebet.Models
{
    public partial class DbSebetPTContext : DbContext
    {
        public DbSebetPTContext()
        {
        }

        public DbSebetPTContext(DbContextOptions<DbSebetPTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Career> Career { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Graduate> Graduate { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<LegalForm> LegalForm { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestReview> TestReview { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-L2IH8MOK;Initial Catalog=DbSebetPT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.IdAnswer);

                entity.Property(e => e.AnswerQ).IsRequired();

                entity.HasOne(d => d.IdGraduateNavigation)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.IdGraduate)
                    .HasConstraintName("FK__Answer__IdGradua__52593CB8");
            });

            modelBuilder.Entity<Career>(entity =>
            {
                entity.HasKey(e => e.IdCareer);

                entity.HasIndex(e => e.NameCareer)
                    .HasName("UQ__Career__320EAB435E758A8D")
                    .IsUnique();

                entity.Property(e => e.DescriptionCareer)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NameCareer)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.IdCompany);

                entity.HasIndex(e => e.BusinessName)
                    .HasName("UQ__Company__95A8740EB1F8DD24")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Company__A9D1053467BEA197")
                    .IsUnique();

                entity.HasIndex(e => e.Rfc)
                    .HasName("UQ__Company__CAFFA85EA63D62E2")
                    .IsUnique();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.PasswordR)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RecluiterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnName("RFC")
                    .HasMaxLength(13);

                entity.HasOne(d => d.IdIndustryNavigation)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.IdIndustry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Company__IdLegal__45F365D3");

                entity.HasOne(d => d.IdLegalFormNavigation)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.IdLegalForm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Company__IdLegal__46E78A0C");
            });

            modelBuilder.Entity<Graduate>(entity =>
            {
                entity.HasKey(e => e.IdGraduate);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Graduate__A9D105342713DF02")
                    .IsUnique();

                entity.HasIndex(e => e.Inscription)
                    .HasName("UQ__Graduate__3C48DFEAD345AB8E")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.GraduateName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PasswordG)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCareerNavigation)
                    .WithMany(p => p.Graduate)
                    .HasForeignKey(d => d.IdCareer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Graduate__IdCare__3C69FB99");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.HasKey(e => e.IdIndustry);

                entity.Property(e => e.DescriptionI).HasMaxLength(100);

                entity.Property(e => e.IndustryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.IdJob);

                entity.Property(e => e.Employment)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IdCompany).HasColumnName("idCompany");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job__idCompany__49C3F6B7");
            });

            modelBuilder.Entity<LegalForm>(entity =>
            {
                entity.HasKey(e => e.IdLegalForm);

                entity.Property(e => e.DescripionL).HasMaxLength(100);

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdQuestion);

                entity.Property(e => e.QuestionDescription).IsRequired();

                entity.HasOne(d => d.IdTestNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Question__Questi__4F7CD00D");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.IdTest);

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TotalQuestions).HasColumnName("Total_Questions");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Test__Total_Ques__4CA06362");
            });

            modelBuilder.Entity<TestReview>(entity =>
            {
                entity.HasKey(e => e.IdQualification);

                entity.Property(e => e.IdQuestion).HasColumnName("idQuestion");

                entity.HasOne(d => d.IdAnswerNavigation)
                    .WithMany(p => p.TestReview)
                    .HasForeignKey(d => d.IdAnswer)
                    .HasConstraintName("FK__TestRevie__IdAns__5629CD9C");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.TestReview)
                    .HasForeignKey(d => d.IdQuestion)
                    .HasConstraintName("FK__TestRevie__Score__5535A963");
            });
        }
    }
}
