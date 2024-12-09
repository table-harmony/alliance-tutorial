using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Utils;

namespace WebApplication1 {
    public partial class UploadFile2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["submit"] != null) {
                HandleFileUpload();
            }
        }

        private async void HandleFileUpload() {
            try {
                HttpPostedFile postedFile = Request.Files["fileUpload"];

                if (postedFile == null || postedFile.ContentLength == 0) {
                    StatusLabel.Text = "Please select a file to upload.";
                    return;
                }

                var fileUploader = new FileUploader();
                var file = new File {
                    Stream = postedFile.InputStream,
                    ContentType = postedFile.ContentType
                };

                string fileUrl = await fileUploader.UploadFileAsync(file);
                StatusLabel.Text = "Upload successful! File URL: " + fileUrl;
            } catch (Exception ex) {
                StatusLabel.Text = "Upload failed: " + ex.Message;
            }
        }
    }
}