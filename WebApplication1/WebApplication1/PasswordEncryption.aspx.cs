using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Utils;

using File = WebApplication1.Utils.File;

namespace WebApplication1 {
    public partial class PasswordEncryption : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        /// <summary>
        /// Get random image
        /// </summary>
        /// <param name="width">width of the image</param>
        /// <param name="height">height of the image</param>
        /// <returns>bitmap of the image</returns>
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

        /// <summary>
        /// Encrypt text onto an image
        /// </summary> 
        /// <param name="plainText">text to be encrypted</param>
        /// <returns>a stream of the image</returns>
        private async Task<MemoryStream> EncryptTextToImage(string plainText) {
            var randomImage = await GetRandomImageAsync(500, 500);
            var encryptedImage = Steganography.Encode(plainText, randomImage);

            var memoryStream = new MemoryStream();
            encryptedImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            memoryStream.Position = 0;

            return memoryStream;
        } 

        protected async void EncryptButton_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(PasswordInput.Text)) {
                    StatusLabel.Text = "Please enter a password";
                    return;
                }

                string encryptedPassword = SHA256Encryption.Encrypt(PasswordInput.Text);
                var imageStream = await EncryptTextToImage(encryptedPassword);

                var fileUploader = new FileUploader();
                var file = new File {
                    Stream = imageStream,
                    ContentType = "image/png"
                };

                string fileUrl = await fileUploader.UploadFileAsync(file);
                StatusLabel.Text = "Password encrypted successfully! Image URL: " + fileUrl;

                // פה נשמור את הקישור לתמונה למסד הנתונים
                // ניתן כפי שעשיתי להציג למשתמש את הקישור לתמונה
            } catch (Exception ex) {
                StatusLabel.Text = "Encryption failed: " + ex.Message;
            }
        }
    }
}