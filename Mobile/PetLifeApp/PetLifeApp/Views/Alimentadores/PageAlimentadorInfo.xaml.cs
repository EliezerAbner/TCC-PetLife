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

        public PageAlimentadorInfo (Alimentador alInfo)
		{
            alimentadorId = 6;

			InitializeComponent ();
            

			lblPageTitulo.Text = alInfo.NomeAlimentador;

            var entries = new[]
{
    new ChartEntry(212)
    {
        Label = "UWP",
        ValueLabel = "112",
        Color = SKColor.Parse("#2c3e50")
    },
    new ChartEntry(248)
    {
        Label = "Android",
        ValueLabel = "648",
        Color = SKColor.Parse("#77d065")
    },
    new ChartEntry(128)
    {
        Label = "iOS",
        ValueLabel = "428",
        Color = SKColor.Parse("#b455b6")
    },
    new ChartEntry(514)
    {
        Label = "Forms",
        ValueLabel = "214",
        Color = SKColor.Parse("#3498db")
    }
};

            chartRacao.Chart = new BarChart
            {
                Entries = entries,
                LabelTextSize = 18,
                MaxValue = 3000
            };
		}

        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddAlimentador());
        }


    }
}