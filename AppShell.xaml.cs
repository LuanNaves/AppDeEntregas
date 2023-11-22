using AppDeEntregas.ViewModels;
using AppDeEntregas.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppDeEntregas {
    public partial class AppShell : Xamarin.Forms.Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(RequestPage), typeof(RequestPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
