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

        public RequestViewModel() {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave() {
            return !String.IsNullOrWhiteSpace(height)
                && !String.IsNullOrWhiteSpace(arrivalAddress)
                && !String.IsNullOrWhiteSpace(departureAddress);
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel() {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave() {
            Request newItem = new Request() {
                Id = Guid.NewGuid().ToString(),
                Height = "Peso: "+ height + "Kg",
                DepartureAddress = "Endereço de Saída: " + DepartureAddress,
                ArrivalAddress = "Endereço de Entrega: " + ArrivalAddress
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
