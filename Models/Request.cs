using System;

namespace AppDeEntregas.Models {
    public class Request {
        public string Id { get; set; }
        public string Height { get; set; }
        public string ArrivalAddress { get; set; }
        public string DepartureAddress { get; set; }
        public string Distance { get; set; }
        public string TravelTime { get; set; }
        public string ShippingValue { get; set; }

    }
}