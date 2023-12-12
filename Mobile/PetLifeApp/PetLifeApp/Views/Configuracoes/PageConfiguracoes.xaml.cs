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

        public PageConfiguracoes()
        {
            InitializeComponent();

            configIP = false;
            lblExperimental.TextColor = Color.FromHex("#737373");
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

            }
        }

        private void ExcluirConta(object sender, EventArgs e)
        {
            if (configIP != true)
            {

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