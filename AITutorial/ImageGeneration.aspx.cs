using AITutorial.Utils;
using FileUploaderTutorial.Utils;
using System;
using System.Threading.Tasks;

namespace AITutorial {
    public partial class ImageGeneration : System.Web.UI.Page {
        private readonly IImageModelService _imageService = new StabilityService();
        private readonly IFileUploader _fileUploader = new LocalFileUploader();

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected async void GenerateButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PromptInput.Text)) {
                ErrorLabel.Text = "Please enter a prompt.";
                return;
            }
        
            try {
                var image = new Image();

                var request = new ImageGenerationRequest() {
                    Image = new Image(),
                    Prompt = PromptInput.Text
                };

                var imageStream = await _imageService.GenerateImageAsync(request);

                var file = new File() {
                    Stream = imageStream,
                    ContentType = $"image/{request.Image.Format}",
                };

                string imageUrl = await _fileUploader.UploadFileAsync(file);

                ResultImage.ImageUrl = imageUrl;
                ResultImage.Visible = true;
                ErrorLabel.Text = "";
            } catch (Exception ex) {
                ResultImage.Visible = false;
                ErrorLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}