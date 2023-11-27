using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using PetLifeApp.Models;
using PetLifeApp.Controller;
using System.Collections.Generic;

namespace PetLifeApp.Views.Rastreadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMapa : ContentPage
    {
        private Rastreador rastreador;
        private Pin local = new Pin();
        private DadosRastreador localizacao = new DadosRastreador();
        private Polyline pegadas = new Polyline();
        public PageMapa(Rastreador r)
        {
            InitializeComponent();

            rastreador = r;

            try
            {
                RastreadorController rc = new RastreadorController();
                localizacao = rc.Localizacao(rastreador.Identificador);

                local.Label = rastreador.NomePet;
                local.Type = PinType.Generic;
                local.Position = new Position(Convert.ToDouble(localizacao.Latitude), Convert.ToDouble(localizacao.Longitude));

                map.Pins.Add(local);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(local.Position,
                    Distance.FromMeters(200)));
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

        private void Atualizar(object sender, EventArgs e)
        {
            try
            {
                RastreadorController rc = new RastreadorController();
                localizacao = rc.Localizacao(rastreador.Identificador);

                local.Position = new Position(Convert.ToDouble(localizacao.Latitude), Convert.ToDouble(localizacao.Longitude));
                map.MoveToRegion(MapSpan.FromCenterAndRadius(local.Position,
                    Distance.FromMeters(200)));
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"Infelizmente, estamos com dificuldades de rastrear {rastreador.NomePet}. Erro: {ex.Message}", "OK");
                Navigation.PopAsync();
            }
        }

        private void TracarCaminho(object sender, EventArgs e)
        {
            try
            {
                List<DadosRastreador> linha = new List<DadosRastreador>();
                RastreadorController rc = new RastreadorController();
                linha = rc.Caminho(rastreador.Identificador);

                pegadas.StrokeColor = Color.FromHex("#00BF63");
                pegadas.StrokeWidth = 5;

                foreach(DadosRastreador r in linha)
                {
                    Position p = new Position(Convert.ToDouble(r.Latitude), Convert.ToDouble(r.Longitude));
                    pegadas.Geopath.Add(p);
                }

                map.MapElements.Add(pegadas);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"Infelizmente, estamos com dificuldades de rastrear {rastreador.NomePet}. Erro: {ex.Message}", "OK");
            }
        }

        private void AtualizarCaminho(object sender, EventArgs e)
        {
            List<DadosRastreador> linha = new List<DadosRastreador>();
            RastreadorController rc = new RastreadorController();
            linha = rc.Caminho(rastreador.Identificador);

            pegadas.Geopath.Clear();

            foreach (DadosRastreador r in linha)
            {
                Position p = new Position(Convert.ToDouble(r.Latitude), Convert.ToDouble(r.Longitude));
                pegadas.Geopath.Add(p);
            }
        }
    }
}