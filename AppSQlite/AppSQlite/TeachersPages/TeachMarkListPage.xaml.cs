using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQlite.TeachersPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeachMarkListPage : ContentPage
    {
        public TeachMarkListPage()
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

            var teacher = (from m in Unit.Marks.AllItems
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
                               Name = $"{ss.Name}",
                               Group = $"{s.Group.Name}",
                               StudName = $"{s.LastName}",
                               Mark = $"{m.StudentsMark}"
                           }).ToList();

            teachMarkList.ItemsSource = teacher;
            base.OnAppearing();

        }
    }
}