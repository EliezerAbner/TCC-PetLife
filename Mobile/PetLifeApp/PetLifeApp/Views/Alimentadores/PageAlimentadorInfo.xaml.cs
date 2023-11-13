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
        private ChartEntry[] RacaoConsSem;
        private ChartEntry[] AguaConsSem;
        private int alimentadorId;

        public PageAlimentadorInfo (Alimentador alInfo)
		{
            alimentadorId = 6;

			InitializeComponent ();
            CarregarDados();

			lblPageTitulo.Text = alInfo.NomeAlimentador;

            chartRacao.Chart = new BarChart
            {
                Entries = RacaoConsSem,
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
            CalcularConsumo();

            float[] floatArray = { 100, 500, 1000, 1500, 2000, 2500, 3000 };


            RacaoConsSem = new ChartEntry[7];

            for ( int i = RacaoConsSem.Length; i == 0; i--)
            {
                ChartEntry ce = new ChartEntry(floatArray[i])
                {
                    Label = "Domingo",
                    ValueLabel = "214",
                    Color = SKColor.Parse("#00BF63")
                };

                RacaoConsSem[i] = ce;
            }
        }

        private void CalcularConsumo()
        {
            List<DadosAlimentador> listaDados = new List<DadosAlimentador>();
            List<DadosAlimentadorDia> consumoSemanal = new List<DadosAlimentadorDia>();

            AlimentadorController controller = new AlimentadorController();
            listaDados = controller.ObterDados(alimentadorId);

            DadosAlimentadorDia da = new DadosAlimentadorDia
            {
                QtdeConsumidaAgua = 
            };
        }
    }
}