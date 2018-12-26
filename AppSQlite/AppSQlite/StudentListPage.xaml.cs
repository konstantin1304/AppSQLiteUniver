using System;
using System.Collections.Generic;
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
                        on ts.TeacherId equals teachers.Id
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
                        

                        Name = $"{m.StudentsMark} {s.Group.Name} {s.LastName} {ss.Name}"

             }).ToList();

            studList.ItemsSource = stud;
            base.OnAppearing();

        }
    }
}