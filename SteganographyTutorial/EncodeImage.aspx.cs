using SteganographyTutorial.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using File = SteganographyTutorial.Utils.File;

namespace SteganographyTutorial {
    public partial class EncodeImage : System.Web.UI.Page {
        protected IFileUploader fileUploader = new LocalFileUploader();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected async void EncodeButton_Click(object sender, EventArgs e) {
            if (!FileUpload.HasFile) {
                StatusLabel.Text = "Please select a file to encode.";
                return;
            }

            if (string.IsNullOrEmpty(SecretMessage.Text)) {
                StatusLabel.Text = "Please enter a message to hide.";
                return;
            }

            try {
                using (Bitmap uploadedFile = new Bitmap(FileUpload.FileContent)) {
                    Bitmap encodedFile = Steganography.Encode(SecretMessage.Text, uploadedFile);

                    using (MemoryStream memoryStream = new MemoryStream()) {
                        encodedFile.Save(memoryStream, ImageFormat.Png);
                        memoryStream.Position = 0;

                        File file = new File {
                            Stream = memoryStream,
                            ContentType = "image/png",
                        };

                        string fileUrl = await fileUploader.UploadFileAsync(file);
                        StatusLabel.Text = "Encoded data succefully onto this image: " + fileUrl;
                    }
                }
            } catch (Exception ex) {
                StatusLabel.Text = "Error encoding file: " + ex.Message;
            }
        }
    }
}