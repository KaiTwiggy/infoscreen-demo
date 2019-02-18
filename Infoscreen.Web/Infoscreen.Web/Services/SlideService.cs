using System.Threading.Tasks;
using Infoscreen.Web.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Infoscreen.Web.Services
{
    public class SlideService : ISlideService
    {
        private static object _lock = new Object();
        public async Task<SlideDeck> GetSlides()
        {
            string data = "";
            lock (_lock)
            {
                try
                {
                    data = System.IO.File.ReadAllTextAsync(@"./data.json").Result;
                }
                catch (Exception e)
                {

                }
            }

            return string.IsNullOrEmpty(data) ? new SlideDeck() : JsonConvert.DeserializeObject<SlideDeck>(data);
        }

        public async Task<string> GetSlidesRaw()
        {
            lock (_lock)
            {
                return System.IO.File.ReadAllTextAsync(@"./data.json").Result;
            }
        }

        public async void UpdateSlides(SlideDeck slideDeck)
        {
            string newData;
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            newData = JsonConvert.SerializeObject(slideDeck, jsonSerializerSettings);

            lock (_lock)
            {                
                System.IO.File.WriteAllText(@"./data.json", newData);
            }            
        }
    }
}
