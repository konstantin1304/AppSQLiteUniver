using DB.Common;
using DB.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB
{
    public class UnitOfWork
    {
        SQLiteConnection database;

        public GenericRepository<Friend> Freinds { get; }
        public GenericRepository<Audience> Audiences { get; }
        public GenericRepository<Department> Departments { get; }
        public GenericRepository<AudLect> AudLects { get; }
        public GenericRepository<Friend> Friends { get; }
        public GenericRepository<Group> Groups { get; }
        public GenericRepository<Lection> Lections { get; }
        public GenericRepository<Mark> Marks { get; }
        public GenericRepository<Phone> Phones { get; }
        public GenericRepository<Speciality> Specialities { get; }
        public GenericRepository<Student> Students { get; }
        public GenericRepository<Subject> Subjects { get; }
        public GenericRepository<Teacher> Teachers { get; }
        public GenericRepository<TeachSubj> TeachSubjs { get; }
        public UnitOfWork(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            Freinds = new GenericRepository<Friend>(database);
            Audiences = new GenericRepository<Audience>(database);
            Departments = new GenericRepository<Department>(database);
            AudLects = new GenericRepository<AudLect>(database);
            Friends = new GenericRepository<Friend>(database);
            Groups = new GenericRepository<Group>(database);
            Lections = new GenericRepository<Lection>(database);
            Marks = new GenericRepository<Mark>(database);
            Phones = new GenericRepository<Phone>(database);
            Specialities = new GenericRepository<Speciality>(database);
            Students = new GenericRepository<Student>(database);
            Subjects = new GenericRepository<Subject>(database);
            Teachers = new GenericRepository<Teacher>(database);
            TeachSubjs = new GenericRepository<TeachSubj>(database);


            Departments.AddItem(new Department { Name = "Software Testing " });
            Departments.AddItem(new Department { Name = "Programming and System Analysis" });
            Departments.SaveChanges();

            Freinds.AddItem(new Friend { Name = "Clothing", Email = "asdf@adf.ua" });
            Freinds.SaveChanges();

            Subjects.AddItem(new Subject { Name = "Calculus" });
            Subjects.AddItem(new Subject { Name = "Math Analysis" });
            Subjects.AddItem(new Subject { Name = "Operation Systems" });
            Subjects.AddItem(new Subject { Name = "Databases Theory" });
            Subjects.AddItem(new Subject { Name = "Application Testing" });
            Freinds.SaveChanges();

            Teachers.AddItem(new Teacher { FirstName = "Max", LastName = "Frei", MiddleName = "Unknown", Department = Departments.AllItems.ToList().FirstOrDefault(d => d.Id == 1) });
            Teachers.AddItem(new Teacher { FirstName = "Tyler", LastName = "Durden", MiddleName = "Unknown", Department = Departments.AllItems.ToList().FirstOrDefault(d => d.Id == 1) });
            Teachers.AddItem(new Teacher { FirstName = "Dean", LastName = "Moriarty", MiddleName = "Unknown", Department = Departments.AllItems.ToList().FirstOrDefault(d => d.Id == 2) });
            Teachers.AddItem(new Teacher { FirstName = "Sal", LastName = "Paradise", MiddleName = "Unknown", Department = Departments.AllItems.ToList().FirstOrDefault(d => d.Id == 2) });
            Teachers.SaveChanges();

            List<TeachSubj> teachSubjs = new List<TeachSubj>
            {
                new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
                    Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 1)},
                new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
                    Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 2)},
                new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
                    Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 3)},
                new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
                    Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 4)},
                new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
                    Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 5)},
                new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
                    Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 2)},
                new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
                    Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 4)},
            };
            teachSubjs.ForEach(s => TeachSubjs.AddItem(s));
            TeachSubjs.SaveChanges();

            List<Speciality> specialities = new List<Speciality>
            {
                new Speciality { Name = "Testing" },
                new Speciality { Name = "Programming" }
            };
            specialities.ForEach(s => Specialities.AddItem(s));
            Specialities.SaveChanges();

            List<Group> groups = new List<Group>
            {
                new Group { Name = "T-18-1", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 1) },
                new Group { Name = "T-18-2", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 1) },
                new Group { Name = "P-17-1", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 2) },
                new Group { Name = "P-18-1", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 2) },
                new Group { Name = "P-18-2", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 2) },
            };
            groups.ForEach(s => Groups.AddItem(s));
            Groups.SaveChanges();

            List<Student> students = new List<Student>
            {
                new Student { FirstName = "Edward", MiddleName = "John", LastName = "Hedge",
                Address = "Toronto", Birthday = new DateTime(1993,10,10), Email = "ed_hedgehog@gmail.com",
                LogbookNumber = 00012, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 1)},
                new Student { FirstName = "Margaret", MiddleName = "Ihorovna", LastName = "Starchenko",
                Address = "Dnipro", Birthday = new DateTime(1993,3,7), Email = "rita_starchenko@gmail.com",
                LogbookNumber = 00101, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 1)},
                new Student { FirstName = "Peter", MiddleName = "Tomas", LastName = "Black",
                Address = "Ontario", Birthday = new DateTime(1992,1,30), Email = "ptblack@gmail.com",
                LogbookNumber = 00009, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 2)},
                new Student { FirstName = "Tomas", MiddleName = "Unknown", LastName = "Spolding",
                Address = "Greentown", Birthday = new DateTime(1994,2,1), Email = "tomspolding12@gmail.com",
                LogbookNumber = 00132, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 2)},
                new Student { FirstName = "Douglas", MiddleName = "Unknown", LastName = "Spolding",
                Address = "Greentown", Birthday = new DateTime(1991,4,23), Email = "great_doug4@gmail.com",
                LogbookNumber = 00002, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 3)},
                new Student { FirstName = "Leo", MiddleName = "Unknown", LastName = "Aufmann",
                Address = "Greentown", Birthday = new DateTime(1971,9,2), Email = "happy_leo@gmail.com",
                LogbookNumber = 00012, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 4)},
                new Student { FirstName = "Maxine", MiddleName = "Unknown", LastName = "Caulfield",
                Address = "Arcadia Bay", Birthday = new DateTime(1997,9,4), Email = "max_caulfield7@gmail.com",
                LogbookNumber = 00293, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 5)},
                new Student { FirstName = "Victoria", MiddleName = "Unknown", LastName = "Chase",
                Address = "Arcadia Bay", Birthday = new DateTime(1997,1,15), Email = "vic_chase@gmail.com",
                LogbookNumber = 00220, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 5)}
            };
            students.ForEach(s => Students.AddItem(s));
            Students.SaveChanges();

            List<Phone> phones = new List<Phone>
            {
                new Phone{StudentsPhone = "0998894464", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1)},
                new Phone{StudentsPhone = "0998894465", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2)},
                new Phone{StudentsPhone = "0998894466", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3)},
                new Phone{StudentsPhone = "0998894467", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4)},
                new Phone{StudentsPhone = "0998893407", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5)},
                new Phone{StudentsPhone = "0992891462", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 6)},
                new Phone{StudentsPhone = "0991094461", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 7)},
                new Phone{StudentsPhone = "0990894460", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 8)},
            };
            phones.ForEach(p => Phones.AddItem(p));
            Phones.SaveChanges();

            List<Mark> marks = new List<Mark>
            {
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 95},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 87},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
                            StudentsMark = 89},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
                            StudentsMark = 75},
                //------
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 67},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 71},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
                            StudentsMark = 92},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
                            StudentsMark = 77},
                //------
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 98},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 88},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
                            StudentsMark = 68},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
                            StudentsMark = 73},
                //------
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 67},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 68},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
                            StudentsMark = 73},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 5),
                            StudentsMark = 99},
                //------
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
                            StudentsMark = 67},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
                            StudentsMark = 68},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
                            StudentsMark = 73},
                new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
                            TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 5),
                            StudentsMark = 99},

            };
            marks.ForEach(p => Marks.AddItem(p));
            Marks.SaveChanges();

            //----------Schedule------------------------------
            List<Audience> audiences = new List<Audience>
            {
                new Audience{ Name = "101"},
                new Audience{ Name = "102"},
                new Audience{ Name = "103"},
                new Audience{ Name = "201"},
                new Audience{ Name = "202"}
            };
            audiences.ForEach(s => Audiences.AddItem(s));
            Audiences.SaveChanges();

            List<Lection> lections = new List<Lection>
            {
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,8,0,0),
                    Finish = new DateTime(1970,1,1,9,20,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,9,35,0),
                    Finish = new DateTime(1970,1,1,10,55,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,11,20,0),
                    Finish = new DateTime(1970,1,1,12,40,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,12,55,0),
                    Finish = new DateTime(1970,1,1,14,15,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,14,30,0),
                    Finish = new DateTime(1970,1,1,15,50,0)},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,16,5,0),
                    Finish = new DateTime(1970,1,1,17,25,0)},
            };
            lections.ForEach(s => Lections.AddItem(s));
            Lections.SaveChanges();

            List<AudLect> audLects = new List<AudLect>
            {
                new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                             Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                             Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                             TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1)},
                new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                             Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
                             Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                             TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2)},
                new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                             Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
                             Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
                             TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3)},
                new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                             Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
                             Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
                             TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2)},
                new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
                             Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
                             Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
                             TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2)}
            };
            audLects.ForEach(s => AudLects.AddItem(s));
            AudLects.SaveChanges();







        }


    }
}
