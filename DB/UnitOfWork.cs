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

        public GenericRepository<Audience> Audiences { get; }
        public GenericRepository<Department> Departments { get; }
        public GenericRepository<AudLect> AudLects { get; }
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
            Audiences = new GenericRepository<Audience>(database);
            Departments = new GenericRepository<Department>(database);
            AudLects = new GenericRepository<AudLect>(database);
            Groups = new GenericRepository<Group>(database);
            Lections = new GenericRepository<Lection>(database);
            Marks = new GenericRepository<Mark>(database);
            Phones = new GenericRepository<Phone>(database);
            Specialities = new GenericRepository<Speciality>(database);
            Students = new GenericRepository<Student>(database);
            Subjects = new GenericRepository<Subject>(database);
            Teachers = new GenericRepository<Teacher>(database);
            TeachSubjs = new GenericRepository<TeachSubj>(database);


            //Audiences.AddItem(new Audience());
            //Departments.AddItem(new Department());
            //AudLects.AddItem(new AudLect());
            //Groups.AddItem(new Group());
            //Lections.AddItem(new Lection());
            //Marks.AddItem(new Mark());
            //Phones.AddItem(new Phone());
            //Specialities.AddItem(new Speciality());
            //Students.AddItem(new Student());
            //Subjects.AddItem(new Subject());
            //Teachers.AddItem(new Teacher());
            //TeachSubjs.AddItem(new TeachSubj());
            List<Department> departments = new List<Department>
            {
                new Department { Name = "Software Testing", Teachers=new List<Teacher>() },
                new Department { Name = "Programming and System Analysis", Teachers= new List<Teacher>() }
            };

            List<Subject> subjects = new List<Subject>
            {
                new Subject { Name = "Calculus", TeachSubj = new List<TeachSubj>() },
                new Subject { Name = "Math Analysis" , TeachSubj = new List<TeachSubj>() },
                new Subject { Name = "Operation Systems" , TeachSubj = new List<TeachSubj>() },
                new Subject { Name = "Databases Theory" , TeachSubj = new List<TeachSubj>() },
                new Subject { Name = "Application Testing" , TeachSubj = new List<TeachSubj>() }
            };


            var teachers = new List<Teacher>
            {
            new Teacher { FirstName = "Max", LastName = "Frei", MiddleName = "Unknown", Department = departments[0], TeachSubj= new List<TeachSubj>() },
            new Teacher { FirstName = "Tyler", LastName = "Durden", MiddleName = "Unknown", Department = departments[0], TeachSubj= new List<TeachSubj>() },
            new Teacher { FirstName = "Dean", LastName = "Moriarty", MiddleName = "Unknown", Department = departments[1], TeachSubj= new List<TeachSubj>() },
            new Teacher { FirstName = "Sal", LastName = "Paradise", MiddleName = "Unknown", Department = departments[1], TeachSubj= new List<TeachSubj>() }
        };
            departments[0].Teachers.Add(teachers[0]);
            departments[0].Teachers.Add(teachers[1]);
            departments[1].Teachers.Add(teachers[2]);
            departments[1].Teachers.Add(teachers[3]);


            List<TeachSubj> teachSubjs = new List<TeachSubj>
            {
                new TeachSubj { Teacher= teachers[0],
                    Subject= subjects[0], AudLects= new List<AudLect>(), Marks= new List<Mark>() },
                new TeachSubj { Teacher= teachers[0],
                    Subject=  subjects[1], AudLects= new List<AudLect>(), Marks= new List<Mark>()},
                new TeachSubj { Teacher= teachers[1],
                    Subject=  subjects[2], AudLects= new List<AudLect>(), Marks= new List<Mark>()},
                new TeachSubj { Teacher= teachers[1],
                    Subject=  subjects[3], AudLects= new List<AudLect>(), Marks= new List<Mark>()},
                new TeachSubj { Teacher= teachers[2],
                    Subject=  subjects[4], AudLects= new List<AudLect>(), Marks= new List<Mark>()},
                new TeachSubj { Teacher= teachers[3],
                    Subject=  subjects[1], AudLects= new List<AudLect>(), Marks= new List<Mark>()},
                new TeachSubj { Teacher= teachers[3],
                    Subject=  subjects[3], AudLects= new List<AudLect>(), Marks= new List<Mark>()},
            };
            teachers[0].TeachSubj.Add(teachSubjs[0]);
            teachers[0].TeachSubj.Add(teachSubjs[1]);
            teachers[1].TeachSubj.Add(teachSubjs[2]);
            teachers[1].TeachSubj.Add(teachSubjs[3]);
            teachers[2].TeachSubj.Add(teachSubjs[4]);
            teachers[3].TeachSubj.Add(teachSubjs[5]);
            teachers[3].TeachSubj.Add(teachSubjs[6]);

            subjects[0].TeachSubj.Add(teachSubjs[0]);
            subjects[1].TeachSubj.Add(teachSubjs[1]);
            subjects[2].TeachSubj.Add(teachSubjs[2]);
            subjects[3].TeachSubj.Add(teachSubjs[3]);
            subjects[4].TeachSubj.Add(teachSubjs[4]);
            subjects[1].TeachSubj.Add(teachSubjs[5]);
            subjects[3].TeachSubj.Add(teachSubjs[6]);

            //TeachSubjs.AddItemsWithChildrenCascade(teachSubjs);
            

            List<Speciality> specialities = new List<Speciality>
            {
                new Speciality { Name = "Testing", Groups = new List<Group>() },
                new Speciality { Name = "Programming", Groups = new List<Group>() }
            };

            List<Group> groups = new List<Group>
            {
                new Group { Name = "T-18-1", Speciality=  specialities[0], AudLects= new List<AudLect>(), Students= new List<Student>()},
                new Group { Name = "T-18-2", Speciality=  specialities[0], AudLects= new List<AudLect>(), Students= new List<Student>()},
                new Group { Name = "P-17-1", Speciality=  specialities[1], AudLects= new List<AudLect>(), Students= new List<Student>()},
                new Group { Name = "P-18-1", Speciality=  specialities[1], AudLects= new List<AudLect>(), Students= new List<Student>()},
                new Group { Name = "P-18-2", Speciality=  specialities[1], AudLects= new List<AudLect>(), Students= new List<Student>()},
            };
            specialities[0].Groups.Add(groups[0]);
            specialities[0].Groups.Add(groups[1]);
            specialities[1].Groups.Add(groups[2]);
            specialities[1].Groups.Add(groups[3]);
            specialities[1].Groups.Add(groups[4]);


            List<Student> students = new List<Student>
            {
                new Student { FirstName = "Edward", MiddleName = "John", LastName = "Hedge",
                Address = "Toronto", Birthday = new DateTime(1993,10,10), Email = "ed_hedgehog@gmail.com",
                LogbookNumber = 00012, Group=groups[0], Phones= new List<Phone>(), Marks = new List<Mark>()},
                new Student { FirstName = "Margaret", MiddleName = "Ihorovna", LastName = "Starchenko",
                Address = "Dnipro", Birthday = new DateTime(1993,3,7), Email = "rita_starchenko@gmail.com",
                LogbookNumber = 00101, Group=groups[0], Phones= new List<Phone>(), Marks = new List<Mark>()},
                new Student { FirstName = "Peter", MiddleName = "Tomas", LastName = "Black",
                Address = "Ontario", Birthday = new DateTime(1992,1,30), Email = "ptblack@gmail.com",
                LogbookNumber = 00009, Group=groups[1], Phones= new List<Phone>(), Marks = new List<Mark>()},
                new Student { FirstName = "Tomas", MiddleName = "Unknown", LastName = "Spolding",
                Address = "Greentown", Birthday = new DateTime(1994,2,1), Email = "tomspolding12@gmail.com",
                LogbookNumber = 00132, Group=groups[1], Phones= new List<Phone>(), Marks = new List<Mark>()},
                new Student { FirstName = "Douglas", MiddleName = "Unknown", LastName = "Spolding",
                Address = "Greentown", Birthday = new DateTime(1991,4,23), Email = "great_doug4@gmail.com",
                LogbookNumber = 00002, Group=groups[2], Phones= new List<Phone>(), Marks = new List<Mark>()},
                new Student { FirstName = "Leo", MiddleName = "Unknown", LastName = "Aufmann",
                Address = "Greentown", Birthday = new DateTime(1971,9,2), Email = "happy_leo@gmail.com",
                LogbookNumber = 00012, Group=groups[3], Phones= new List<Phone>(), Marks = new List<Mark>()},
                new Student { FirstName = "Maxine", MiddleName = "Unknown", LastName = "Caulfield",
                Address = "Arcadia Bay", Birthday = new DateTime(1997,9,4), Email = "max_caulfield7@gmail.com",
                LogbookNumber = 00293, Group=groups[4], Phones= new List<Phone>(), Marks = new List<Mark>()},
                new Student { FirstName = "Victoria", MiddleName = "Unknown", LastName = "Chase",
                Address = "Arcadia Bay", Birthday = new DateTime(1997,1,15), Email = "vic_chase@gmail.com",
                LogbookNumber = 00220, Group=groups[4], Phones= new List<Phone>(), Marks = new List<Mark>()}
            };

            groups[0].Students.Add(students[0]);
            groups[0].Students.Add(students[1]);
            groups[1].Students.Add(students[2]);
            groups[1].Students.Add(students[3]);
            groups[2].Students.Add(students[4]);
            groups[3].Students.Add(students[5]);
            groups[4].Students.Add(students[6]);
            groups[4].Students.Add(students[7]);


            List<Phone> phones = new List<Phone>
            {
                new Phone{StudentsPhone = "0998894464", Student=students[0]},
                new Phone{StudentsPhone = "0998894465", Student=students[1]},
                new Phone{StudentsPhone = "0998894466", Student=students[2]},
                new Phone{StudentsPhone = "0998894467", Student=students[3]},
                new Phone{StudentsPhone = "0998893407", Student=students[4]},
                new Phone{StudentsPhone = "0992891462", Student=students[5]},
                new Phone{StudentsPhone = "0991094461", Student=students[6]},
                new Phone{StudentsPhone = "0990894460", Student=students[7]},
            };
            students[0].Phones.Add(phones[0]);
            students[1].Phones.Add(phones[1]);
            students[2].Phones.Add(phones[2]);
            students[3].Phones.Add(phones[3]);
            students[4].Phones.Add(phones[4]);
            students[5].Phones.Add(phones[5]);
            students[6].Phones.Add(phones[6]);
            students[7].Phones.Add(phones[7]);

            List<Mark> marks = new List<Mark>
            {
                new Mark{Student= students[0],
                             TeachSubj=  teachSubjs[0],
                            StudentsMark =95},
                new Mark{Student= students[0],
                             TeachSubj=  teachSubjs[1],
                            StudentsMark =87},
                new Mark{Student= students[0],
                             TeachSubj=  teachSubjs[2],
                            StudentsMark =89},
                new Mark{Student= students[0],
                             TeachSubj=  teachSubjs[3],
                            StudentsMark =75},
                //------
                new Mark{Student= students[1],
                             TeachSubj = teachSubjs[0],
                            StudentsMark = 67},
                new Mark{Student= students[1],
                             TeachSubj = teachSubjs[1],
                            StudentsMark = 71},
                new Mark{Student= students[1],
                             TeachSubj = teachSubjs[2],
                            StudentsMark = 92},
                new Mark{Student= students[1],
                             TeachSubj = teachSubjs[3],
                            StudentsMark = 77},
                //------
                new Mark{Student= students[2],
                             TeachSubj = teachSubjs[0],
                            StudentsMark = 98},
                new Mark{Student= students[2],
                             TeachSubj = teachSubjs[1],
                            StudentsMark = 88},
                new Mark{Student= students[2],
                             TeachSubj = teachSubjs[2],
                            StudentsMark = 68},
                new Mark{Student= students[2],
                             TeachSubj = teachSubjs[3],
                            StudentsMark = 73},
                //------
                new Mark{Student= students[3],
                             TeachSubj= teachSubjs[0],
                            StudentsMark = 67},
                new Mark{Student= students[3],
                             TeachSubj= teachSubjs[1],
                            StudentsMark = 68},
                new Mark{Student= students[3],
                             TeachSubj= teachSubjs[3],
                            StudentsMark = 73},
                new Mark{Student= students[3],
                             TeachSubj= teachSubjs[4],
                            StudentsMark = 99},
                //------
                new Mark{Student= students[4],
                             TeachSubj= teachSubjs[0] ,
                            StudentsMark = 67},
                new Mark{Student= students[4],
                             TeachSubj= teachSubjs[1],
                            StudentsMark = 68},
                new Mark{Student= students[4],
                             TeachSubj= teachSubjs[2],
                            StudentsMark = 73},
                new Mark{Student= students[4],
                             TeachSubj= teachSubjs[4],
                            StudentsMark = 99},

            };

            students[0].Marks.Add(marks[0]);
            students[0].Marks.Add(marks[1]);
            students[0].Marks.Add(marks[2]);
            students[0].Marks.Add(marks[3]);
            students[1].Marks.Add(marks[4]);
            students[1].Marks.Add(marks[5]);
            students[1].Marks.Add(marks[6]);
            students[1].Marks.Add(marks[7]);
            students[2].Marks.Add(marks[8]);
            students[2].Marks.Add(marks[9]);
            students[2].Marks.Add(marks[10]);
            students[2].Marks.Add(marks[11]);
            students[3].Marks.Add(marks[12]);
            students[3].Marks.Add(marks[13]);
            students[3].Marks.Add(marks[14]);
            students[3].Marks.Add(marks[15]);
            students[4].Marks.Add(marks[16]);
            students[4].Marks.Add(marks[17]);
            students[4].Marks.Add(marks[18]);
            students[4].Marks.Add(marks[19]);

            teachSubjs[0].Marks.Add(marks[0]);
            teachSubjs[1].Marks.Add(marks[1]);
            teachSubjs[2].Marks.Add(marks[2]);
            teachSubjs[3].Marks.Add(marks[3]);
            teachSubjs[0].Marks.Add(marks[4]);
            teachSubjs[1].Marks.Add(marks[5]);
            teachSubjs[2].Marks.Add(marks[6]);
            teachSubjs[3].Marks.Add(marks[7]);
            teachSubjs[0].Marks.Add(marks[8]);
            teachSubjs[1].Marks.Add(marks[9]);
            teachSubjs[2].Marks.Add(marks[10]);
            teachSubjs[3].Marks.Add(marks[11]);
            teachSubjs[0].Marks.Add(marks[12]);
            teachSubjs[1].Marks.Add(marks[13]);
            teachSubjs[3].Marks.Add(marks[14]);
            teachSubjs[4].Marks.Add(marks[15]);
            teachSubjs[0].Marks.Add(marks[16]);
            teachSubjs[1].Marks.Add(marks[17]);
            teachSubjs[2].Marks.Add(marks[18]);
            teachSubjs[4].Marks.Add(marks[19]);


            //----------Schedule------------------------------
            List<Audience> audiences = new List<Audience>
            {
                new Audience{ Name = "101", AudLects = new List<AudLect>()},
                new Audience{ Name = "102", AudLects = new List<AudLect>()},
                new Audience{ Name = "103", AudLects = new List<AudLect>()},
                new Audience{ Name = "201", AudLects = new List<AudLect>()},
                new Audience{ Name = "202", AudLects = new List<AudLect>()}
            };

            List<Lection> lections = new List<Lection>
            {
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,8,0,0),
                    Finish = new DateTime(1970,1,1,9,20,0), AudLects = new List<AudLect>()},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,9,35,0),
                    Finish = new DateTime(1970,1,1,10,55,0), AudLects = new List<AudLect>()},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,11,20,0),
                    Finish = new DateTime(1970,1,1,12,40,0), AudLects = new List<AudLect>()},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,12,55,0),
                    Finish = new DateTime(1970,1,1,14,15,0), AudLects = new List<AudLect>()},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,14,30,0),
                    Finish = new DateTime(1970,1,1,15,50,0), AudLects = new List<AudLect>()},
                new Lection{Day = DayOfWeek.Monday,
                    Start = new DateTime(1970,1,1,16,5,0),
                    Finish = new DateTime(1970,1,1,17,25,0), AudLects = new List<AudLect>()},
            };

            List<AudLect> audLects = new List<AudLect>
            {
                new AudLect{Audience=audiences[0],
                             Lection=lections[0],
                             Group= groups[0],
                              TeachSubj= teachSubjs[0]},
                new AudLect{Audience=audiences[0],
                             Lection=lections[1],
                             Group= groups[0],
                              TeachSubj= teachSubjs[1]},
                new AudLect{Audience=audiences[0],
                             Lection=lections[2],
                             Group= groups[1],
                              TeachSubj= teachSubjs[2]},
                new AudLect{Audience=audiences[0],
                             Lection=lections[3],
                             Group= groups[1],
                              TeachSubj= teachSubjs[1]},
                new AudLect{Audience=audiences[0],
                             Lection=lections[4],
                             Group= groups[2],
                              TeachSubj= teachSubjs[1]}
            };

            teachSubjs[0].AudLects.Add(audLects[0]);
            teachSubjs[1].AudLects.Add(audLects[1]);
            teachSubjs[2].AudLects.Add(audLects[2]);
            teachSubjs[1].AudLects.Add(audLects[3]);
            teachSubjs[1].AudLects.Add(audLects[4]);

            groups[0].AudLects.Add(audLects[0]);
            groups[0].AudLects.Add(audLects[1]);
            groups[1].AudLects.Add(audLects[2]);
            groups[1].AudLects.Add(audLects[3]);
            groups[2].AudLects.Add(audLects[4]);

            lections[0].AudLects.Add(audLects[0]);
            lections[1].AudLects.Add(audLects[1]);
            lections[2].AudLects.Add(audLects[2]);
            lections[3].AudLects.Add(audLects[3]);
            lections[4].AudLects.Add(audLects[4]);

            audiences[0].AudLects.Add(audLects[0]);
            audiences[0].AudLects.Add(audLects[1]);
            audiences[0].AudLects.Add(audLects[2]);
            audiences[0].AudLects.Add(audLects[3]);
            audiences[0].AudLects.Add(audLects[4]);

            Audiences.AddItemsWithChildrenCascade(audiences);


            //Departments.AddItem(new Department { Name = "Software Testing "});
            //Departments.AddItem(new Department { Name = "Programming and System Analysis" });
            //Departments.SaveChanges();



            //Subjects.AddItem(new Subject { Name = "Calculus" });
            //Subjects.AddItem(new Subject { Name = "Math Analysis" });
            //Subjects.AddItem(new Subject { Name = "Operation Systems" });
            //Subjects.AddItem(new Subject { Name = "Databases Theory" });
            //Subjects.AddItem(new Subject { Name = "Application Testing" });
            //Subjects.SaveChanges();

            //Teachers.AddItem(new Teacher { FirstName = "Max", LastName = "Frei", MiddleName = "Unknown", Department = Departments.AllItems.ToList().FirstOrDefault(d => d.Id == 1) });
            //Teachers.AddItem(new Teacher { FirstName = "Tyler", LastName = "Durden", MiddleName = "Unknown", Department = Departments.AllItems.ToList().FirstOrDefault(d => d.Id == 1) });
            //Teachers.AddItem(new Teacher { FirstName = "Dean", LastName = "Moriarty", MiddleName = "Unknown", Department = Departments.AllItems.ToList().FirstOrDefault(d => d.Id == 2) });
            //Teachers.AddItem(new Teacher { FirstName = "Sal", LastName = "Paradise", MiddleName = "Unknown", Department = Departments.AllItems.ToList().FirstOrDefault(d => d.Id == 2) });
            //Teachers.SaveChanges();

            //List<TeachSubj> teachSubjs = new List<TeachSubj>
            //{
            //    new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
            //        Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 1)},
            //    new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
            //        Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 2)},
            //    new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
            //        Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 3)},
            //    new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
            //        Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 4)},
            //    new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
            //        Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 5)},
            //    new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
            //        Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 2)},
            //    new TeachSubj { Teacher = Teachers.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
            //        Subject = Subjects.AllItems.ToList().FirstOrDefault(s=>s.Id == 4)},
            //};
            //teachSubjs.ForEach(s => TeachSubjs.AddItem(s));
            //TeachSubjs.SaveChanges();

            //List<Speciality> specialities = new List<Speciality>
            //{
            //    new Speciality { Name = "Testing" },
            //    new Speciality { Name = "Programming" }
            //};
            //specialities.ForEach(s => Specialities.AddItem(s));
            //Specialities.SaveChanges();

            //List<Group> groups = new List<Group>
            //{
            //    new Group { Name = "T-18-1", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 1) },
            //    new Group { Name = "T-18-2", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 1) },
            //    new Group { Name = "P-17-1", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 2) },
            //    new Group { Name = "P-18-1", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 2) },
            //    new Group { Name = "P-18-2", Speciality = Specialities.AllItems.ToList().FirstOrDefault(s=>s.Id == 2) },
            //};
            //groups.ForEach(s => Groups.AddItem(s));
            //Groups.SaveChanges();

            //List<Student> students = new List<Student>
            //{
            //    new Student { FirstName = "Edward", MiddleName = "John", LastName = "Hedge",
            //    Address = "Toronto", Birthday = new DateTime(1993,10,10), Email = "ed_hedgehog@gmail.com",
            //    LogbookNumber = 00012, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 1)},
            //    new Student { FirstName = "Margaret", MiddleName = "Ihorovna", LastName = "Starchenko",
            //    Address = "Dnipro", Birthday = new DateTime(1993,3,7), Email = "rita_starchenko@gmail.com",
            //    LogbookNumber = 00101, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 1)},
            //    new Student { FirstName = "Peter", MiddleName = "Tomas", LastName = "Black",
            //    Address = "Ontario", Birthday = new DateTime(1992,1,30), Email = "ptblack@gmail.com",
            //    LogbookNumber = 00009, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 2)},
            //    new Student { FirstName = "Tomas", MiddleName = "Unknown", LastName = "Spolding",
            //    Address = "Greentown", Birthday = new DateTime(1994,2,1), Email = "tomspolding12@gmail.com",
            //    LogbookNumber = 00132, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 2)},
            //    new Student { FirstName = "Douglas", MiddleName = "Unknown", LastName = "Spolding",
            //    Address = "Greentown", Birthday = new DateTime(1991,4,23), Email = "great_doug4@gmail.com",
            //    LogbookNumber = 00002, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 3)},
            //    new Student { FirstName = "Leo", MiddleName = "Unknown", LastName = "Aufmann",
            //    Address = "Greentown", Birthday = new DateTime(1971,9,2), Email = "happy_leo@gmail.com",
            //    LogbookNumber = 00012, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 4)},
            //    new Student { FirstName = "Maxine", MiddleName = "Unknown", LastName = "Caulfield",
            //    Address = "Arcadia Bay", Birthday = new DateTime(1997,9,4), Email = "max_caulfield7@gmail.com",
            //    LogbookNumber = 00293, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 5)},
            //    new Student { FirstName = "Victoria", MiddleName = "Unknown", LastName = "Chase",
            //    Address = "Arcadia Bay", Birthday = new DateTime(1997,1,15), Email = "vic_chase@gmail.com",
            //    LogbookNumber = 00220, Group = Groups.AllItems.ToList().FirstOrDefault(g=>g.Id == 5)}
            //};
            //students.ForEach(s => Students.AddItem(s));
            //Students.SaveChanges();

            //List<Phone> phones = new List<Phone>
            //{
            //    new Phone{StudentsPhone = "0998894464", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1)},
            //    new Phone{StudentsPhone = "0998894465", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2)},
            //    new Phone{StudentsPhone = "0998894466", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3)},
            //    new Phone{StudentsPhone = "0998894467", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4)},
            //    new Phone{StudentsPhone = "0998893407", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5)},
            //    new Phone{StudentsPhone = "0992891462", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 6)},
            //    new Phone{StudentsPhone = "0991094461", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 7)},
            //    new Phone{StudentsPhone = "0990894460", Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 8)},
            //};
            //phones.ForEach(p => Phones.AddItem(p));
            //Phones.SaveChanges();

            //List<Mark> marks = new List<Mark>
            //{
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
            //                StudentsMark = 95},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
            //                StudentsMark = 87},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
            //                StudentsMark = 89},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
            //                StudentsMark = 75},
            //    //------
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
            //                StudentsMark = 67},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
            //                StudentsMark = 71},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
            //                StudentsMark = 92},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
            //                StudentsMark = 77},
            //    //------
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
            //                StudentsMark = 98},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
            //                StudentsMark = 88},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
            //                StudentsMark = 68},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
            //                StudentsMark = 73},
            //    //------
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
            //                StudentsMark = 67},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
            //                StudentsMark = 68},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 4),
            //                StudentsMark = 73},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 5),
            //                StudentsMark = 99},
            //    //------
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1),
            //                StudentsMark = 67},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2),
            //                StudentsMark = 68},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3),
            //                StudentsMark = 73},
            //    new Mark{Student = Students.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
            //                TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 5),
            //                StudentsMark = 99},

            //};
            //marks.ForEach(p => Marks.AddItem(p));
            //Marks.SaveChanges();

            ////----------Schedule------------------------------
            //List<Audience> audiences = new List<Audience>
            //{
            //    new Audience{ Name = "101"},
            //    new Audience{ Name = "102"},
            //    new Audience{ Name = "103"},
            //    new Audience{ Name = "201"},
            //    new Audience{ Name = "202"}
            //};
            //audiences.ForEach(s => Audiences.AddItem(s));
            //Audiences.SaveChanges();

            //List<Lection> lections = new List<Lection>
            //{
            //    new Lection{Day = DayOfWeek.Monday,
            //        Start = new DateTime(1970,1,1,8,0,0),
            //        Finish = new DateTime(1970,1,1,9,20,0)},
            //    new Lection{Day = DayOfWeek.Monday,
            //        Start = new DateTime(1970,1,1,9,35,0),
            //        Finish = new DateTime(1970,1,1,10,55,0)},
            //    new Lection{Day = DayOfWeek.Monday,
            //        Start = new DateTime(1970,1,1,11,20,0),
            //        Finish = new DateTime(1970,1,1,12,40,0)},
            //    new Lection{Day = DayOfWeek.Monday,
            //        Start = new DateTime(1970,1,1,12,55,0),
            //        Finish = new DateTime(1970,1,1,14,15,0)},
            //    new Lection{Day = DayOfWeek.Monday,
            //        Start = new DateTime(1970,1,1,14,30,0),
            //        Finish = new DateTime(1970,1,1,15,50,0)},
            //    new Lection{Day = DayOfWeek.Monday,
            //        Start = new DateTime(1970,1,1,16,5,0),
            //        Finish = new DateTime(1970,1,1,17,25,0)},
            //};
            //lections.ForEach(s => Lections.AddItem(s));
            //Lections.SaveChanges();

            //List<AudLect> audLects = new List<AudLect>
            //{
            //    new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                 Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                 Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                 TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 1)},
            //    new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                 Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
            //                 Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                 TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2)},
            //    new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                 Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
            //                 Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
            //                 TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 3)},
            //    new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                 Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 4),
            //                 Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 2),
            //                 TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2)},
            //    new AudLect{ Audience = Audiences.AllItems.ToList().FirstOrDefault(s=>s.Id == 1),
            //                 Lection = Lections.AllItems.ToList().FirstOrDefault(s=>s.Id == 5),
            //                 Group = Groups.AllItems.ToList().FirstOrDefault(s=>s.Id == 3),
            //                 TeachSubj = TeachSubjs.AllItems.ToList().FirstOrDefault(t=>t.Id == 2)}
            //};
            //audLects.ForEach(s => AudLects.AddItem(s));
            //AudLects.SaveChanges();

        }


    }
}
