using PetLifeApp.Controller;
using PetLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Pets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAddNovoPet : ContentPage
    {
        private int clienteId;
        private int petId;

        public PageAddNovoPet()
        {
            InitializeComponent();
            CarregarListas();
            clienteId = 6;
        }

        public PageAddNovoPet(Pet editPet)
        {
            InitializeComponent();
            CarregarListas();

            clienteId = 6;
            petId = editPet.PetId;
            txtNomePet.Text = editPet.Nome;
            txtObservacao.Text = editPet.Observacao;
            txtPeso.Text = Convert.ToString(editPet.Peso);
            txtRaca.Text = editPet.Raca;
            pkEspecie.SelectedItem = editPet.Especie;
            pkPorte.SelectedItem = editPet.Porte;
            dpDataNascimento.Date = Convert.ToDateTime(editPet.DataNascimento);

            btnCadastrar.Text = "Editar";
            btnExcluir.IsVisible = true;
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            var pagAnterior = Navigation.NavigationStack.LastOrDefault();
            Navigation.PushAsync(new PageMeusPets());
            Navigation.RemovePage(pagAnterior);
        }

        private void BtnCadastrar_Clicked(object sender, EventArgs e)
        {
            if (VerificaCamposVazios())
            {
                Pet novoPet = new Pet()
                {
                    ClienteId = clienteId,
                    DataNascimento = Convert.ToString(dpDataNascimento.Date),
                    Nome = txtNomePet.Text,
                    Observacao = txtObservacao.Text,
                    Peso = Convert.ToDecimal(txtPeso.Text),
                    Porte = Convert.ToString(pkPorte.SelectedItem),
                    Raca = txtRaca.Text,
                    Especie = Convert.ToString(pkEspecie.SelectedItem)
                };

                try
                {
                    PetController cadPet = new PetController();

                    if (btnCadastrar.Text == "Cadastrar")
                    {
                        cadPet.NovoPet(novoPet);
                    }
                    else
                    {
                        novoPet.PetId = petId;
                        cadPet.EditarPet(novoPet);
                    }

                    var pagAnterior = Navigation.NavigationStack.LastOrDefault();
                    Navigation.PushAsync(new PageMeusPets());
                    Navigation.RemovePage(pagAnterior);
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", $"Infelizmente não estamos conseguindo cadastrar seu pet. Erro: {ex.Message}", "Ok");
                }
            }
            else
            {
                DisplayAlert("Campos não preenchidos", "Preencha os campos vazios", "OK");
            }
        }

        private bool VerificaCamposVazios()
        {
            if(txtNomePet.Text == null || txtRaca.Text == null || pkEspecie.SelectedItem == null)
            {
                return false;
            }
            else if (txtObservacao.Text == null || txtPeso.Text == null || dpDataNascimento.Date == DateTime.Today) 
            {
                DisplayAlert("Atenção", "Os campos não são obrigatórios, mas seriam de grande ajuda para os nossos PetWalkers", "OK");
            }

            return true;
        }

        private void CarregarListas()
        {
            List<string> listaPorte = new List<string>()
            {
                "Pequeno",
                "Médio",
                "Grande"
            };

            List<string> listaEspecie = new List<string>()
            {
                "Cachorro",
                "Gato",
                "Ave",
                "Outros"
            };

            pkEspecie.ItemsSource = listaEspecie;
            pkPorte.ItemsSource = listaPorte;
        }

        private async void BtnExcluir_Clicked(object sender, EventArgs e)
        {
            bool resp = await DisplayAlert("Excluir", "Deseja mesmo excluir esse pet?", "Sim", "Não");

            if (resp)
            {
                try
                {
                    PetController controller = new PetController();
                    controller.ExcluirPet(petId);

                    var pagAnterior = Navigation.NavigationStack.LastOrDefault();
                    await Navigation.PushAsync(new PageMeusPets());
                    Navigation.RemovePage(pagAnterior);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", $"Não estamos conseguindo realizar essa operação. Erro: {ex.Message}", "OK");
                }
            }
        }
    }
}