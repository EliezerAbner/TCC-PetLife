using PetLifeApp.Views.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PageWelcome());
            // Abre a main page em "PageWelcome" localizada em: view > login 
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
