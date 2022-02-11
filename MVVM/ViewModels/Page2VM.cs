using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }
    }
    public class MyResponce
    {
        [JsonProperty("data")]
        public List<User> Responce { get; set; }
    }

    class Page2VM : BindableObject
    {
        public ObservableCollection<User> data { get; set; }
        private HttpClient client;
        private object source;
        public object Source
        {
            get => source;
            set
            {
                if (source != value)
                {
                    source = value;
                    OnPropertyChanged(nameof(Source));
                }
            }
        }
        public ICommand Fill => new Command(Request);


        public async void Request()
        {
            client = new HttpClient();
            var result = await client.GetStringAsync("https://reqres.in/api/users?page=2");
            var users = JsonConvert.DeserializeObject<MyResponce>(result);
            data = new ObservableCollection<User>(users.Responce);
            Source = data;
        }
    }
}