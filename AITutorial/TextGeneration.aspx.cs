using AITutorial.Utils;
using System;
using System.Threading.Tasks;

namespace AITutorial {
    public partial class TextGeneration : System.Web.UI.Page {
        private readonly ITextModelService _textService = new GeminiService();

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected async void GenerateButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PromptInput.Text)) {
                ResultLabel.Text = "Please enter a prompt.";
                return;
            }

            try {
                string response = await _textService.GetResponseAsync(PromptInput.Text);
                ResultLabel.Text = response;
            } catch (Exception ex) {
                ResultLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}