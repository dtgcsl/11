using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;
using Web.Entities;

namespace Web.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);

            builder
                .Entity<Classroom>()
                .HasOne<Faculty>(c => c.Faculty)
                .WithMany(f => f.Classrooms)
                .HasForeignKey(c => c.FacultyId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .Entity<Result>()
                .HasOne<Student>(r => r.Student)
                .WithMany(s => s.Results)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .Entity<Result>()
                .HasOne<Subject>(r => r.Subject)
                .WithMany(s => s.Results)
                .HasForeignKey(r => r.SujectId)
                .OnDelete(DeleteBehavior.ClientCascade);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        private static void SeedData(ModelBuilder builder)
        {

            builder.Entity<Student>().HasData(
            new Student() { Id = Guid.NewGuid(), FullName = "Giang", Gender = false, Address = "Son La", Email = "dtg.csl@gmail.com" },
            new Student() { Id = Guid.NewGuid(), FullName = "Giang1", Gender = false, Address = "Son La", Email = "dtg.csl@gmail.com" },
            new Student() { Id = Guid.NewGuid(), FullName = "Giang2", Gender = false, Address = "Son La", Email = "dtg.csl@gmail.com" },
            new Student() { Id = Guid.NewGuid(), FullName = "Giang3", Gender = false, Address = "Son La", Email = "dtg.csl@gmail.com" },
            new Student() { Id = Guid.NewGuid(), FullName = "Giang3", Gender = false, Address = "Son La", Email = "dtg.csl@gmail.com" }
                );

            builder.Entity<Classroom>().HasData(
            new Classroom() { Id = Guid.NewGuid(), Name = "cntt1", HomeroomTeacher = "Tam" },
            new Classroom() { Id = Guid.NewGuid(), Name = "cntt2", HomeroomTeacher = "Tam" },
            new Classroom() { Id = Guid.NewGuid(), Name = "cntt3", HomeroomTeacher = "Tam" },
            new Classroom() { Id = Guid.NewGuid(), Name = "cntt4", HomeroomTeacher = "Tam" },
            new Classroom() { Id = Guid.NewGuid(), Name = "cntt5", HomeroomTeacher = "Tam" }
                );

            builder.Entity<Faculty>().HasData(
                new Faculty() { Id = Guid.NewGuid(), Name = "moi truong" },
                new Faculty() { Id = Guid.NewGuid(), Name = "dia chat" },
                new Faculty() { Id = Guid.NewGuid(), Name = "co dien" },
                new Faculty() { Id = Guid.NewGuid(), Name = "kinh te" },
                new Faculty() { Id = Guid.NewGuid(), Name = "mo" }
                );

            //builder.Entity<Result>().HasData(
            //    new Result() { Id = Guid.NewGuid(), StudentId = 1, ClassroomId = 1, SujectId = 1, Point = 1 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 1, Point = 8 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 3, ClassroomId = 3, SujectId = 1, Point = 5 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 4, ClassroomId = 2, SujectId = 1, Point = 6 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 5, ClassroomId = 1, SujectId = 1, Point = 4 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 1, Point = 9 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 1, Point = 4 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 1, Point = 4 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 1, Point = 4 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 1, Point = 3 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 2, Point = 4 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 3, Point = 2 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 4, Point = 1 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 5, Point = 4 },
            //    new Result() { Id = Guid.NewGuid(), StudentId = 2, ClassroomId = 1, SujectId = 2, Point = 4 }
            //    );

            builder.Entity<Subject>().HasData(
                new Subject() { Id = Guid.NewGuid(), Name = "c++", NumberOfCredits = 3 },
                new Subject() { Id = Guid.NewGuid(), Name = "c", NumberOfCredits = 3 },
                new Subject() { Id = Guid.NewGuid(), Name = "c#", NumberOfCredits = 3 },
                new Subject() { Id = Guid.NewGuid(), Name = "java", NumberOfCredits = 3 },
                new Subject() { Id = Guid.NewGuid(), Name = "js", NumberOfCredits = 3 },
                new Subject() { Id = Guid.NewGuid(), Name = "ctdl", NumberOfCredits = 3 }
                );
        }
    }
}
