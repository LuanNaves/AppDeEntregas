
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDeEntregas.Views {
    public partial class ProfilePage : ContentPage {
        public ProfilePage() {
            InitializeComponent();
        }
        private async void OnRequestButtonClicked(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("//RequestPage");
        }

    }

}