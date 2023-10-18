using PetLifeApp.Models;
using System;
using Xamarin.Forms;
using PetLifeApp.Views;

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
            Cliente teste = new Cliente()
            {
                Nome = "Teste 01",
                dataNascimento = DateTime.Now,
                Email = "teste@teste.com",
                Rua = "Av Brasil",
                Numero = 564,
                Cep = "87043698",
                Cidade = "Maringá",
                Estado = "PR",
                Telefone = "(44) 9 9874-2145"
            };

            try
            {
                teste.NovoCliente();
                DisplayAlert("Sucesso", "Deu bom :)", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }

		private async void Alimentador_Clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new PageAlimentador());
		}
	}
}
