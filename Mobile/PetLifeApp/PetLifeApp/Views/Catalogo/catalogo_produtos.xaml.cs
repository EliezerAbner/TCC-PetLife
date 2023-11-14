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
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {                          
            await Navigation.PushAsync(new CarrinhoDeComprasPage());
           
        }
    }
}