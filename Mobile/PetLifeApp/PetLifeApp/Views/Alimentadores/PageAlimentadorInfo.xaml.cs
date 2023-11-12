using Microcharts;
using PetLifeApp.Controller;
using PetLifeApp.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Alimentadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAlimentadorInfo : ContentPage
	{
        private ChartEntry[] EntradaRacao;

        public PageAlimentadorInfo (Alimentador alInfo)
		{
			InitializeComponent ();
            test();

			lblPageTitulo.Text = alInfo.NomeAlimentador;

            chartRacao.Chart = new BarChart
            {
                Entries = EntradaRacao,
                LabelTextSize = 18,
                MaxValue = 3000
            };
		}

        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddAlimentador());
        }


        private void CarregarDados()
        {
            AlimentadorController controller = new AlimentadorController();
            controller.ObterDados();

            float[] floatArray = { 100, 500, 1000, 1500, 2000, 2500, 3000 };

            EntradaRacao = new ChartEntry[7];

            for (int i = 0; i < EntradaRacao.Length; i++)
            {
                ChartEntry ce = new ChartEntry(floatArray[i])
                {
                    Label = "Domingo",
                    ValueLabel = "214",
                    Color = SKColor.Parse("#00BF63")
                };

                EntradaRacao[i] = ce;
            }
        }

        private readonly ChartEntry[] entriesAgua = new[]
        {
            new ChartEntry(3000)
            {
                Label = "Domingo",
                ValueLabel = "214",
                Color = SKColor.Parse("#00BF63")
            },
            new ChartEntry(3000)
            {
                Label = "Segunda",
                ValueLabel = "112",
                Color = SKColor.Parse("#00BF63")
            },
            new ChartEntry(3000)
            {
                Label = "Terça",
                ValueLabel = "648",
                Color = SKColor.Parse("#00BF63")
            },
            new ChartEntry(3000)
            {
                Label = "Quarta",
                ValueLabel = "428",
                Color = SKColor.Parse("#00BF63")
            },
            new ChartEntry(3000)
            {
                Label = "Quinta",
                ValueLabel = "214",
                Color = SKColor.Parse("#00BF63")
            },
            new ChartEntry(3000)
            {
                Label = "Sexta",
                ValueLabel = "214",
                Color = SKColor.Parse("#00BF63")
            },
            new ChartEntry(3000)
            {
                Label = "Sábado",
                ValueLabel = "214",
                Color = SKColor.Parse("#00BF63")
            }
        };
    }
}