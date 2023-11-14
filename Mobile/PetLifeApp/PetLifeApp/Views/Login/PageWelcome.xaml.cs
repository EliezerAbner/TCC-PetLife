using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetLifeApp.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Roboto-Black.ttf", Alias = "Roboto-Black")]
[assembly: ExportFont("baloo-chettan-regular.ttf", Alias = "baloo-chettan-regular")]

namespace PetLifeApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageWelcome : ContentPage
    {
        public PageWelcome()
        {
            InitializeComponent();
        }

        private void btnNovoCliente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageNovoCliente());
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageLogin());
        }
    }
}