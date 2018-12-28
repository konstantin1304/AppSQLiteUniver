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
		public StudentListPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            var Unit = App.UnitOfWork;
            var stud = (from m in Unit.Marks.AllItems
                        join s in Unit.Students.AllItems
                        on m.Student.Id equals s.Id
                        join ts in Unit.TeachSubjs.AllItems
                        on m.TeachSubj.Id equals ts.Id
                        join teachers in Unit.Teachers.AllItems
                        on ts.Teacher.Id equals teachers.Id
                        join ss in Unit.Subjects.AllItems
                        on ts.SubjId equals ss.Id
                        select new
                        {
                            //teachers.Id,
                            //m.StudentsMark,
                            //Group = s.Group.Name,
                            //GroupId = s.Group.Id,
                            //s.LastName,
                            //ss.Name


                            Name = $"{s.LastName} {s.FirstName}",
                            Group = $"{s.Group.Name}",
                            Subject = $"{ss.Name}",
                            Mark = $"{m.StudentsMark}"

                        }).ToList();

            studList.ItemsSource = stud;//Unit.Marks.AllItems.Join(Unit.Students.AllItems, o => o.StudId, i => i.Id, (o, i) => { return new { Name = $"{i.FirstName} {i.LastName}", Group = i.Group.Name, Subject = "NONE"/*o.TeachSubj.Subject.Name*/,Mark=o.StudentsMark, OId=o.StudId, IId=i.Id}; });//stud;
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

            studList.ItemsSource = items;//Unit.Marks.AllItems.Join(Unit.Students.AllItems, o => o.StudId, i => i.Id, (o, i) => { return new { Name = $"{i.FirstName} {i.LastName}", Group = i.Group.Name, Subject = "NONE"/*o.TeachSubj.Subject.Name*/,Mark=o.StudentsMark, OId=o.StudId, IId=i.Id}; });//stud;
            base.OnAppearing();

        }
    }
}