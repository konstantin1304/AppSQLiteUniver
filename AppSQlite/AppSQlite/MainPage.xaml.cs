using AppSQlite.StudentPages;
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
            TeacherPage teacherPage = new TeacherPage();
            await Navigation.PushAsync(teacherPage);
        }

        private async void ViewStudents(object sender, EventArgs e)
        {
            StudentPage studPage = new StudentPage();
            await Navigation.PushAsync(studPage);
        }
        
    }
}