using PetLifeApp.Catalogo;
using PetLifeApp.Views.Configuracoes;
using PetLifeApp.Views.Login;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Connectivity.NetworkAccess == NetworkAccess.None || Connectivity.NetworkAccess == NetworkAccess.Local)
            {
                MainPage = new NavigationPage(new PageNoInternet());
            }
            else
            {
                MainPage = new NavigationPage(new PageWelcome());
            }  
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
