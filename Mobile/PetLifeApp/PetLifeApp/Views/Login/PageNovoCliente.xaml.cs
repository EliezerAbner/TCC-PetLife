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
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"Infelizmente estamos com dificuldades no momento, tente novamente mais tarde. Erro: {ex.Message}", "OK");
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

                    if (VerificaCamposVazios("etapa1"))
                    {
                        ClienteController carneFresca = new ClienteController();
                        string resultado = carneFresca.Validacao(txtEmail.Text, txtTelefone.Text);

                        if (resultado != "ok")
                        {
                            CorrecaoValidacao(resultado);
                            break;
                        }

                        sl01.IsVisible = false;
                        sl02.IsVisible = true;

                        pickerEstado.ItemsSource = carneFresca.BuscaEstados();
                    }
                    else
                    {
                        DisplayAlert("Erro", "Preencha os campos vazios!", "OK");
                    }
                    break;

                case "Cadastrar Endereço":

                    if (VerificaCamposVazios("etapa2"))
                    {
                        sl02.IsVisible = false;
                        sl03.IsVisible = true;
                    }
                    else
                    {
                        DisplayAlert("Erro", "Preencha os campos vazios!", "OK");
                    }
                    break;
            }
        }

        private void CorrecaoValidacao(string resultado)
        {
            switch (resultado)
            {
                case "email":
                    txtEmail.TextColor = Color.FromHex("#F0555E");
                    lblEmail.IsVisible = true;
                    break;

                case "telefone":
                    txtTelefone.TextColor = Color.FromHex("#F0555E");
                    lblTelefone.IsVisible = true;
                    break;
            }
        }

        private bool VerificaCamposVazios(string etapa)
        {

            switch (etapa)
            {
                case "etapa1":
                    if(txtNome.Text == null || txtEmail.Text == null || txtTelefone.Text == null || dpDataNascimento.Date == DateTime.Today)
                    {
                        return false;
                    }

                    if((DateTime.Today.Year - dpDataNascimento.Date.Year) < 18)
                    {
                        DisplayAlert("Erro", "Agradecemos pelo seu entusiasmo, no entanto, apenas maiores de 18 anos podem abrir uma conta PetLife.", "OK");
                        btnContinuar.IsEnabled = true;

                        return false;
                    }
                    break;

                case "etapa2":
                    if(txtCep.Text == null || txtRua.Text == null || txtNumero.Text == null || txtCidade.Text == null || pickerEstado.SelectedItem == null)
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        private void txtSenhaConfirmacao_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSenha.Text != txtSenhaConfirmacao.Text)
            {
                txtSenhaConfirmacao.TextColor = Color.FromHex("#F0555E");
                lblSenha.IsVisible = true;
                btnCadastrar.IsEnabled = false;
            }
            else
            {
                txtSenhaConfirmacao.TextColor = Color.Black;
                lblSenha.IsVisible = false;
                btnCadastrar.IsEnabled = true;
            }
        }
    }
}