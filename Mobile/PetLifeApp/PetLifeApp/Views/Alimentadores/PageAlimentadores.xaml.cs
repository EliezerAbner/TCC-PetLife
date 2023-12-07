using PetLifeApp.Controller;
using PetLifeApp.Models;
using PetLifeApp.Views.Compra;
using PetLifeApp.Views.Home;
using PetLifeApp.Views.Rastreadores;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Alimentadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAlimentadores : ContentPage
    {
        private int clienteId;
        private int alimentadorId;

        public PageAlimentadores()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("clienteId"))
            {
                string clientId = Application.Current.Properties["clienteId"] as string;
                clienteId = int.Parse(clientId);
            }

            try
            {
                List<Alimentador> listaAlim = new List<Alimentador>();
                AlimentadorController controller = new AlimentadorController();
                listaAlim = controller.ListaAlimentadores(clienteId);

                if (listaAlim.Count > 0)
                {
                    lvAlimentadores.ItemsSource = listaAlim;
                    slNoAlim.IsVisible = false;
                }
                else
                {
                    lvAlimentadores.IsVisible = false;
                    slNoAlim.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");

                lvAlimentadores.IsVisible = false;
                slNoAlim.IsVisible = true;
            }
        }

        private void BtnAddAlim_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAddAlimentador());
        }

        private void btnComprar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageCompra());
        }

        private void lvAlimentadores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Alimentador a = e.SelectedItem as Alimentador;
            if (a != null)
            {
                Navigation.PushAsync(new PageAlimentadorInfo(a));
                lvAlimentadores.SelectedItem = null;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            slAddAlim.IsVisible = false;
            slForm.IsVisible = true;
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            if (txtIdentificador.Text != null || txtNomeAlimentador.Text != null)
            {
                Alimentador novoAlimentador = new Alimentador()
                {
                    ClienteId = clienteId,
                    Identificador = txtIdentificador.Text,
                    NomeAlimentador = txtNomeAlimentador.Text,
                };

                try
                {
                    AlimentadorController alimentadorController = new AlimentadorController();
                    bool opOk = alimentadorController.NovoAlimentador(novoAlimentador);

                    if (opOk)
                    {
                        lvAlimentadores.ItemsSource = null;

                        AlimentadorController alController = new AlimentadorController();
                        lvAlimentadores.ItemsSource = alController.ListaAlimentadores(clienteId);

                        slForm.IsVisible = false;
                        slAddAlim.IsVisible = true;
                    }
                    else
                    {
                        DisplayAlert("Erro", "Erro ao cadastrar o alimentador. Tente novamente", "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", $"{ex.Message}", "OK");
                }
            }
            else
            {
                DisplayAlert("Erro","Preencha os campos restantes","OK");
            }
        }
    }
}