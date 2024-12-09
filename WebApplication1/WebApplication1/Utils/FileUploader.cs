using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApplication1.Utils {
    /// <summary>
    /// קובץ
    /// </summary>
    public class File {
        public Stream Stream { get; set; }
        public string ContentType { get; set; }
    }

    /// <summary>
    /// ממשק להעלאת קבצים במקרה ויש מספר מימושים להעלאת קובץ כגון בתיקייה לוקלית
    /// </summary>
    public interface IFileUploader {
        Task<string> UploadFileAsync(File file);
    }

    /// <summary>
    /// העלאת קובץ של לירון לאחסון convex
    /// </summary>
    public class FileUploader : IFileUploader {
        private readonly HttpClient _httpClient;
        private readonly string API_URL = "https://colorless-shrimp-958.convex.site";

        public FileUploader() {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// הפעולה מקבלת מופע מן המחלקה קובץ ומחזירה קישור לקובץ
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> UploadFileAsync(File file) {
            string uploadUrl = await GenerateUploadUrlAsync();
            string storageId = await UploadToUrlAsync(uploadUrl, file);
            string fileUrl = await GetFileUrlAsync(storageId);

            return fileUrl;
        }

        /// <summary>
        /// הפעולה מייצרת קישור להעלאה
        /// </summary>
        /// <returns>קישור העלאה</returns>
        private async Task<string> GenerateUploadUrlAsync() {
            var response = await _httpClient.PostAsync($"{API_URL}/generateUploadUrl", null);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(content);
            return result.uploadUrl;
        }


        /// <summary>
        /// הפעולה מעלה קובץ לקישור
        /// </summary>
        /// <param name="uploadUrl">קישור</param>
        /// <param name="file">קובץ</param>
        /// <returns>הפעולה מחזירה את הכתובת של הקובץ באחסון</returns>
        private async Task<string> UploadToUrlAsync(string uploadUrl, File file) {
            using (var content = new StreamContent(file.Stream)) {
                content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                var response = await _httpClient.PostAsync(uploadUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseContent);
                return result.storageId;
            }
        }

        /// <summary>
        /// הפעולה מקבלת כתובת אחסון ומחזירה קישור הקובץ
        /// </summary>
        /// <param name="storageId">כתובת אחסון</param>
        /// <returns>קישור הקובץ</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private async Task<string> GetFileUrlAsync(string storageId) {
            var response = await _httpClient.GetAsync($"{API_URL}/getFileUrl?storageId={storageId}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);

            if (result?.fileUrl == null) {
                throw new InvalidOperationException($"File URL not found in the response. Response: {responseContent}");
            }

            return result.fileUrl;
        }
    }
}