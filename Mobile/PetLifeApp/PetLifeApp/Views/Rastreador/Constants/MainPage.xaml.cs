using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace XF_GoogleMaps
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Pin Localizacao = new Pin()
            {
                Type = PinType.Place,
                Label = "Ponto",
                Address = "",
                Position = new Position(-23.411347, -51.956203),
                Tag = "Pet",

            };
            map.Pins.Add(Localizacao);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(Localizacao.Position, 
                Distance.FromMeters(5000)));
        }
    }
}
