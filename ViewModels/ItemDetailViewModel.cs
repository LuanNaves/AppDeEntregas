using AppDeEntregas.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDeEntregas.ViewModels {
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel {
        private string itemId;
        private string height;
        private string arrivalAdress;
        public string Id { get; set; }

        public string Height {
            get => height;
            set => SetProperty(ref height, value);
        }

        public string ArrivalAdress {
            get => arrivalAdress;
            set => SetProperty(ref arrivalAdress, value);
        }

        public string ItemId {
            get {
                return itemId;
            }
            set {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId) {
            try {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Height = item.Height;
                ArrivalAdress = item.ArrivalAddress;
            }
            catch (Exception) {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
