using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Net.Http;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    //public class UserList
    //{
    //    public List<User> users { get; set; }
    //}
    public partial class Consumer
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("House")]
        public string House { get; set; }

        [JsonProperty("Reign")]
        public string Reign { get; set; }
        public string ToShow
        {
            get => $"ID: {Id} | Name: {Name} | Country: {Country}";
        }
    }
    public class Page3VM : BindableObject
    {
        public ObservableCollection<Consumer> UsersCollection { get; set; }
        public ICommand GetUsers => new Command(Request);
        //it isnt show me the list on screen
        private async void Request()
        {
            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync("https://mysafeinfo.com/api/data?list=englishmonarchs&format=json");
            var request = JsonConvert.DeserializeObject<List<Consumer>>(json);
            UsersCollection = new ObservableCollection<Consumer>(request);

        }
    }

}
