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
            
            DisplayAlert("Sucesso", "Deu bom :)", "OK");
        }
    }
}
