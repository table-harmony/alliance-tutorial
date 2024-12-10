using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUploaderTutorial.Utils {
    /// <summary>
    /// מחלקה המממשת העלאת קבצים לשירות לוקלי
    /// </summary>
    public class LocalFileUploader : IFileUploader {
        private readonly string _uploadDirectory;  // תיקיית הקבצים

        public LocalFileUploader(string uploadDirectory = null) {
            _uploadDirectory = uploadDirectory 
                ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");

            if (!Directory.Exists(_uploadDirectory)) {
                Directory.CreateDirectory(_uploadDirectory);
            }
        }


        /// <summary>
        /// מעלה קובץ לתיקייה ומחזיר את כתובת הגישה אליו
        /// </summary>
        /// <param name="file">הקובץ להעלאה</param>
        /// <returns>כתובת URL לגישה לקובץ</returns>
        /// <exception cref="InvalidOperationException">כאשר נכשל לעלות קובץ</exception>
        public async Task<string> UploadFileAsync(File file) {
            try {
                string fileName = Guid.NewGuid().ToString() + GetExtension(file.ContentType);
                string filePath = Path.Combine(_uploadDirectory, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                    await file.Stream.CopyToAsync(fileStream);
                }

                return $"{_uploadDirectory}/{fileName}";
            } catch (Exception ex) {
                throw new InvalidOperationException($"Failed to upload file: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// מחשב סיומת של קובץ
        /// </summary>
        /// <param name="contentType">טיפוס הקובץ</param>
        /// <returns>סיומת הקובץ</returns>
        /// <exception cref="InvalidOperationException">כאשר טיפוס הקובץ לא נתמך</exception>
        private static string GetExtension(string contentType) {
            var mimeTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                { "image/jpeg", ".jpg" },
                { "image/png", ".png" },
                { "image/gif", ".gif" },
                { "application/pdf", ".pdf" },
                { "text/plain", ".txt" },
                { "application/zip", ".zip" },
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", ".docx" },
                { "application/vnd.ms-excel", ".xls" },
                { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ".xlsx" }
            };

            if (mimeTypes.TryGetValue(contentType, out var extension)) {
                return extension;
            }

            throw new InvalidOperationException($"Unsupported content type: {contentType}");
        }

    }
}