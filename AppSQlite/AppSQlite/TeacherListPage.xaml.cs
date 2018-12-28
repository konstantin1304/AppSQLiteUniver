using DB.Entities;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace AppSQlite
{
    public partial class TeacherListPage : ContentPage
    {
        public TeacherListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            var Unit = App.UnitOfWork;

            foreach (var a in Unit.AudLects.AllItems)
            {
                Debug.WriteLine($"Id={a.Id} GroupID={a.Group?.Id}");
            }

            //foreach (var g in Unit.Groups.AllItems)
            //{
            //    Debug.WriteLine($"Id= {g.Id} GroupID={g.Group?.Id}");
            //}

            //foreach (var a in Unit.AudLects.AllItems)
            //{
            //    Debug.WriteLine(a.ToString());
            //}

            var teacher =
            (from l in Unit.AudLects.AllItems
             join g in Unit.Groups.AllItems
                 on l.Group.Id equals g.Id
             join ts in Unit.Lections.AllItems
                 on l.Lection.Id equals ts.Id
             join a in Unit.Audiences.AllItems
                 on l.Audience.Id equals a.Id
             join teas in Unit.TeachSubjs.AllItems
                 on l.TeachSubj.Id equals teas.Id
             join teachers in Unit.Teachers.AllItems
                 on teas.Teacher.Id equals teachers.Id
             join ss in Unit.Subjects.AllItems
                 on teas.Subject.Id equals ss.Id
             select new
             {
                 //l.Group.Id,
                 //TeachID=teachers.Id,
                 //Group = g.Name,
                 //ts.Day,
                 //ts.Start,
                 //ts.Finish,
                 //Audience = a.Name,
                 //Teacher = teachers.LastName + " " + teachers.FirstName,
                 //Subject = ss.Name

                 Name = $"{g.Name} {ts.Start} {ts.Finish} {a.Name} {teachers.LastName} {ss.Name}",
                 Day = $" {ts.Day}",
                 TimeStart = $"{ts.Start.Hour} : {ts.Start.Minute}",
                 TimeFinish = $"{ts.Finish.Hour} : {ts.Finish.Minute}",
                 Aud = $"{a.Name}",
                 TeacherName = $"{ss.Name}"

        }).ToList();

            teachList.ItemsSource = teacher;
            base.OnAppearing();
            
        }
       

    }
}