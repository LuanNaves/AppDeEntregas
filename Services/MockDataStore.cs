using AppDeEntregas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDeEntregas.Services {
    public class MockDataStore : IDataStore<Request> {
        readonly List<Request> items;

        public MockDataStore() {
            items = new List<Request>();
        }
        
        public async Task<bool> AddItemAsync(Request item) {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Request item) {
            var oldItem = items.Where((Request arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id) {
            var oldItem = items.Where((Request arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Request> GetItemAsync(string id) {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Request>> GetItemsAsync(bool forceRefresh = false) {
            return await Task.FromResult(items);
        }
    }
}