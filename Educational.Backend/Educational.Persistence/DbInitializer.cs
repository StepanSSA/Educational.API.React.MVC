using Educational.Domein;

namespace Educational.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(EducationalDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            Seed(dbContext);
        }

        private static void Seed(EducationalDbContext dbContext)
        {
            if (dbContext.Courses.Any())
                return;

            FillingFields();

            if (!dbContext.Teachers.Any())
                dbContext.Teachers.Add(teacher);

            if (!dbContext.Courses.Any())
                dbContext.Courses.AddRange(Courses);

            if (!dbContext.Lessons.Any())
            {
                dbContext.Lessons.AddRange(LessonForFirstCourse);
                dbContext.Lessons.AddRange(LessonForSecondCourse);
                dbContext.Lessons.AddRange(LessonForThirdCourse);
            }

            if (!dbContext.PurchasedCourses.Any())
                dbContext.PurchasedCourses.AddRange(purchasedCourses);

            if(!dbContext.Students.Any())
                dbContext.Students.Add(student);

            if (!dbContext.Homeworks.Any())
                dbContext.Homeworks.Add(homework);

            dbContext.SaveChanges();
        }


        private static void FillingFields()
        {
            foreach (var item in LessonForFirstCourse)
            {
                Courses[0].Lessons.Add(item);
                item.Course = Courses[0];
            }

            foreach (var item in LessonForSecondCourse)
            {
                Courses[1].Lessons.Add(item);
                item.Course = Courses[1];
            }

            foreach (var item in LessonForThirdCourse)
            {
                Courses[2].Lessons.Add(item);
                item.Course = Courses[2];
            }

            foreach (var item in Courses)
            {
                item.Teacher = teacher;
                teacher.Course.Add(item);
            }

            purchasedCourses[0].Course = Courses[0];
            purchasedCourses[0].Student = student;
            purchasedCourses[1].Course = Courses[1];
            purchasedCourses[1].Student = student;

            student.PurchasedCourses.Add(purchasedCourses[0]);
            student.PurchasedCourses.Add(purchasedCourses[1]);
            student.Homeworks.Add(homework);

            homework.Student = student;
            homework.Lesson = LessonForFirstCourse[0];
            LessonForFirstCourse[0].Homeworks.Add(homework);
            
        }


        private static List<Lesson> LessonForFirstCourse = new List<Lesson>()
        {
            new Lesson
                    {
                        Description = "Первый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Введение",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 1
                    },
            new Lesson
                    {
                        Description = "Второй урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Основый",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 2
                    },
            new Lesson
                    {
                        Description = "Третий урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Практика",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 3
                    },
            new Lesson
                    {
                        Description = "Четвёртый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Повышение уровня",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 4
                    },
            new Lesson
                    {
                        Description = "Пятый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Практика",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 5
                    },
            new Lesson
                    {
                        Description = "Завершающий урок",
                        Id = Guid.NewGuid(),
                        Name = "Экзамен",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 6
                    }
        };

        private static List<Lesson> LessonForSecondCourse = new List<Lesson>()
        {
            new Lesson
                    {
                        Description = "Первый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Введение",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 1
                    },
            new Lesson
                    {
                        Description = "Второй урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Основый",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 2
                    },
            new Lesson
                    {
                        Description = "Третий урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Практика",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 3
                    },
            new Lesson
                    {
                        Description = "Четвёртый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Повышение уровня",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 4
                    },
            new Lesson
                    {
                        Description = "Пятый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Практика",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 5
                    },
            new Lesson
                    {
                        Description = "Завершающий урок",
                        Id = Guid.NewGuid(),
                        Name = "Экзамен",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 6
                    }
        };

        private static List<Lesson> LessonForThirdCourse = new List<Lesson>()
        {
            new Lesson
                    {
                        Description = "Первый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Введение",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 1
                    },
            new Lesson
                    {
                        Description = "Второй урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Основый",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 2
                    },
            new Lesson
                    {
                        Description = "Третий урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Практика",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 3
                    },
            new Lesson
                    {
                        Description = "Четвёртый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Повышение уровня",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 4
                    },
            new Lesson
                    {
                        Description = "Пятый урок цикла",
                        Id = Guid.NewGuid(),
                        Name = "Практика",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 5
                    },
            new Lesson
                    {
                        Description = "Завершающий урок",
                        Id = Guid.NewGuid(),
                        Name = "Экзамен",
                        VideoPath = "",
                        Homeworks = new List<Homework>(),
                        Number = 6
                    }
        };

        private static List<Course> Courses = new List<Course>()
        {
                new Course()
                {
                    Id = Guid.NewGuid(),
                    Confirmed = false,
                    Description = "Вы изучите основы программирования и основные концепции компьютерных наук, цифровые технологии, программное обеспечение, операционные системы, базы данных, системы аналитики, языки программирования и многое другое.",
                    Name = "ИТ-инженер",
                    Price = 41040,
                    Duration = 6,
                },
                new Course()
                {
                    Id = Guid.NewGuid(),
                    Confirmed = false,
                    Description = "Вы на практике изучите программирование, алгоритмы, базы данных и другие предметы инженерной базы",
                    Name = "Разработчик: старт в ИТ с нуля до Junior",
                    Price = 41040,
                    Duration = 6,
                },
                new Course()
                {
                    Id = Guid.NewGuid(),
                    Confirmed = false,
                    Description = "Вы изучите основы программирования и основные концепции компьютерных наук, цифровые технологии, программное обеспечение, операционные системы, базы данных, системы аналитики, языки программирования и многое другое",
                    Name = "Разработчик: старт в ИТ с нуля до Pro",
                    Price = 30040,
                    Duration = 6,
                },
        };

        private static Teacher teacher = new Teacher
        {
            UserId = new Guid("72743aab-00ee-4208-8056-260cea461cb2"),
            Name = "Учитель",
            Email = "Teacher@mail.ru",
            Lastname = "Училов"
        };

        private static List<PurchasedCourses> purchasedCourses = new List<PurchasedCourses>()
            {
                new PurchasedCourses
                {
                    Id = Guid.NewGuid(),
                    date = DateTime.Now,
                },
                new PurchasedCourses
                {
                    Id = Guid.NewGuid(),
                    date = DateTime.Now,
                },
            };

        private static Student student = new Student()
        {
            UserId = new Guid("70d55eef-177e-4486-9bf7-e3b9f31cb97b"),
            Name = "Иван",
            Email = "Ivan@mail.ru",
            Lastname = "Иванов"
        };

        private static Homework homework = new Homework()
        {
            Id = Guid.NewGuid(),
            FilePath = "",
            date = DateTime.Now,
            Score = 5,
        };
    }
}
