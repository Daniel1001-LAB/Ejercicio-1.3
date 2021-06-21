using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2
{
    public partial class App : Application
        
    {
        public static string UBICACIONDB = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(String dblocal)
        {
            InitializeComponent();
            UBICACIONDB = dblocal;
            MainPage = new NavigationPage(new MainPage());
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
