using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentListPage : ContentPage
    {
        public StudentListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var Unit = App.UnitOfWork;

            var stud =
                            (from l in Unit.AudLects.AllItems
                             join g in Unit.Groups.AllItems
                                 on l.Group.Id equals g.Id
                             join ts in Unit.Lections.AllItems
                                 on l.LectId equals ts.Id
                             join a in Unit.Audiences.AllItems
                                 on l.AudId equals a.Id
                             join teas in Unit.TeachSubjs.AllItems
                                 on l.TeachSubj.Id equals teas.Id
                             join teachers in Unit.Teachers.AllItems
                                 on teas.TeacherId equals teachers.Id
                             join ss in Unit.Subjects.AllItems
                                 on teas.SubjId equals ss.Id
                             select new
                             {
                                 Group = $"{g.Name}",
                                 Day = $" {ts.Day}",
                                 TimeStart = $"{ts.Start.Hour} : {ts.Start.Minute}",
                                 TimeFinish = $"{ts.Finish.Hour} : {ts.Finish.Minute}",
                                 Aud = $"{a.Name}",
                                 Teacher = $"{teachers.LastName}",
                                 Subject = $"{ss.Name}"
                             }).ToList();

            studList.ItemsSource = stud;
            base.OnAppearing();
            return;

            Debug.WriteLine("All Groups");
            var groups = Unit.Groups.AllItems.ToList();
            foreach (var group in groups)
            {
                Debug.WriteLine($"{group.Id}|{group.Name}");
            }
            var items = Unit.Marks.AllItems.Join(Unit.Students.AllItems, o => o.StudId, i => i.Id, (o, i) => { return new { Name = $"{i.FirstName} {i.LastName}", Group = i.Group.Name, Subject = "NONE"/*o.TeachSubj.Subject.Name*/, Mark = o.StudentsMark, OId = o.StudId, IId = i.Id }; }).ToList();
            Debug.WriteLine("All items");
            foreach (var item in items)
            {
                Debug.WriteLine($"{item.IId}|{item.OId}|{item.Name}|{item.Mark}|{item.Group}|{item.Subject}");
            }

            studList.ItemsSource = items;
            base.OnAppearing();

        }
    }
}