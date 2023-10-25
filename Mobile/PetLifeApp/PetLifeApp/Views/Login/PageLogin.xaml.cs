using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PetLifeApp.Controller;
using PetLifeApp.Views;
using PetLifeApp.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetLifeApp.Models;

namespace PetLifeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLogin : ContentPage
    {
        public PageLogin()
        {
            InitializeComponent();
        }

		private void btnLogin_Clicked(object sender, EventArgs e)
		{
			
		}

		private void btnSenha_Clicked(object sender, EventArgs e)
		{
			string emailInserido = txtEmail.Text; // Recebe de txt email inserido
			LoginController loginController = new LoginController(); // Crie uma instância do seu controlador

			// criando instancia da classe login para capturar email
			Login login = new Login()
			{
				Email = emailInserido

			};

			// Chame o método VerificarEmail
			int emailId = loginController.VerificarEmail(login);

			if (emailId != 0)
			{
				if (emailId == login)
				{
					// O email está registrado no banco de dados
					// Agora você pode prosseguir para a próxima etapa, que é verificar a senha ou navegar para a próxima página
				}
			}
			else
			{
				// O email não está registrado no banco de dados
				// Você pode mostrar uma mensagem de erro ao usuário
				DisplayAlert("Erro", "O email não está registrado", "OK");
			}
		}

	}
	}
}