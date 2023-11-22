using AppDeEntregas.Models;
using AppDeEntregas.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDeEntregas.Views {
    public partial class RequestPage : ContentPage {
        public Request Item { get; set; }

        public RequestPage() {
            InitializeComponent();
            BindingContext = new RequestViewModel();
        }
    }
}