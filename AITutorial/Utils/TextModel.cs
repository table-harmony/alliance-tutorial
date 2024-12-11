using System;
using System.Configuration;
using System.Threading.Tasks;
using Mscc.GenerativeAI;

namespace AITutorial.Utils {
    /// <summary>
    /// Interface for text generation models.
    /// Implementations should handle text-based AI model interactions.
    /// </summary>
    public interface ITextModelService {
        Task<string> GetResponseAsync(string prompt);
    }

    /// <summary>
    /// Google's Gemini AI implementation for text generation.
    /// Uses the Gemini API (https://ai.google.dev/) for text generation tasks.
    /// Requires an API key from Google AI Studio.
    /// </summary>
    public class GeminiService : ITextModelService {
        private readonly GenerativeModel _model;

        private static string GetGeminiApiKey() {
            string apiKey = ConfigurationManager.AppSettings["Gemini_ApiKey"];
            if (string.IsNullOrEmpty(apiKey)) {
                throw new ConfigurationErrorsException("Gemini API key not found in configuration");
            }
            return apiKey;
        }

        public GeminiService() {
            string apiKey = GetGeminiApiKey();

            _model = new GenerativeModel() {
                ApiKey = apiKey,
                Model = Model.Gemini15Flash,
            };
        }

        public async Task<string> GetResponseAsync(string prompt) {
            var response = await _model.GenerateContent(prompt);
            return response.Text ?? "";
        }
    }
}