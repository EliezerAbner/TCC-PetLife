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
        private string alimentadorId;

        private decimal qtdeDisponivelRacao;
        private decimal qtdeDisponivelAgua;

        private ChartEntry[] dadosAgua = new ChartEntry[7];
        private ChartEntry[] dadosRacao = new ChartEntry[7];

        public PageAlimentadorInfo (Alimentador alInfo)
		{
            InitializeComponent();

            qtdeDisponivelAgua = 500;
            qtdeDisponivelRacao = 320;
            //---------------------------------

            alimentadorId = alInfo.Identificador;
            lblPageTitulo.Text = alInfo.NomeAlimentador;

            try
            {
                List<HorariosAlimentador> h = new List<HorariosAlimentador>();
                AlimentadorController controller = new AlimentadorController();
                h = controller.ListaHorarios(alimentadorId);

                if (h.Count > 0)
                {
                    lvHorarios.ItemsSource = h;

                    CarregarChart();
                }
                else
                {
                    lvHorarios.IsVisible = false;
                    frameAgua.IsVisible = false;
                    frameRacao.IsVisible = false;
                    slNoHorario.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK"); 
            }
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddAlimentador());
        }

        private void CarregarChart()
        {
            List<DadosAlimentador> dados = new List<DadosAlimentador>();
            int counter = 0;

            try
            {
                AlimentadorController ac = new AlimentadorController();
                dados = ac.ObterDados(alimentadorId);

                if (dados.Count == 7 )
                {
                    dadosAgua = new ChartEntry[dados.Count];
                    dadosRacao = new ChartEntry[dados.Count];

                    decimal[] mediaAgua = new decimal[dados.Count];
                    decimal[] mediaRacao = new decimal[dados.Count];

                    foreach (DadosAlimentador dado in dados)
                    {
                        ChartEntry racao = new ChartEntry((float)dado.QtdeConsumidaRacao)
                        {
                            Label = dado.Dia,
                            ValueLabel = Convert.ToString(dado.QtdeConsumidaRacao),
                            Color = SKColor.Parse("#00BF63")
                        };
                        dadosRacao[counter] = racao;
                        mediaRacao[counter] = dado.QtdeConsumidaRacao;

                        ChartEntry agua = new ChartEntry((float)dado.QtdeConsumidaAgua)
                        {
                            Label = dado.Dia,
                            ValueLabel = Convert.ToString(dado.QtdeConsumidaAgua),
                            Color = SKColor.Parse("#00BF63")
                        };
                        dadosAgua[counter] = agua;
                        mediaAgua[counter] = dado.QtdeConsumidaAgua;

                        counter++;
                    }

                    lblMediaAgua.Text = Convert.ToString(mediaAgua.Sum() / mediaAgua.Length);
                    lblMediaRacao.Text = Convert.ToString(mediaRacao.Sum() / mediaRacao.Length);

                    chartRacao.Chart = new BarChart
                    {
                        Entries = dadosRacao,
                        LabelOrientation = Orientation.Horizontal,
                        LabelTextSize = 20,
                        MaxValue = 3000
                    };

                    chartAgua.Chart = new BarChart
                    {
                        Entries = dadosAgua,
                        LabelOrientation = Orientation.Horizontal,
                        LabelTextSize = 24,
                        MaxValue = 3000
                    };
                }
                else
                {
                    DisplayAlert("Uma pena", $"Sei que você está ancioso, mas os resultados estarão disponíveis em {7 - dados.Count} dias", "OK");
                    frameAgua.IsVisible = false;
                    frameRacao.IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }

        private void btnCadHorario_Clicked(object sender, EventArgs e)
        {
            if(txtQtdeAgua.Text != null && txtQtdeRacao.Text != null)
            {
                if (Convert.ToDecimal(txtQtdeAgua.Text) >= qtdeDisponivelAgua)
                {
                    DisplayAlert("Alerta", $"Quantidade de água acima da capacidade do alimentador", "OK");
                    txtQtdeAgua.Focus();
                }
                else if (Convert.ToDecimal(txtQtdeRacao.Text) >= qtdeDisponivelRacao)
                {
                    DisplayAlert("Alerta", $"Quantidade de ração acima da capacidade do alimentador", "OK");
                    txtQtdeRacao.Focus();
                }
                else
                {
                    HorariosAlimentador h = new HorariosAlimentador()
                    {
                        AlimentadorId = alimentadorId,
                        Horario = tpHorario.Time,
                        QtdeDespejarAgua = Convert.ToDecimal(txtQtdeAgua.Text),
                        QtdeDespejarRacao = Convert.ToDecimal(txtQtdeRacao.Text)
                    };

                    try
                    {
                        AlimentadorController ac = new AlimentadorController();
                        ac.DefinirHorarios(h);

                        frameAddHorario.IsVisible = false;

                        lvHorarios.ItemsSource = null;
                        lvHorarios.ItemsSource = ac.ListaHorarios(alimentadorId);
                        lvHorarios.IsVisible = true;
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", $"{ex.Message}", "OK");
                    }
                }
            }
            else
            {
                DisplayAlert("Erro", "Preencha os campos vazios", "OK");
            }
        }

        private void btnAddHorario_Clicked(object sender, EventArgs e)
        {
            frameAddHorario.IsVisible = true;
            slNoHorario.IsVisible = false;
        }

        private void btnApagar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var menu = sender as MenuItem;
                HorariosAlimentador h = menu.CommandParameter as HorariosAlimentador;

                AlimentadorController ac = new AlimentadorController();
                ac.ExcluirHorarios(h.HorariosAlimentadorId);

                lvHorarios.ItemsSource = null;
                lvHorarios.ItemsSource = ac.ListaHorarios(alimentadorId);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }
    }
}