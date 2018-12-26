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
        private async void ViewFriends(object sender, EventArgs e)
        {
            FriendListPage friendListPage = new FriendListPage();
            await Navigation.PushAsync(friendListPage);
        }
        //private async void ViewStudents(object sender, EventArgs e)
        //{
        //    StudentListPage studentListPage = new StudentListPage();
        //    await Navigation.PushAsync(studentListPage);
        //}
        private async void ViewTeachers(object sender, EventArgs e)
        {
            TeacherListPage teacherListPage = new TeacherListPage();
            await Navigation.PushAsync(teacherListPage);
        }
        //protected override void OnAppearing()
        //{
        //    friendsList.ItemsSource = App.UnitOfWork.Freinds.AllItems.ToList();
        //    base.OnAppearing();
        //    //DisplayAlert("Alert", "Count of items:" + App.Database.AllItems.Count(), "OK");
        //}
        //// обработка нажатия элемента в списке
        //private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    Friend selectedFriend = (Friend)e.SelectedItem;
        //    FriendPage friendPage = new FriendPage();
        //    friendPage.BindingContext = selectedFriend;
        //    await Navigation.PushAsync(friendPage);
        //}
        //// обработка нажатия кнопки добавления
        //private async void CreateFriend(object sender, EventArgs e)
        //{
        //    Friend friend = new Friend();
        //    FriendPage friendPage = new FriendPage();
        //    friendPage.BindingContext = friend;
        //    await Navigation.PushAsync(friendPage);
        //}
    }
}