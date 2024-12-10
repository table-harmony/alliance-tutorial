using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Utils;

namespace WebApplication1 {
    public partial class VerifyPassword2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        /// <summary>
        /// Decode text from a stream
        /// </summary>
        /// <param name="stream">Stream from which to decode</param>
        /// <returns>Decoded text</returns>
        private string DecodeText(Stream stream) {
            Bitmap image = new Bitmap(stream);

            string text = Steganography.Decode(image);
            return text;
        }

        /// <summary>
        /// decode text from a file
        /// </summary>
        /// <param name="fileUrl">the file url from which decode</param>
        /// <returns>decoded text from a file</returns>
        private async Task<string> DecodeText(string fileUrl) {
            using (var client = new HttpClient()) {
                using (var stream = await client.GetStreamAsync(fileUrl)) {
                    Bitmap image = new Bitmap(stream);

                    string text = Steganography.Decode(image);
                    return text;
                }
            }
        }

        protected async void VerifyButton_Click(object sender, EventArgs e) {
            if (!FileUploadControl.HasFile)
                StatusLabel.Text = "Please select a file to upload.";

            try {
                var fileStream = FileUploadControl.FileContent;
                string inputHash = DecodeText(fileStream);

                // זאת הסיסמה של המשתמש
                // במסד הנתונים נשמור קישור לתמונה שבה מוצפנת הסיסמה
                string dbHash = await DecodeText("https://colorless-shrimp-958.convex.cloud/api/storage/e82dafc2-8552-4e40-8c50-7ff9cec63f11");

                if (inputHash == dbHash) {
                    StatusLabel.Text = "Password verified successfully!";
                } else {
                    StatusLabel.Text = "Incorrect password";
                }
            } catch (Exception ex) {
                StatusLabel.Text = "Upload failed: " + ex.Message;
            }
        }
    }
}