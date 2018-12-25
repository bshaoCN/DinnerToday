using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dinner.Data;
using Dinner.Views;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Dinner
{
    public partial class App : Application
    {
        static  DishDatabase dishDatabase;
        public static DishDatabase DishDatabase
        {
            get
            {
                if (dishDatabase == null)
                {
                    dishDatabase = new DishDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),  "Dishes.db3"));
                }
                return dishDatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
