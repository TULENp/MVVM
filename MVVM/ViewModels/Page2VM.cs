using MVVM.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using UsersLibrary;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
    internal class Page2VM : BindableObject
    {
        private HttpClient client;
        private ObservableCollection<People> people = new ObservableCollection<People>();
        public ObservableCollection<User> usersCollection = new ObservableCollection<User>();

        public ObservableCollection<People> People { get => people; set => people = value; }
        public ObservableCollection<User> UsersCollection { get => usersCollection; set => usersCollection = value; }
        
        public ICommand Fill => new Command(Request);
        public ICommand LoadUsers => new Command(MyUserRequest);

        public async void Request()
        {
            client = new HttpClient();
            var result = await client.GetStringAsync("https://reqres.in/api/users?page=2");
            var people = JsonConvert.DeserializeObject<MyResponce>(result);
            foreach (People user in people.Responce)
            {
                People.Add(user);
            }
        }

        public async void MyUserRequest()
        {
            client = new HttpClient();
            var json = await client.GetStringAsync("http://192.168.1.64/Users/GetUsers");
            var users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            UsersCollection.Clear();
            foreach (var user in users)
            {
                UsersCollection.Add(user);
            }
        }
    }
}