using SteganographyTutorial.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteganographyTutorial {
    public partial class DecodeImage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void DecodeButton_Click(object sender, EventArgs e) {
            if (!FileUpload.HasFile) {
                StatusLabel.Text = "Please select a file to decode.";
                return;
            }

            try {
                using (Bitmap image = new Bitmap(FileUpload.FileContent)) {
                    string message = Steganography.Decode(image);

                    if (string.IsNullOrEmpty(message)) {
                        StatusLabel.Text = "No hidden message found or message is corrupted.";
                        return;
                    }

                    ResultPanel.Visible = true;
                    MessageLabel.Text = message;
                    StatusLabel.Text = "";
                }
            } catch (Exception ex) {
                StatusLabel.Text = "Failed decoding file: " + ex.Message;
            }
        }
    }
}