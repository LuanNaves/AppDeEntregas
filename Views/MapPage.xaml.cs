
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace AppDeEntregas.Views {
    public partial class MapPage : ContentPage {
        public MapPage() {
            InitializeComponent();

            Pin pinHome = new Pin() {
                Type=PinType.Place,
                Label="Home",
                Address="Rua Primo Barbosa, 180",
                Position=new Position(-19.871418924365287, -44.60824948220891),
                Tag="id_home",
            };

            map.Pins.Add(pinHome);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinHome.Position, Distance.FromMeters(1000)));
        }

    }

}