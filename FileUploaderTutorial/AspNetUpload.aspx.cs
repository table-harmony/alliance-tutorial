using FileUploaderTutorial.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FileUploaderTutorial {
    public partial class AspNetUpload : System.Web.UI.Page {
        protected IFileUploader fileUploader = Global.ServiceProvider.GetService<IFileUploader>();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected async void UploadButton_Click(object sender, EventArgs e) {
            if (!FileUploadControl.HasFile) {
                StatusLabel.Text = "Please select a file to upload.";
                return;
            }

            try {
                var file = new File {
                    Stream = FileUploadControl.FileContent,
                    ContentType = FileUploadControl.PostedFile.ContentType
                };

                string fileUrl = await fileUploader.UploadFileAsync(file);
                
                StatusLabel.Text = "File uploaded successfully! " + fileUrl;
            } catch (Exception ex) {
                StatusLabel.Text = "Upload failed: " + ex.Message;
            }
        }
    }
}