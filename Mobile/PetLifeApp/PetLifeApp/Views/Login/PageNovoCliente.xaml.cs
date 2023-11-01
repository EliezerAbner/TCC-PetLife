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
                DataNascimento = DateTime.Now.ToString(),
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text
            };

            Endereco endereco = new Endereco()
            {
                Rua = txtRua.Text,
                Numero = txtNumero.Text,
                Cep = txtCep.Text,
                Cidade = txtCidade.Text,
                Estado = txtEstado.Text
            };

            LoginCliente login = new LoginCliente()
            {
                Email = txtEmail.Text,
                Senha = txtSenha.Text
            };

            ClienteController cadastrar = new ClienteController();
            cadastrar.NovoCliente(cliente, endereco, login);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageLogin());
        }
    }
}