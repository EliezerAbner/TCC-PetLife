using PetLifeApp.Controller;
using PetLifeApp.Models;
using PetLifeApp.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.GPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageGPS : ContentPage
    {
        private string rastreadorId;

        public PageGPS()
        {
            InitializeComponent();

            rastreadorId = "5040v1";

            DadosRastreador local = new DadosRastreador();
            RastreadorController rastreadorController = new RastreadorController();
            local = rastreadorController.Localizacao(rastreadorId);

            Pin pinPaulista = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(Convert.ToDouble(local.Latitude), Convert.ToDouble(local.Longitude)),
                Tag = "localizaçao_pet",

            };
            map.Pins.Add(pinPaulista);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinPaulista.Position,
                Distance.FromMeters(5000)));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageHome());
        }
    }
    
}