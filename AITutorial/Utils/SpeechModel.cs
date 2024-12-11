using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AITutorial.Utils {
    //TODO: not good that there is model id and voice id of specific implemetation
    public class SpeechGenerationRequest {
        public string Prompt { get; set; }
        public string ModelId { get; set; } = "eleven_multilingual_v2";
        public string VoiceId { get; set; } = "9BWtsMINqrJLrRacOk9x";
        public float Stability { get; set; } = 0.5f;
        public float SimilarityBoost { get; set; } = 0.5f;
    }

    /// <summary>
    /// Interface for text-to-speech models.
    /// Implementations should handle speech synthesis tasks.
    /// </summary>
    public interface ITextToSpeechService {
        Task<Stream> GenerateSpeechAsync(SpeechGenerationRequest request);
    }

    /// <summary>
    /// ElevenLabs implementation for text-to-speech generation.
    /// Uses the ElevenLabs API (https://elevenlabs.io/) for speech synthesis.
    /// Requires an API key from ElevenLabs platform.
    /// </summary>
    public class ElevenLabsService : ITextToSpeechService {
        private readonly HttpClient _httpClient;

        public ElevenLabsService() {
            string apiKey = ConfigurationManager.AppSettings["ElevenLabs_ApiKey"];

            _httpClient = new HttpClient {
                BaseAddress = new Uri("https://api.elevenlabs.io/v1/"),
                Timeout = TimeSpan.FromMinutes(5)
            };
            _httpClient.DefaultRequestHeaders.Add("xi-api-key", apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("audio/mpeg"));
        }

        public async Task<Stream> GenerateSpeechAsync(SpeechGenerationRequest request) {
            var payload = new {
                text = request.Prompt,
                model_id = request.ModelId,
                voice_settings = new {
                    stability = request.Stability,
                    similarity_boost = request.SimilarityBoost
                }
            };
            var content = new StringContent(
                JsonConvert.SerializeObject(payload),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync($"text-to-speech/{request.VoiceId}", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync();
        }
    }
}