using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHome : ContentPage
    {
        public PageHome()
        {
            InitializeComponent();
        }

        private void btnVerMaisPet_Clicked(object sender, EventArgs e)
        {
            //Pet by Vector Place
            //Pet-Food by Andinur Studio
        }

        private void btnVerMaisAlimentador_Clicked(object sender, EventArgs e)
        {

        }
    }
}