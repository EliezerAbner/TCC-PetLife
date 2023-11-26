using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetLifeApp.Models;
using PetLifeApp.Controller;
using Xamarin.Essentials;

namespace PetLifeApp.Views.Rastreadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMapa : ContentPage
    {
        public PageMapa(Rastreador rastreador)
        {
            InitializeComponent();

            DadosRastreador localizacao = new DadosRastreador();

            try
            {
                RastreadorController rc = new RastreadorController();
                localizacao = rc.Localizacao(rastreador.Identificador);

                //Pin local = new Pin()
                //{
                //    Label = rastreador.NomePet,
                //    Type = PinType.Generic,
                //    Position = new Position(Convert.ToDouble(localizacao.Latitude), Convert.ToDouble(localizacao.Longitude)),
                //    Tag = "localizaçao_pet",
                //};
                //map.Pins.Add(local);
                //map.MoveToRegion(MapSpan.FromCenterAndRadius(local.Position,
                //    Distance.FromMeters(5000)));
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}