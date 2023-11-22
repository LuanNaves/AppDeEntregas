using AppDeEntregas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDeEntregas.ViewModels {
    public class RequestViewModel : BaseViewModel {
        private string height;
        private string arrivalAdress;

        public RequestViewModel() {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave() {
            return !String.IsNullOrWhiteSpace(height)
                && !String.IsNullOrWhiteSpace(arrivalAdress);
        }

        public string Height {
            get => height;
            set => SetProperty(ref height, value);
        }

        public string ArrivalAdress {
            get => arrivalAdress;
            set => SetProperty(ref arrivalAdress, value);
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
                ArrivalAdress = "Endereço: " + arrivalAdress
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
