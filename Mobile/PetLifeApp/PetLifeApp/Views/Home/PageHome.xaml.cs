using PetLifeApp.Controller;
using PetLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetLifeApp.Views.Alimentadores;
using PetLifeApp.Views.Pets;

namespace PetLifeApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHome : ContentPage
    {
        private int clienteId;

        public PageHome()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("clienteId"))
            {
                string clientId = Application.Current.Properties["clienteId"] as string;
                clienteId = int.Parse(clientId);
            }

            try
            {
                PetController controller = new PetController();
                List<Pet> listaPet = new List<Pet>();
                listaPet = controller.CarregarPets(clienteId);

                if (listaPet.Count > 0)
                {
                    cvPet.ItemsSource = listaPet;
                }

                AlimentadorController ac = new AlimentadorController();
                List<Alimentador> listaAlim = new List<Alimentador>();
                listaAlim = ac.ListaAlimentadores(clienteId);

                if (listaAlim.Count > 0)
                {
                    cvAlimentador.ItemsSource = listaAlim;
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"{ex.Message}", "OK");
            }
        }

        private void btnVerMaisPet_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageMeusPets());
        }

        private void btnVerMaisAlimentador_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageAlimentadores());
        }
    }
}