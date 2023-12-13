using PetLifeApp.Models;
using PetLifeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Configuracoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEditarConta : ContentPage
    {
        private int clienteId;
        private string senhaCliente;

        Cliente cliente = new Cliente();
        LoginCliente login = new LoginCliente();
        Endereco end = new Endereco();

        public PageEditarConta()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("clienteId"))
            {
                string clientId = Application.Current.Properties["clienteId"] as string;
                clienteId = int.Parse(clientId);

                ClienteController editarCliente = new ClienteController();
                
                pickerEstado.ItemsSource = editarCliente.BuscaEstados();
                (cliente, login, end) = editarCliente.CarregarCliente(clienteId);

                txtNome.Text = cliente.Nome;
                txtEmail.Text = login.Email;
                txtTelefone.Text = cliente.Telefone;
                dpDataNascimento.Date = Convert.ToDateTime(cliente.DataNascimento);

                txtRua.Text = end.Rua;
                txtCep.Text = end.Cep;
                txtNumero.Text = end.Numero;
                txtCidade.Text = end.Cidade;
                pickerEstado.SelectedItem = end.Estado;

                senhaCliente = login.Senha;
            }
            else
            {
                DisplayAlert("Erro", "Ocorreu um erro, tente novamente", "OK");
                Navigation.PopAsync();
            }
            
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                cliente.Id = clienteId;
                cliente.Nome = txtNome.Text;
                cliente.DataNascimento = Convert.ToString(dpDataNascimento.Date);
                cliente.Telefone = txtTelefone.Text;

                end.Cep = txtCep.Text;
                end.Cidade = txtCidade.Text;
                end.Estado = pickerEstado.SelectedItem.ToString();
                end.Numero = txtNumero.Text;
                end.Rua = txtRua.Text;

                login.Email = txtEmail.Text;

                ClienteController cc = new ClienteController();
                cc.EditarCliente(cliente, end, login);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }

            Navigation.PopAsync();
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}