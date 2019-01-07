using AppSQlite.TeachersPages;
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
	public partial class TeacherPage : ContentPage
	{
		public TeacherPage ()
		{
			InitializeComponent ();
		}

        private async void ViewSchedule(object sender, EventArgs e)
        {
            TeacherListPage teacherListPage = new TeacherListPage();
            await Navigation.PushAsync(teacherListPage);
        }

        private async void ViewMarks(object sender, EventArgs e)
        {
            TeachMarkListPage teachMarkListPage = new TeachMarkListPage();
            await Navigation.PushAsync(teachMarkListPage);
        }
    }
}