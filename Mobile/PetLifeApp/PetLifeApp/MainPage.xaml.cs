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

		private async void Alimentador_Clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new PageAlimentador());
		}
	}
}
