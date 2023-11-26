using PetLifeApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetLifeApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHome : FlyoutPage
    {
        private int clienteId;

        public FlyoutHome(int clienteId)
        {
            InitializeComponent();
            flyout.listView.ItemSelected += OnSelectedItem;
            this.clienteId = clienteId;

            Device.BeginInvokeOnMainThread(() =>
            {
                MessagingCenter.Send<Page, int>(this, "clienteId", this.clienteId);
            });
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if (item != null)
            {
                Device.BeginInvokeOnMainThread(() => 
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                    flyout.listView.SelectedItem = null;
                    IsPresented = false;
                });
            }
        }
    }
}