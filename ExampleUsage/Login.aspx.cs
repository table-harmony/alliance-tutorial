using ExampleUsage.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExampleUsage {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected async void LoginButton_Click(object sender, EventArgs e) {
            if (!PasswordFileInput.HasFile && string.IsNullOrEmpty(PasswordTextInput.Text)) {
                StatusLabel.Text = "Please select a password.";
                return;
            }

            User user = Database.Users
                .Where(u => u.Name == UserNameInput.Text)
                .FirstOrDefault();

            if (user == null) {
                StatusLabel.Text = "User not found";
                return;
            }

            try {
                StatusLabel.Text = "Login successfull!";

                string storedEncryption = await DecodeText(user.Password);

                if (!string.IsNullOrEmpty(PasswordTextInput.Text)) {
                    string writtenEncryption = SHA256Encryption.Encrypt(PasswordTextInput.Text);

                    if (writtenEncryption != storedEncryption) {
                        StatusLabel.Text = "Passwords do not match";
                    }
                } else if (PasswordFileInput.HasFile) {
                    string uploadedEncryption = DecodeText(PasswordFileInput.FileContent);

                    if (storedEncryption != uploadedEncryption) {
                        StatusLabel.Text = "Passwords do not match";
                    }
                }

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

        private string DecodeText(Stream stream) {
            Bitmap image = new Bitmap(stream);

            string text = Steganography.Decode(image);
            return text;
        }
    }
}