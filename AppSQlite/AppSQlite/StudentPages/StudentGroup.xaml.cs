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
    public partial class StudentGroup : ContentPage
    {
        public StudentGroup()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var Unit = App.UnitOfWork;

            var stud = (from p in Unit.Phones.AllItems
                        join s in Unit.Students.AllItems
                            on p.Student.Id equals s.Id
                        join g in Unit.Groups.AllItems
                            on s.Group.Id equals g.Id
                        select new
                        {
                            Firstname = $"{s.FirstName}",
                            Lastname = $"{s.FirstName}",
                            Email = $"{s.Email}",
                            Phone = $"{p.StudentsPhone}"
                        }).ToList();

            studGroup.ItemsSource = stud;
            base.OnAppearing();
            return;
        }
    }
}