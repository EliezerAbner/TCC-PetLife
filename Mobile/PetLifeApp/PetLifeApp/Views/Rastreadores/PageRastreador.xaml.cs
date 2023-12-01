using PetLifeApp.Controller;
using PetLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Rastreadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRastreador : ContentPage
    {
        private int clienteId;

        public PageRastreador()
        {
            InitializeComponent();

            clienteId = 6;

            List<Rastreador> listaRastreadores = new List<Rastreador>();

            try 
            {
                PetController pc = new PetController();
                pickerPet.ItemsSource = pc.CarregarPets(clienteId);

                RastreadorController rc = new RastreadorController();
                listaRastreadores = rc.ListaRastreadores(clienteId);
            } 
            catch (Exception ex) 
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }


            if (listaRastreadores.Count > 0)
            {
                lvRastreador.ItemsSource = listaRastreadores;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            slAddRas.IsVisible = false;
            slForm.IsVisible = true;
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            if (txtIdentificador.Text !=  null && pickerPet.SelectedItem != null)
            {
                Rastreador novoRastreador = new Rastreador()
                {
                    ClienteId = clienteId,
                    Identificador = txtIdentificador.Text,
                    PetId = pickerPet.SelectedIndex,
                };

                try
                {
                    RastreadorController rc = new RastreadorController();
                    bool deuBom = rc.NovoRastreador(novoRastreador);

                    if (deuBom)
                    {
                        slAddRas.IsVisible = true;
                        slForm.IsVisible = false;
                    }
                    else
                    {
                        DisplayAlert("Erro", "Houve um erro ao cadastrar seu rastreador. Verifique o identificador e tente novamente.", "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", $"{ex.Message}", "OK");
                }
            }
            else
            {
                DisplayAlert("Erro", $"Preencha os campos vazios.", "OK");
            }
        }

        private void lvRastreador_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Rastreador r = e.SelectedItem as Rastreador;
            if (r != null)
            {
                Navigation.PushAsync(new PageMapa(r));
                lvRastreador.SelectedItem = null;
            }
        }
    }
}