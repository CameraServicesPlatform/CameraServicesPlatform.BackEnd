using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.ConfigurationModel;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using DinkToPdf.Contracts;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twilio.Converters;
 
namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class FirebaseService : GenericBackendService, IFirebaseService
    {
        private readonly IConverter _pdfConverter;
        private AppActionResult _result;
        private FirebaseConfiguration _firebaseConfiguration;
        private readonly IConfiguration _configuration;

        public FirebaseService(IConverter pdfConverter, IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            _pdfConverter = pdfConverter;
            _result = new();
            _firebaseConfiguration = Resolve<FirebaseConfiguration>();
            _configuration = configuration;

        }

        public async Task<AppActionResult> DeleteFileFromFirebase(string pathFileName)
        {
            var _result = new AppActionResult();
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseConfiguration.ApiKey));

                var account = await auth.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
                var storage = new FirebaseStorage(
             _firebaseConfiguration.Bucket,
             new FirebaseStorageOptions
             {
                 AuthTokenAsyncFactory = () => Task.FromResult(account.FirebaseToken),
                 ThrowOnCancel = true
             });
                await storage
                    .Child(pathFileName)
                    .DeleteAsync();
                _result.Messages.Add("Delete image successful");
            }
            catch (FirebaseStorageException ex)
            {
                _result.Messages.Add($"Error deleting image: {ex.Message}");
            }
            return _result;
        }

        public async Task<string> GetUrlImageFromFirebase(string pathFileName)
        {
            var a = pathFileName.Split("/");
            pathFileName = $"{a[0]}%2F{a[1]}";
            var api = $"https://firebasestorage.googleapis.com/v0/b/yogacenter-44949.appspot.com/o?name={pathFileName}";
            if (string.IsNullOrEmpty(pathFileName))
            {
                return string.Empty;
            }

            var client = new RestClient();
            var request = new RestRequest(api);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jmessage = JObject.Parse(response.Content);
                var downloadToken = jmessage.GetValue("downloadTokens").ToString();
                return
                    $"https://firebasestorage.googleapis.com/v0/b/{_configuration["Firebase:Bucket"]}/o/{pathFileName}?alt=media&token={downloadToken}";
            }

            return string.Empty;
        }

        public async Task<string> GetUrlImageAfterAndBeforeFromFirebase(string pathFileName)
        {
            try
            {
                // Kiểm tra đầu vào
                if (string.IsNullOrEmpty(pathFileName))
                    return string.Empty;

                // Lấy cấu hình Firebase Bucket từ appsettings.json
                string bucket = _configuration["Firebase:Bucket"];
                if (string.IsNullOrEmpty(bucket))
                    throw new Exception("Firebase Bucket chưa được cấu hình!");

                // Firebase API để lấy metadata của file
                string api = $"https://firebasestorage.googleapis.com/v0/b/{bucket}/o/{Uri.EscapeDataString(pathFileName)}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(api);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // Parse JSON response từ Firebase
                        string content = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(content);

                        // Lấy token tải file
                        string downloadToken = json["downloadTokens"]?.ToString();
                        if (!string.IsNullOrEmpty(downloadToken))
                        {
                            // Trả về URL đầy đủ
                            return $"https://firebasestorage.googleapis.com/v0/b/{bucket}/o/{Uri.EscapeDataString(pathFileName)}?alt=media&token={downloadToken}";
                        }
                    }

                    // Nếu không thành công, trả về chuỗi rỗng
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc trả về lỗi chi tiết hơn nếu cần
                Console.WriteLine($"Lỗi khi lấy URL từ Firebase: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<AppActionResult> UploadFileToFirebase(IFormFile file, string pathFileName)
        {
            var _result = new AppActionResult();
            bool isValid = true;

            if (file == null || file.Length == 0)
            {
                isValid = false;
                _result.Messages.Add("The file is empty");
            }

            if (isValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var stream = new MemoryStream(memoryStream.ToArray());
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseConfiguration.ApiKey));
                    var account = await auth.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
                    string destinationPath = $"{pathFileName}.png"; // Add .png extension

                    // Since Firebase.Storage doesn't support metadata directly, use a workaround
                    // You could encode metadata in the file path or handle it separately
                    var task = new FirebaseStorage(
                        _firebaseConfiguration.Bucket,
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(account.FirebaseToken),
                            ThrowOnCancel = true
                        })
                        .Child(destinationPath)
                        .PutAsync(stream);

                    var downloadUrl = await task;

                    if (task != null)
                    {
                        _result.Result = downloadUrl;
                        _result.IsSuccess = true;
                    }
                    else
                    {
                        _result.IsSuccess = false;
                        _result.Messages.Add("Upload failed");
                    }
                }
            }

            return _result;
        }



        //public async Task<List<IFormFile>> GetFilesAsFormFilesAsync(List<string> fileUrls)
        //{
        //    var storageClient = StorageClient.Create();
        //    var formFiles = new List<IFormFile>();

        //    foreach (var fileUrl in fileUrls)
        //    {
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await storageClient.DownloadObjectAsync(_firebaseConfiguration.Bucket, fileUrl, memoryStream);
        //            memoryStream.Position = 0;
        //            formFiles.Add(new FormFile(memoryStream, 0, memoryStream.Length, null, Path.GetFileName(fileUrl))
        //            {
        //                Headers = new HeaderDictionary(),
        //                ContentType = "application/octet-stream"
        //            });
        //        }
        //    }

        //    return formFiles;
        //}
    }

    public class CustomMetadata
    {
        public string ContentType { get; set; }
    }
}
