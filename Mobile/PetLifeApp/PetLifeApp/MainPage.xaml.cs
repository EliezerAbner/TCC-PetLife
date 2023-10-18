using PetLifeApp.Models;
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
            Cliente cobaia = new Cliente()
            {
                Nome = "Teste 01",
                DataNascimento = DateTime.Now.ToString(),
                Email = "kagaro@bol.com",
                Rua = "Av Brasil",
                Numero = 564,
                Cep = "87043698",
                Cidade = "Maringá",
                Estado = "PR",
                Telefone = "(44) 9 9874-2145"
            };

            Cliente cliente = new Cliente();
            cliente.NovoCliente();
            DisplayAlert("Sucesso", "Deu bom :)", "OK");
        }
    }
}
