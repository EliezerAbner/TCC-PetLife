using PetLifeApp.Controller;
using PetLifeApp.Models;
using PetLifeApp.Views.GPS;
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

            try
            {
                PetController controller = new PetController();
                List<Pet> listaPet = new List<Pet>();

                if(listaPet.Count > 0 )
                {
                    cvPet.ItemsSource = listaPet;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }

        private void btnVerMaisPet_Clicked(object sender, EventArgs e)
        {
            //Pet by Vector Place
            //Pet-Food by Andinur Studio
        }

        private void btnVerMaisAlimentador_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btnGPS_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageGPS());
        }
    }
}