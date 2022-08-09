using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blockchain_Basics
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Users.db";
        public static UserRepos database;
        public static UserRepos Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserRepos(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Njg1OTAzQDMyMzAyZTMyMmUzMGtEVStWSGpjMWVBY1FIOEVudjFLVVkyb3VBL3BzSC9mSG55ZER4Wm80ZXc9");
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
