using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EventTrackerTutorial.Utils {
    /// <summary>
    /// אירוע
    /// </summary>
    public class Event {
        public DateTime CreationTime { get; set; }
        public string Key { get; set; }
    }

    /// <summary>
    /// ממשק עבור מעקב אחר אירועים
    /// </summary>
    public interface IEventTracker {
        // פעולה עבור החזרת כל האירועים
        Task<List<Event>> GetEventsAsync();
        
        // מעקב אחרי אירוע
        Task TrackEventAsync(string key);
    }

    public class EventTracker : IEventTracker {
        private readonly HttpClient _httpClient;
        private const string API_URL = "https://www.devharmony.io/api/";
        private const string SCHOOL_ID = "your_school_id";

        public EventTracker() {
            _httpClient = new HttpClient {
                BaseAddress = new Uri(API_URL)
            };
        }

        public async Task<List<Event>> GetEventsAsync() {
            try {
                List<Event> events = new List<Event>();
                
                var response = await _httpClient.GetAsync($"schools/{SCHOOL_ID}");
                string content = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject<object>(content);
                
                foreach (var item in data["events"]) {
                    Event @event = new Event {
                        Key = item["key"],
                        CreationTime = DateTimeOffset.FromUnixTimeMilliseconds((long)item["_creationTime"]).DateTime
                    };

                    events.Add(@event);
                }

                return events;
            } catch {
                return new List<Event>();
            }
        }

        public async Task TrackEventAsync(string key) {
            var payload = new {
                key,
                objectId = SCHOOL_ID
            };

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(payload),
                System.Text.Encoding.UTF8, 
                "application/json"
            );

            await _httpClient.PostAsync("events", content);
        }
    }
}
