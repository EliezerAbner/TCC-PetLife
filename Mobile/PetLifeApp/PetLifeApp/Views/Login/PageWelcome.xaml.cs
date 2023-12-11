using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetLifeApp.Views.Configuracoes;
using PetLifeApp.Models;
using PetLifeApp.Views.Home;

[assembly: ExportFont("Roboto-Black.ttf", Alias = "Roboto-Black")]
[assembly: ExportFont("baloo-chettan-regular.ttf", Alias = "baloo-chettan-regular")]

namespace PetLifeApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageWelcome : ContentPage
    {
        public PageWelcome()
        {
            InitializeComponent();
        }

        private void btnNovoCliente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageNovoCliente());
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageLogin());
        }
    }
}