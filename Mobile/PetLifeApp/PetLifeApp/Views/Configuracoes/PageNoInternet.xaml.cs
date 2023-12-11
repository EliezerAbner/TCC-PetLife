using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetLifeApp.Views.Login;

namespace PetLifeApp.Views.Configuracoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageNoInternet : ContentPage
    {
        public PageNoInternet()
        {
            InitializeComponent();
            Connectivity.ConnectivityChanged += ConnectivityChangedHandler;
        }

        private void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var pagAnterior = Navigation.NavigationStack.LastOrDefault();
                Navigation.PushAsync(new PageWelcome());
                Navigation.RemovePage(pagAnterior);
            }
        }
    }
}