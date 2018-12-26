
using DB;
using DB.Common;
using DB.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppSQlite
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Users.db";
        private static UnitOfWork unitOfWork;

        public static UnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork(DependencyService.Get<ISQLite>().GetDatabasePath(DATABASE_NAME));
                }
                return unitOfWork;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}