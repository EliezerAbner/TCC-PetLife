using PetLifeApp.Controller;
using PetLifeApp.Models;
using PetLifeApp.Views.Compra;
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

            clienteId = 6;

            try
            {
                List<Alimentador> listaAlim = new List<Alimentador>();
                AlimentadorController controller = new AlimentadorController();
                listaAlim = controller.ListaAlimentadores(clienteId);

                if(listaAlim.Count != 0)
                {
                    lvAlimentadores.ItemsSource = listaAlim;
                }
                else
                {
                    lvAlimentadores.IsVisible = false;
                    slAddAlim.IsVisible = true;
                }
            }
            catch (Exception ex) 
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");

                lvAlimentadores.IsVisible = false;
                slAddAlim.IsVisible = true;
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
            Navigation.PushAsync(new PageAlimentadorInfo(e.SelectedItem as Alimentador));
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
                    NomeAlimentador = txtIdentificador.Text,
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