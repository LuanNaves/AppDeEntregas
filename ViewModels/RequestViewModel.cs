using AppDeEntregas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDeEntregas.ViewModels {
    public class RequestViewModel : BaseViewModel {
        private string height;
        private string arrivalAddress;
        private string departureAddress;
        private string distance;
        private string travelTime;
        private string shippingValue;

        public RequestViewModel() {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave() {
            return !String.IsNullOrWhiteSpace(height)
                && !String.IsNullOrWhiteSpace(arrivalAddress)
                && !String.IsNullOrWhiteSpace(departureAddress)
                && !String.IsNullOrWhiteSpace(distance)
                && !String.IsNullOrWhiteSpace(travelTime);
        }

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
        //public string ShippingValue {
        //    get => shippingValue;
        //    set => SetProperty(ref shippingValue, value);
        //}
        public string calculateShippingValue() {
            double doubleHeight = double.Parse(height);
            int intTravelTime = int.Parse(travelTime);
            double doubleDistance = double.Parse(distance);

            double distanceValue;
            double travelTimeValue;
            double heightValue;
            
            if (doubleHeight <= 1) {
                heightValue = 3;
            } else if (doubleHeight <= 3) {
                heightValue = 5;
            } else if (doubleHeight <= 8) {
                heightValue = 9;
            } else if (doubleHeight <= 12) {
                heightValue = 12;
            }
            else {
                heightValue = 0;
            }

            distanceValue = doubleDistance * 0.5;

            travelTimeValue = intTravelTime * 0.3;

            double doubleShippingValue = distanceValue + travelTimeValue + heightValue;

            shippingValue = doubleShippingValue.ToString();

            return shippingValue;


        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel() {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave() {
            Request newItem = new Request() {
                Id = Guid.NewGuid().ToString(),
                Height = "Peso: " + height + "Kg",
                DepartureAddress = "Endereço de Saída: " + DepartureAddress,
                ArrivalAddress = "Endereço de Entrega: " + ArrivalAddress,
                Distance = "Distancia: " + Distance,
                TravelTime = "Tempo de Deslocamento: " + TravelTime,
                ShippingValue =  "Valor do frete: R$" + calculateShippingValue(),
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
