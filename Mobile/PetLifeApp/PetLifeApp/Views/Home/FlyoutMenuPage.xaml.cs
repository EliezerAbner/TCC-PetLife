using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetLifeApp.Models;
using PetLifeApp.Services;
using PetLifeApp.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuPage : ContentPage
    {
        private int teste = 0;
        private int clienteId;

        public FlyoutMenuPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("clienteId"))
            {
                string clientId = Application.Current.Properties["clienteId"] as string;
                clienteId = int.Parse(clientId);
            }

            try
            {
                ClienteController cc = new ClienteController();
                lblName.Text = cc.CarregarNome(clienteId);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            var pagAnterior = Navigation.NavigationStack.LastOrDefault();
            Navigation.PushAsync(new PageWelcome());
            Navigation.RemovePage(pagAnterior);
        }

        private void btnSair_Clicked(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", "" + ex.Message + "", "OK");
            }
        }
    }
}