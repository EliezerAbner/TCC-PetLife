using PetLifeApp.Views.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Catalogo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class catalogo_produtos : ContentPage
    {
        public catalogo_produtos()
        {
            InitializeComponent();
            TipoCartaoPicker.SelectedIndex = 0;
        }

        private void FinalizarCompra_Clicked(object sender, EventArgs e)
        {
            
            string nome = NomeEntry.Text;
            string endereco = EnderecoEntry.Text;
            string numeroCartao = NumeroCartaoEntry.Text;
            string dataValidade = DataValidadeEntry.Text;
            string cvv = CvvEntry.Text;
            string tipoCartao = TipoCartaoPicker.SelectedItem.ToString();

            
            DisplayAlert("Compra Concluída", "Obrigado por sua compra!", "OK");
        }
    }
}