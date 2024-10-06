using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _bucketName = "your-firebase-storage-bucket"; // Replace with your actual bucket name

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file provided");
            }

            try
            {
                // Load credentials and initialize Google Cloud Storage client
                var credential = GoogleCredential.FromFile("firebase-adminsdk.json");
                var storageClient = await StorageClient.CreateAsync(credential);

                // Generate a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Upload the file to Firebase Cloud Storage
                using (var stream = file.OpenReadStream())
                {
                    var storageObject = await storageClient.UploadObjectAsync(_bucketName, fileName, null, stream, new UploadObjectOptions
                    {
                        PredefinedAcl = PredefinedObjectAcl.PublicRead
                    });
                }

                // Return the public URL
                return $"https://storage.googleapis.com/{_bucketName}/{fileName}";
            }
            catch (Exception ex)
            {
                throw new Exception($"File upload failed: {ex.Message}");
            }
        }
    }
}
