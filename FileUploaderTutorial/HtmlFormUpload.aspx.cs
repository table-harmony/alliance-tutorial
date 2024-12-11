using FileUploaderTutorial.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploaderTutorial {
    public partial class HtmlFormUpload : System.Web.UI.Page {
        protected readonly IFileUploader fileUploader = new LocalFileUploader();

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