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
	public partial class StudPage : ContentPage
	{
		public StudPage ()
		{
			InitializeComponent ();
		}
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            StudPage studPage = new StudPage();
            await Navigation.PushAsync(studPage);
        }
    }
}