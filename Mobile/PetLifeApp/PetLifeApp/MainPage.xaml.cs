using PetLifeApp.Models;
using PetLifeApp.Services;
using System;
using Xamarin.Forms;

namespace PetLifeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void bt_Clicked(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                DataNascimento = DateTime.Now.ToString(),
                Nome = "Teste 03",
                Telefone = "44997541269"
            };

            Endereco endereco = new Endereco()
            {
                Cep = "9999999",
                Cidade = "Curitiba",
                Estado = "PR",
                Numero = 69,
                Rua = "Rua Trave Tristes"
            };

            Login login = new Login()
            {
                Email = "teste@teste.com",
                Senha = "123",
            };

            try
            {
                ClienteController testeConexao = new ClienteController();
                testeConexao.NovoCliente(cliente, endereco, login);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"Erro: {ex.Message}", "OK");
            }
        }
    }
}
