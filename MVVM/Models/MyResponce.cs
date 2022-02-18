using Newtonsoft.Json;
using System.Collections.Generic;

namespace MVVM.Models
{

    public class MyResponce
    {
        [JsonProperty("data")]
        public List<People> Responce { get; set; }
    }
}
