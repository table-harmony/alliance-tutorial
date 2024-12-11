using AITutorial.Utils;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AITutorial {
    public partial class SpeechGeneration : System.Web.UI.Page {
        private readonly ITextToSpeechService _speechService = new ElevenLabsService();

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected async void GenerateButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PromptInput.Text)) {
                ErrorLabel.Text = "Please enter text to convert.";
                return;
            }

            try {
                var request = new SpeechGenerationRequest {
                    Prompt = PromptInput.Text,
                };

                using (var audioStream = await _speechService.GenerateSpeechAsync(request))
                using (var memoryStream = new MemoryStream()) {
                    await audioStream.CopyToAsync(memoryStream);
                    string base64Audio = Convert.ToBase64String(memoryStream.ToArray());
                    audioPlayer.Src = $"data:audio/mpeg;base64,{base64Audio}";
                    audioPlayer.Visible = true;
                    ErrorLabel.Text = "";
                }
            } catch (Exception ex) {
                ErrorLabel.Text = $"Error: {ex.Message}";
                audioPlayer.Visible = false;
            }
        }
    }
}