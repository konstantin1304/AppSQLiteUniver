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
	public partial class StudentPage : ContentPage
	{
		public StudentPage ()
		{
			InitializeComponent ();
		}

        private async void ViewSchedule(object sender, EventArgs e)
        {
            StudentListPage studentListPage = new StudentListPage();
            await Navigation.PushAsync(studentListPage);
        }

        private async void ViewMarks(object sender, EventArgs e)
        {
            StudentMark studentMark = new StudentMark();
            await Navigation.PushAsync(studentMark);
        }

        private async void ViewGroups(object sender, EventArgs e)
        {
            StudentGroup studentGroup = new StudentGroup();
            await Navigation.PushAsync(studentGroup);
        }
    }
}