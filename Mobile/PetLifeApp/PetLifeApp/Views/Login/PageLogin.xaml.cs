using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PetLifeApp.Controller;
using PetLifeApp.Views.Home;
using PetLifeApp.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetLifeApp.Models;

namespace PetLifeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLogin : ContentPage
    {
		private LoginCliente login;
		private LoginController fazerLogin;

        public PageLogin()
        {
            InitializeComponent();
            slEmail.IsVisible = true;
            slSenha.IsVisible = false;

			fazerLogin = new LoginController();
			login = new LoginCliente();
			txtEmail.Focus();
		}

		private void btnLogin_Clicked(object sender, EventArgs e)
		{
			if (txtSenha.Text != "")
			{
				login.Senha = txtSenha.Text;
				

				int clienteId = fazerLogin.VerificarSenha(login);

				if(clienteId != 0)
                {
                    var pagAnterior = Navigation.NavigationStack.LastOrDefault();
                    Navigation.PushAsync(new FlyoutHome(clienteId));
                    Navigation.RemovePage(pagAnterior);
                }
			}
		}

		private void btnProximo_Clicked(object sender, EventArgs e)
		{
			try
			{
				if (txtEmail.Text.Contains("@")) 
				{
					login.Email = txtEmail.Text;

					int emailId = fazerLogin.VerificarEmail(login);

					if (emailId != 0)
					{
						login.EmailId= emailId;
						slEmail.IsVisible = false;
						slSenha.IsVisible = true;
						txtSenha.Focus();
					}
					else
					{
						DisplayAlert("Login", "Erro ao logar. Verifique seu email e tente novamente", "OK");
						txtEmail.Text = string.Empty;
					}
				}
				else
				{
					DisplayAlert("Login", "Erro ao logar. Verifique seu email e tente novamente", "OK");
				}
			}
			catch (Exception ex)
			{
				DisplayAlert("Erro", $"Infelizmente não estamos conseguindo te logar no momento. Tente novamente em instantes. Erro: {ex.Message}", "OK");
			}
		}

		private void btnCriarConta_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PageNovoCliente());
		}
	}
}