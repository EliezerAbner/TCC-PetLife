using Microcharts;
using PetLifeApp.Controller;
using PetLifeApp.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Alimentadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAlimentadorInfo : ContentPage
	{
        private int alimentadorId;
        private ChartEntry[] entries;

        public PageAlimentadorInfo (Alimentador alInfo)
		{
            alimentadorId = 6;

			InitializeComponent ();
            CarregarChart();

			lblPageTitulo.Text = alInfo.NomeAlimentador;

            chartRacao.Chart = new BarChart
            {
                Entries = entries,
                LabelTextSize = 18,
                MaxValue = 1000
            };

            chartAgua.Chart = new BarChart
            {
                Entries = entries,
                LabelTextSize = 18,
                MaxValue = 1000
            };
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddAlimentador());
        }

        private void CarregarChart()
        {
            entries = new[] 
            {
                new ChartEntry(212)
                {
                    Label = "Domingo",
                    ValueLabel = "112",
                    Color = SKColor.Parse("#00BF63")
                },
                new ChartEntry(248)
                {
                    Label = "Segunda",
                    ValueLabel = "648",
                    Color = SKColor.Parse("#00BF63")
                },
                new ChartEntry(128)
                {
                    Label = "Terça",
                    ValueLabel = "428",
                    Color = SKColor.Parse("#00BF63")
                },
                new ChartEntry(514)
                {
                    Label = "Quarta",
                    ValueLabel = "214",
                    Color = SKColor.Parse("#00BF63")
                },
                new ChartEntry(514)
                {
                    Label = "Quinta",
                    ValueLabel = "214",
                    Color = SKColor.Parse("#00BF63")
                },
                new ChartEntry(514)
                {
                    Label = "Sexta",
                    ValueLabel = "214",
                    Color = SKColor.Parse("#00BF63")
                },
                new ChartEntry(514)
                {
                    Label = "Sábado",
                    ValueLabel = "214",
                    Color = SKColor.Parse("#00BF63")
                },
            };
        }

        private void btnCadHorario_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAddHorario_Clicked(object sender, EventArgs e)
        {
            frameAddHorario.IsVisible = true;
        }
    }
}