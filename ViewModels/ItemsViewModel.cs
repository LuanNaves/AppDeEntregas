using AppDeEntregas.Models;
using AppDeEntregas.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDeEntregas.ViewModels {
    public class ItemsViewModel : BaseViewModel {
        private Request _selectedItem;

        public ObservableCollection<Request> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Request> ItemTapped { get; }

        public ItemsViewModel() {
            Title = "Browse";
            Items = new ObservableCollection<Request>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Request>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand() {
            IsBusy = true;

            try {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items) {
                    Items.Add(item);
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);
            }
            finally {
                IsBusy = false;
            }
        }

        public void OnAppearing() {
            IsBusy = true;
            SelectedItem = null;
        }

        public Request SelectedItem {
            get => _selectedItem;
            set {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj) {
            await Shell.Current.GoToAsync(nameof(RequestPage));
        }

        async void OnItemSelected(Request item) {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}