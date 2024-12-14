using ExampleUsage.Utils;
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

namespace ExampleUsage {
    public partial class TextLogin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected async void LoginButton_Click(object sender, EventArgs e) {
            try {
                User user = Database.Users
                    .Where(u => u.Name == UserNameInput.Text)
                    .FirstOrDefault();

                if (user == null) {
                    StatusLabel.Text = "User not found";
                    return;
                }

                string storedEncryption = await DecodeText(user.Password);

                string fullPassword = PasswordInput.Text + ":" + user.Salt;
                string writtenEncryption = SHA256Encryption.Encrypt(fullPassword);

                if (storedEncryption != writtenEncryption) {
                    StatusLabel.Text = "Passwords do not match";
                    return;
                }

                StatusLabel.Text = "Login successfull!";
            } catch (Exception ex) {
                StatusLabel.Text = "Login failed: " + ex.Message;
            }
        }

        private async Task<string> DecodeText(string fileUrl) {
            if (new Uri(fileUrl).IsFile) {
                Bitmap image = new Bitmap(fileUrl);

                string text = Steganography.Decode(image);
                return text;
            }

            using (var client = new HttpClient()) {
                using (var stream = await client.GetStreamAsync(fileUrl)) {
                    Bitmap image = new Bitmap(stream);

                    string text = Steganography.Decode(image);
                    return text;
                }
            }
        }
    }
}