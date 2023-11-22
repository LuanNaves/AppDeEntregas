using AppDeEntregas.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppDeEntregas.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}