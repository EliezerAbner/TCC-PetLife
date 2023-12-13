using PetLifeApp.Services;
using PetLifeApp.Views.Home;
using PetLifeApp.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Configuracoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageConfiguracoes : ContentPage
    {
        private bool configIP;
        private int clienteId;

        public PageConfiguracoes()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("clienteId"))
            {
                string clientId = Application.Current.Properties["clienteId"] as string;
                clienteId = int.Parse(clientId);

                configIP = false;
                lblExperimental.TextColor = Color.FromHex("#737373");
                lblExcluirAlimentador.TextColor = Color.FromHex("#737373");
                lblExcluirRastreador.TextColor = Color.FromHex("#737373");
                lblEditarAlimentador.TextColor = Color.FromHex("#737373");
                lblReportarErro.TextColor = Color.FromHex("#737373");
                lblSobre.TextColor = Color.FromHex("#737373");
            }
        }

        public PageConfiguracoes(bool configIp)
        {
            InitializeComponent();

            configIP = configIp;

            lblEditarAlimentador.TextColor = Color.FromHex("#737373");
            lblEditarConta.TextColor = Color.FromHex("#737373");
            lblExcluirAlimentador.TextColor = Color.FromHex("#737373");
            lblExcluirConta.TextColor = Color.FromHex("#737373");
            lblExcluirRastreador.TextColor = Color.FromHex("#737373");
        }

        private void EditarConta(object sender, EventArgs e)
        {
            if (configIP != true) 
            {
                Navigation.PushAsync(new PageEditarConta());
            }
        }

        private async void ExcluirConta(object sender, EventArgs e)
        {
            if (configIP != true)
            {
                bool excluir = await DisplayAlert("Atenção", "Deseja mesmo excluir sua conta?", "Sim", "Não");

                if (excluir)
                {
                    try
                    {
                        ClienteController cc = new ClienteController();
                        cc.ExcluirCliente(clienteId);

                        var pagAnterior = Navigation.NavigationStack.LastOrDefault();
                        await Navigation.PushAsync(new PageWelcome());
                        Navigation.RemovePage(pagAnterior);
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Erro", $"{ex.Message}", "OK");
                    }
                }
            }
        }

        private void EditarAlimentador(object sender, EventArgs e)
        {
            if (configIP != true)
            {

            }
        }

        private void ExcluirAlimentador(object sender, EventArgs e)
        {
            if (configIP != true)
            {

            }
        }

        private void Experimental(object sender, EventArgs e)
        {
            if (configIP != false)
            {

            }
        }

        private void ReportarErro(object sender, EventArgs e)
        {
            if (configIP != true)
            {

            }
        }

        private void Sobre(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageSobre());
        }
    }
}