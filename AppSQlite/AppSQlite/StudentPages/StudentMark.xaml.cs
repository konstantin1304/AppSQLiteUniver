using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQlite.StudentPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentMark : ContentPage
	{
		public StudentMark ()
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
                           Mark = $"{m.StudentsMark}",
                           Teacher = $"{teachers.LastName}",
                           Subject = $"{ss.Name}"
                        }).ToList();

            studMark.ItemsSource = stud;
            base.OnAppearing();
            return;
        }
    }
}