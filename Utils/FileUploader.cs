using Newtonsoft.Json;

namespace Utils {
    /// <summary>
    /// Provides functionality to upload files to a remote server.
    /// </summary>
    public static class FileUploader {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string API_URL = "https://colorless-shrimp-958.convex.site";

        /// <summary>
        /// Uploads a file to the remote server and returns the URL of the uploaded file.
        /// </summary>
        /// <param name="file">The file to be uploaded.</param>
        /// <returns>The URL of the uploaded file.</returns>
        public static async Task<string> UploadFileAsync(HttpPostedFile file) {
            string uploadUrl = await GenerateUploadUrlAsync();
            string storageId = await UploadToUrlAsync(uploadUrl, file);
            string fileUrl = await GetFileUrlAsync(storageId);

            return fileUrl;
        }

        /// <summary>
        /// Generates an upload URL from the remote server.
        /// </summary>
        /// <returns>The generated upload URL.</returns>
        private static async Task<string> GenerateUploadUrlAsync() {
            var response = await _httpClient.PostAsync($"{API_URL}/generateUploadUrl", null);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(content);
            return result.uploadUrl;
        }

        /// <summary>
        /// Uploads a file to the specified URL.
        /// </summary>
        /// <param name="uploadUrl">The URL to upload the file to.</param>
        /// <param name="file">The file to be uploaded.</param>
        /// <returns>The storage ID of the uploaded file.</returns>
        private static async Task<string> UploadToUrlAsync(string uploadUrl, HttpPostedFile file) {
            using (var content = new StreamContent(file.InputStream)) {
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                var response = await _httpClient.PostAsync(uploadUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(responseContent);
                return result.storageId;
            }
        }

        /// <summary>
        /// Retrieves the file URL for a given storage ID from the remote server.
        /// </summary>
        /// <param name="storageId">The storage ID of the file.</param>
        /// <returns>The URL of the file.</returns>
        private static async Task<string> GetFileUrlAsync(string storageId) {
            var response = await _httpClient.GetAsync($"{API_URL}/getFileUrl?storageId={storageId}");
            var responseContent = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            dynamic result = JsonConvert.DeserializeObject(responseContent);
            if (result?.fileUrl == null) {
                throw new InvalidOperationException($"File URL not found in the response. Response: {responseContent}");
            }

            return result.fileUrl;
        }
    }
}