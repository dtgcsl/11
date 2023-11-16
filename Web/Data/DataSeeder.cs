using Web.Entities;

namespace Web.Data
{
    public class DataSeeder
    {
        private readonly SchoolContext _schoolcontext;
        public DataSeeder(SchoolContext schoolContext)
        {
            _schoolcontext = schoolContext;
        }

        public void Seed()
        {
            if (!_schoolcontext.Students.Any())
            {
                Random random = new Random();

                var faculties = new List<Faculty>()
                {
                    new Faculty() {
                        Id = Guid.NewGuid(),
                        Name = "moi truong",
                        CreateAt = DateTime.Now,
                    },
                    new Faculty() {
                        Id = Guid.NewGuid(),
                        Name = "dia chat",
                        CreateAt = DateTime.Now,
                    },
                    new Faculty() {
                        Id = Guid.NewGuid(),
                        Name = "co dien",
                        CreateAt = DateTime.Now,
                    },
                    new Faculty() {
                        Id = Guid.NewGuid(),
                        Name = "kinh te",
                        CreateAt = DateTime.Now,
                    },
                    new Faculty() {
                        Id = Guid.NewGuid(),
                        Name = "mo",
                        CreateAt = DateTime.Now,
                    }
                };

                var classrooms = new List<Classroom>()
                {
                    new Classroom() {
                        Id = Guid.NewGuid(),
                        Name = "cntt1",
                        HomeroomTeacher = "Tam",
                        FacultyId = faculties[random.Next(0, faculties.Count)].Id,
                        CreateAt = DateTime.Now,
                    },
                    new Classroom() {
                        Id = Guid.NewGuid(),
                        Name = "cntt2",
                        HomeroomTeacher = "Tam",
                        FacultyId = faculties[random.Next(0, faculties.Count)].Id,
                        CreateAt = DateTime.Now,
                    },
                    new Classroom() {
                        Id = Guid.NewGuid(),
                        Name = "cntt3",
                        HomeroomTeacher = "Tam",
                        FacultyId = faculties[random.Next(0, faculties.Count)].Id,
                        CreateAt = DateTime.Now,
                    },
                    new Classroom() {
                        Id = Guid.NewGuid(),
                        Name = "cntt4",
                        HomeroomTeacher = "Tam",
                        FacultyId = faculties[random.Next(0, faculties.Count)].Id,
                        CreateAt = DateTime.Now,
                    },
                    new Classroom() {
                        Id = Guid.NewGuid(),
                        Name = "cntt5",
                        HomeroomTeacher = "Tam",
                        FacultyId = faculties[random.Next(0, faculties.Count)].Id,
                        CreateAt = DateTime.Now,
                    }
                };

                var students = new List<Student>()
                {
                    new Student() {
                        Id = Guid.NewGuid(),
                        FullName = "Giang",
                        Gender = false,
                        Address = "Son La",
                        Email = "dtg.csl@gmail.com",
                        ClassroomId = classrooms[random.Next(0,classrooms.Count)].Id,
                        CreateAt = DateTime.Now,
                    },
                    new Student() {
                        Id = Guid.NewGuid(),
                        FullName = "Giang1",
                        Gender = false,
                        Address = "Son La",
                        Email = "dtg.csl@gmail.com",
                        ClassroomId = classrooms[random.Next(0,classrooms.Count)].Id,
                        CreateAt = DateTime.Now,
                    },
                    new Student() {
                        Id = Guid.NewGuid(),
                        FullName = "Giang2",
                        Gender = false,
                        Address = "Son La",
                        Email = "dtg.csl@gmail.com",
                        ClassroomId = classrooms[random.Next(0,classrooms.Count)].Id,
                        CreateAt = DateTime.Now,
                    },
                    new Student() { 
                        Id = Guid.NewGuid(), 
                        FullName = "Giang3", 
                        Gender = false, 
                        Address = "Son La", 
                        Email = "dtg.csl@gmail.com",
                        ClassroomId = classrooms[random.Next(0,classrooms.Count)].Id,
                        CreateAt = DateTime.Now,
                    },
                    new Student() { 
                        Id = Guid.NewGuid(), 
                        FullName = "Giang3",
                        Gender = false,
                        Address = "Son La",
                        Email = "dtg.csl@gmail.com",
                        ClassroomId = classrooms[random.Next(0,classrooms.Count)].Id,
                        CreateAt = DateTime.Now,
                    }
                };


                var subjects = new List<Subject>()
                {
                    new Subject() {
                        Id = Guid.NewGuid(),
                        Name = "c++",
                        NumberOfCredits = 3,
                        CreateAt = DateTime.Now,
                    },
                    new Subject() {
                        Id = Guid.NewGuid(),
                        Name = "c",
                        NumberOfCredits = 3,
                        CreateAt = DateTime.Now,
                    },
                    new Subject() {
                        Id = Guid.NewGuid(),
                        Name = "c#",
                        NumberOfCredits = 3,
                        CreateAt = DateTime.Now,
                    },
                    new Subject() {
                        Id = Guid.NewGuid(),
                        Name = "java",
                        NumberOfCredits = 3,
                        CreateAt = DateTime.Now,
                    },
                    new Subject() {
                        Id = Guid.NewGuid(),
                        Name = "js", 
                        NumberOfCredits = 3,
                        CreateAt = DateTime.Now,
                    },
                    new Subject() {
                        Id = Guid.NewGuid(),
                        Name = "ctdl", 
                        NumberOfCredits = 3,
                        CreateAt = DateTime.Now,
                    }
                };

                

                var results = new List<Result>()
                {
                    new Result() { 
                        Id = Guid.NewGuid(),
                        StudentId = students[random.Next(0,students.Count)].Id,
                        SujectId = subjects[random.Next(0,subjects.Count)].Id,
                        Point = random.Next(0,10),
                        CreateAt = DateTime.Now,
                    },
                    new Result() {
                        Id = Guid.NewGuid(),
                        StudentId = students[random.Next(0,students.Count)].Id,
                        SujectId = subjects[random.Next(0,subjects.Count)].Id,
                        Point = random.Next(0,10),
                        CreateAt = DateTime.Now,
                    },
                    new Result() {
                        Id = Guid.NewGuid(),
                        StudentId = students[random.Next(0,students.Count)].Id,
                        SujectId = subjects[random.Next(0,subjects.Count)].Id,
                        Point = random.Next(0,10),
                        CreateAt = DateTime.Now,
                    },
                    new Result() {
                        Id = Guid.NewGuid(),
                        StudentId = students[random.Next(0,students.Count)].Id,
                        SujectId = subjects[random.Next(0,subjects.Count)].Id,
                        Point = random.Next(0,10),
                        CreateAt = DateTime.Now,
                    },
                    new Result() {
                        Id = Guid.NewGuid(),
                        StudentId = students[random.Next(0,students.Count)].Id,
                        SujectId = subjects[random.Next(0,subjects.Count)].Id,
                        Point = random.Next(0,10),
                        CreateAt = DateTime.Now,
                    },
                };

                _schoolcontext.Students.AddRange(students);
                _schoolcontext.Classrooms.AddRange(classrooms);
                _schoolcontext.Faculties.AddRange(faculties);
                _schoolcontext.Subjects.AddRange(subjects);
                _schoolcontext.Results.AddRange(results);
                _schoolcontext.SaveChanges();

            }
        }
    }
}