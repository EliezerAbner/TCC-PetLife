using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetLifeApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLogin : ContentPage
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PopAsync();
            Navigation.PushAsync(new PagePrincipal());
        }

    }
}