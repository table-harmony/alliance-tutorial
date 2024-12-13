using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EventTrackerTutorial.Utils {
    /// <summary>
    /// מחלקה המייצגת אירוע במערכת
    /// </summary>
    public class Event {
        /// <summary>
        /// זמן יצירת האירוע
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// מפתח/מזהה האירוע
        /// </summary>
        public string Key { get; set; }
    }

    public class EventTracker {
        private readonly HttpClient _httpClient;  //  לקוח HTTP לביצוע בקשות לשרת   
        private const string API_URL = "https://www.devharmony.io/api/";  //  כתובת ה-API של השירות
        private const string SCHOOL_ID = "j9714cqqkrf0trcj8vm235vnjs70t8vb";  // מזהה בית ספר

        public EventTracker() {
            _httpClient = new HttpClient {
                BaseAddress = new Uri(API_URL)
            };
        }

        /// <summary>
        /// מחזיר את כל האירועים שתועדו במערכת
        /// </summary>
        /// <returns>רשימת האירועים</returns>
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

        /// <summary>
        /// מתעד אירוע חדש במערכת
        /// </summary>
        /// <param name="key">מפתח האירוע לתיעוד</param>
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
