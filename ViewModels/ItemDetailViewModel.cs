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
        private string arrivalAddress;
        private string departureAddress;
        private string distance;
        private string travelTime;
        private string shippingValue;


        public string Id { get; set; }

        public string Height {
            get => height;
            set => SetProperty(ref height, value);
        }

        public string ArrivalAddress {
            get => arrivalAddress;
            set => SetProperty(ref arrivalAddress, value);
        }
        public string DepartureAddress {
            get => departureAddress;
            set => SetProperty(ref departureAddress, value);
        }
        public string Distance {
            get => distance;
            set => SetProperty(ref distance, value);
        }
        public string TravelTime {
            get => travelTime;
            set => SetProperty(ref travelTime, value);
        }
        public string ShippingValue {
            get => shippingValue;
            set => SetProperty(ref shippingValue, value);
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
                ArrivalAddress = item.ArrivalAddress;
                DepartureAddress = item.DepartureAddress;
                Distance = item.Distance;
                TravelTime = item.TravelTime;
                ShippingValue = item.ShippingValue;
            }
            catch (Exception) {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
