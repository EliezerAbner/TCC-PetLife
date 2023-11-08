using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetLifeApp.Views.Compra;

namespace PetLifeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PageAnuncio());
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
