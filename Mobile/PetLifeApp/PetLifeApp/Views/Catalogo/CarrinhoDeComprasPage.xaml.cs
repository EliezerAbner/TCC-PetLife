using PetLifeApp.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Catalogo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrinhoDeComprasPage : ContentPage
    {
        private int itensNoCarrinho = 0;

        public CarrinhoDeComprasPage()
        {
            InitializeComponent();

            
            ComprarButton1.Clicked += ComprarButton_Clicked;

           
            ComprarButton2.Clicked += ComprarButton_Clicked;

            
            ProsseguirButton.Clicked += ProsseguirButton_Clicked;
        }

        private void ComprarButton_Clicked(object sender, EventArgs e)
        {
           
            itensNoCarrinho++;
            AtualizarCarrinhoInfoLabel();
        }

        private async void ProsseguirButton_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new catalogo_produtos());
        }

        private void AtualizarCarrinhoInfoLabel()
        {
            CarrinhoInfoLabel.Text = $"Itens no carrinho: {itensNoCarrinho}";
        }
    }
}