using ExampleUsage.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.IO;
using File = ExampleUsage.Utils.File;
using MimeTypes;
using System.Net.Mime;

namespace ExampleUsage {
    public partial class Register : System.Web.UI.Page {
        protected IFileUploader fileUploader = new LocalFileUploader();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected async void RegisterButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(PasswordInput.Text) || 
                string.IsNullOrEmpty(UserNameInput.Text)) {
                StatusLabel.Text = "Please fill in a password and a username";
                return;
            }

            try {
                User user = new User() {
                    Name = UserNameInput.Text,
                    Password = PasswordInput.Text,
                    Salt = SHA256Encryption.GenerateSalt(),
                };

                User existingUser = Database.Users
                    .Where(u => u.Name == user.Name)
                    .FirstOrDefault();

                if (existingUser != null) {
                    StatusLabel.Text = "User already exists with name";
                    return;
                }

                string fullPassword = user.Password + ":" + user.Salt;
                string encryption = SHA256Encryption.Encrypt(fullPassword);

                var imageStream = await EncryptTextToImage(encryption);
                var file = new File {
                    Stream = imageStream,
                    ContentType = "image/png"
                };

                string fileUrl = await fileUploader.UploadFileAsync(file);

                user.Password = fileUrl;
                Database.Users.Add(user);

                // Download password image
                Response.ContentType = "image/png";
                Response.AddHeader("Content-Disposition", $"attachment; filename={user.Name}_password.png");
                imageStream.Position = 0;
                await imageStream.CopyToAsync(Response.OutputStream);
            } catch (Exception ex) {
                 StatusLabel.Text = "Registration Failed: " + ex.Message;
            }
        }


        private async Task<MemoryStream> EncryptTextToImage(string plainText) {
            var randomImage = await GetRandomImageAsync(500, 500);
            var encryptedImage = Steganography.Encode(plainText, randomImage);

            var memoryStream = new MemoryStream();
            encryptedImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            memoryStream.Position = 0;

            return memoryStream;
        }

        private async Task<Bitmap> GetRandomImageAsync(int width, int height) {
            using (var client = new HttpClient()) {
                var response = await client.GetAsync($"https://picsum.photos/{width}/{height}");
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync()) {
                    var bitmap = new Bitmap(stream);
                    return bitmap;
                }
            }
        }
    }
}