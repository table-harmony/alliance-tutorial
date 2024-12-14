using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExampleUsage.Utils {
    /// <summary>
    /// מחלקה המייצגת קובץ להעלאה
    /// </summary>
    public class File {
        /// <summary>
        /// זרם הנתונים של הקובץ
        /// </summary>
        public Stream Stream { get; set; }

        /// <summary>
        /// סוג התוכן של הקובץ (Content Type)
        /// </summary>
        public string ContentType { get; set; }
    }

    public class FileUploadResponse {
        public string FileUrl { get; set; }
        public string StorageId { get; set; }
    }

    /// <summary>
    /// ממשק להעלאת קבצים המאפשר מימושים שונים כגון העלאה לשרת מרוחק או לתיקייה מקומית
    /// </summary>
    public interface IFileUploader {
        /// <summary>
        /// מעלה קובץ ומחזיר את כתובת ה-URL שלו
        /// </summary>
        /// <param name="file">אובייקט המכיל את פרטי הקובץ להעלאה</param>
        /// <returns>כתובת URL של הקובץ שהועלה</returns>
        Task<FileUploadResponse> UploadFileAsync(File file);

        /// <summary>
        /// מקבל מזהה אחסון של קובץ ומחזיר את הקישור אליו
        /// </summary>
        /// <param name="storageId">מזהה איחסון</param>
        /// <returns>קישור לקובץ</returns>
        Task<string> GetFileUrlAsync(string storageId);
    }
}