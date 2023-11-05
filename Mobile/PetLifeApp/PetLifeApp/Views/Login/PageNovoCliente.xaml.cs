using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetLifeApp.Models;
using PetLifeApp.Controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetLifeApp.Services;

namespace PetLifeApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageNovoCliente : ContentPage
    {
        public PageNovoCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                DataNascimento = dpDataNascimento.Date.ToString(),
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text
            };

            Endereco endereco = new Endereco()
            {
                Rua = txtRua.Text,
                Numero = txtNumero.Text,
                Cep = txtCep.Text,
                Cidade = txtCidade.Text,
                Estado = pickerEstado.SelectedItem.ToString()
            };

            LoginCliente login = new LoginCliente()
            {
                Email = txtEmail.Text,
                Senha = txtSenha.Text
            };

            try
            {
                ClienteController cadastrar = new ClienteController();
                cadastrar.NovoCliente(cliente, endereco, login);

                Navigation.PopAsync();
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Infelizmente estamos com dificuldades no momento, tente novamente mais tarde", "OK");
            }
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageLogin());
        }

        private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            Button teste = sender as Button;

            switch (teste.Text)
            {
                case "Continuar":

                    sl01.IsVisible = false;
                    sl02.IsVisible = true;

                    ClienteController carregarEstado = new ClienteController();
                    pickerEstado.ItemsSource = carregarEstado.BuscaEstados();
                    break;

                case "Cadastrar Endereço":
                    sl02.IsVisible = false;
                    sl03.IsVisible = true;
                    break;
            }
        }
    }
}