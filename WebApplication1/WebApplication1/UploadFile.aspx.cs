using System;
using WebApplication1.Utils;

namespace WebApplication1 {
    public partial class UploadFile : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected async void UploadButton_Click(object sender, EventArgs e) {
            if (!FileUploadControl.HasFile)
                StatusLabel.Text = "Please select a file to upload.";

            try {
                var fileUploader = new FileUploader();
                var file = new File {
                    Stream = FileUploadControl.FileContent,
                    ContentType = FileUploadControl.PostedFile.ContentType
                };

                string fileUrl = await fileUploader.UploadFileAsync(file);
                StatusLabel.Text = "Upload successful! File URL: " + fileUrl;
            } catch (Exception ex) {
                StatusLabel.Text = "Upload failed: " + ex.Message;
            }
        }

    }
}