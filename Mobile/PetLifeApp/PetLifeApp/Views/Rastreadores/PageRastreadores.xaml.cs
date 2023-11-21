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
    public partial class PageRastreadores : ContentPage
    {
        private int clienteId;

        public PageRastreadores()
        {
            clienteId = 6;
            //---------------------------------
            InitializeComponent();

            PetController lista = new PetController();
            pickerPet.ItemsSource = lista.CarregarPets(clienteId);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            slForm.IsVisible = true;
            slAddRas.IsVisible = false;
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            if(txtIdentificador.Text != null || txtNomeRastreador.Text != null || pickerPet.SelectedItem != null) 
            {
                Rastreador novoRastreador = new Rastreador()
                {
                    ClienteId = clienteId,
                    Identificador = txtIdentificador.Text,
                    NomeRastreador = txtNomeRastreador.Text,
                    PetId = pickerPet.SelectedIndex
                };

                try
                {
                    RastreadorController rc = new RastreadorController();
                    rc.NovoRastreador(novoRastreador);

                    //atualizar listView
                    //fechar slform
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", $"{ex.Message}", "OK");
                }
            }
        }
    }
}