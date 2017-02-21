using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using MyCert.Data.Models;

namespace MyCert.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectCategory> SubjectCategories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestSubject> TestSubjects { get; set; }
        public DbSet<UserCertificate> UserCertificates { get; set; }
        public DbSet<UserPartitionInfo> UserPartitionInfos { get; set; }
        public DbSet<UserReference> UserReferences { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserTest> UserTests { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<ApplicationUser>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<Answer>().HasKey(p => p.Id);
            builder.Entity<Answer>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<Answer>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<Answer>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<Answer>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<Certificate>().HasKey(p => p.Id);
            builder.Entity<Certificate>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<Certificate>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<Certificate>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<Certificate>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<Question>().HasKey(p => p.Id);
            builder.Entity<Question>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<Question>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<Question>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<Question>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<Question>().HasOne(p => p.QuestionCategory).WithMany(p => p.Questions).HasForeignKey(p => p.QuestionCategoryId).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<QuestionCategory>().HasKey(p => p.Id);
            builder.Entity<QuestionCategory>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<QuestionCategory>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<QuestionCategory>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<QuestionCategory>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<Skill>().HasKey(p => p.Id);
            builder.Entity<Skill>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<Skill>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<Skill>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<Skill>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<Subject>().HasKey(p => p.Id);
            builder.Entity<Subject>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<Subject>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<Subject>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<Subject>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<Subject>().HasOne(p => p.SubjectCategory).WithMany(p => p.Subjects).HasForeignKey(p => p.SubjectCategoryId).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<SubjectCategory>().HasKey(p => p.Id);
            builder.Entity<SubjectCategory>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<SubjectCategory>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<SubjectCategory>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<SubjectCategory>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<Test>().HasKey(p => p.Id);
            builder.Entity<Test>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<Test>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<Test>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<Test>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<TestSubject>().HasKey(p => p.Id);
            builder.Entity<TestSubject>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<TestSubject>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<TestSubject>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<TestSubject>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<UserCertificate>().HasKey(p => p.Id);
            builder.Entity<UserCertificate>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<UserCertificate>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<UserCertificate>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<UserCertificate>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<UserPartitionInfo>().HasKey(p => p.Id);
            builder.Entity<UserPartitionInfo>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<UserPartitionInfo>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<UserPartitionInfo>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<UserPartitionInfo>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<UserReference>().HasKey(p => p.Id);
            builder.Entity<UserReference>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<UserReference>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<UserReference>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<UserReference>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<UserSkill>().HasKey(p => p.Id);
            builder.Entity<UserSkill>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<UserSkill>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<UserSkill>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<UserSkill>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            builder.Entity<UserTest>().HasKey(p => p.Id);
            builder.Entity<UserTest>().HasIndex(p => p.Id).IsUnique();
            builder.Entity<UserTest>().Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Entity<UserTest>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Entity<UserTest>().Property(p => p.UpdatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
