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
		public PageMeusPets ()
		{
			InitializeComponent ();
		}

        private void btnAddPet_Clicked(object sender, EventArgs e)
        {

        }
    }
}