using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace AITutorial.Utils {
    public class Image {
        public int Width { get; set; } = 500;
        public int Height { get; set; } = 500;
        public string Format { get; set; } = "png";
        public string AspectRatio { get; set; } = "1:1";
    }

    public class ImageGenerationRequest {
        public Image Image { get; set; }
        public string Prompt { get; set; }
    }

    /// <summary>
    /// Interface for image generation models.
    /// Implementations should handle image-based AI model interactions.
    /// </summary>
    public interface IImageModelService {
        Task<Stream> GenerateImageAsync(ImageGenerationRequest request);
    }

    /// <summary>
    /// Stability AI implementation for image generation.
    /// Uses the Stability AI API (https://stability.ai/) for image generation tasks.
    /// Requires an API key from Stability AI platform.
    /// </summary>
    public class StabilityService : IImageModelService {
        private readonly HttpClient _httpClient;

        public StabilityService() {
            string apiKey = ConfigurationManager.AppSettings["Stability_ApiKey"];

            _httpClient = new HttpClient {
                BaseAddress = new Uri("https://api.stability.ai/")
            };
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("image/*"));
        }

        public async Task<Stream> GenerateImageAsync(ImageGenerationRequest request) {
            using (var content = new MultipartFormDataContent()) {
                content.Add(new StringContent(request.Prompt), "\"prompt\"");
                content.Add(new StringContent(request.Image.Format), "\"output_format\"");
                content.Add(new StringContent(request.Image.Width.ToString()), "\"width\"");
                content.Add(new StringContent(request.Image.Height.ToString()), "\"height\"");
                content.Add(new StringContent(request.Image.AspectRatio), "\"aspect_ratio\"");

                var response = await _httpClient.PostAsync("v2beta/stable-image/generate/core", content);
                string x = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStreamAsync();
            }
        }
    }
}