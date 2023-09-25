using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageLogin());
        }
    }
}