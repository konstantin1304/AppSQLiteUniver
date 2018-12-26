using DB.Entities;
using System;
using System.Linq;
using Xamarin.Forms;

namespace AppSQlite
{
    public partial class FriendListPage : ContentPage
    {
        public FriendListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.UnitOfWork.Freinds.AllItems.ToList();
            base.OnAppearing();
            //DisplayAlert("Alert", "Count of items:" + App.Database.AllItems.Count(), "OK");
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.SelectedItem;
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }
    }
}