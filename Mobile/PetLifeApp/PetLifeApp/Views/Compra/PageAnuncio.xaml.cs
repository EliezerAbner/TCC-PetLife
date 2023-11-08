using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Compra
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageAnuncio : ContentPage
	{
		public PageAnuncio ()
		{
			InitializeComponent ();
		}

		private async void Comprar_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync (new PageComprar());
        }
    }
}