using PetLifeApp.Controller;
using PetLifeApp.Models;
using PetLifeApp.Views.Pets;
using PetLifeApp.Views.Rastreadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Pets
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageMeusPets : ContentPage
	{
        private int clienteId;

		public PageMeusPets ()
		{
			InitializeComponent ();

            if (Application.Current.Properties.ContainsKey("clienteId"))
            {
                string clientId = Application.Current.Properties["clienteId"] as string;
                clienteId = int.Parse(clientId);
            }

            PetController carregarPets = new PetController();
            List<Pet> listaPet = new List<Pet> ();

			try
			{
                listaPet = carregarPets.CarregarPets(clienteId);

                if (listaPet.Count > 0)
                {
                    lvPets.ItemsSource = listaPet;
                }
                else
                {
                    slAddPet.IsVisible = true;
                    lvPets .IsVisible = false;
                }
            }
			catch (Exception ex)
			{
                DisplayAlert("Erro", $"{ex.Message}", "OK");
			}
        }

        private void btnAddPet_Clicked(object sender, EventArgs e)
        {
            var pagAnterior = Navigation.NavigationStack.LastOrDefault();
            Navigation.PushAsync(new PageAddNovoPet());
            Navigation.RemovePage(pagAnterior);
            
        }

        private void lvPets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Pet p = e.SelectedItem as Pet;
            if (p != null)
            {
                Navigation.PushAsync(new PageAddNovoPet(p));
                lvPets.SelectedItem = null;
            }
        }
    }
}