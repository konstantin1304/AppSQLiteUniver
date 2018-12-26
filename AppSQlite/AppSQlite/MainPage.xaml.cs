using DB.Entities;
using System;
using System.Linq;
using Xamarin.Forms;

namespace AppSQlite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
               
        private async void ViewTeachers(object sender, EventArgs e)
        {
            TeacherListPage teacherListPage = new TeacherListPage();
            await Navigation.PushAsync(teacherListPage);
        }

        private async void ViewStudents(object sender, EventArgs e)
        {
            StudentListPage studentListPage = new StudentListPage();
            await Navigation.PushAsync(studentListPage);
        }
        
    }
}