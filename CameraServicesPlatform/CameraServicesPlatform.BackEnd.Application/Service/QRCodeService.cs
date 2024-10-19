using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.Common.Utils;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class QRCodeService : GenericBackendService, IQRCodeService
    {
        private readonly IFirebaseService _firebaseService;
        private readonly IUnitOfWork _unitOfWork;

        public QRCodeService(IServiceProvider serviceProvider,
            IFirebaseService firebaseService,
            IUnitOfWork unitOfWork
            ) : base(serviceProvider)
        {
            _firebaseService = firebaseService;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppActionResult> DecodeQR(string hashedAccountData)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                //string decryptData = DecryptData(hashedAccountData, SD.QR_CODE_KEY);
                //if(decryptData != null)
                //{
                //}
                string[] data = hashedAccountData.Split(',');
                result.Result = new QRAccountResponse
                {
                    FullName = data[0],
                    PhoneNumber = data[1],
                    Email = data[2]
                };
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        public async Task<AppActionResult> GenerateQR(string Id)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                UploadImgResponseDto dto = new UploadImgResponseDto();
                string qrAccountString = $"{Id}";
                //string encryptAccountResponseString = EncryptData(qrAccountString, SD.QR_CODE_KEY);
                string pathName = SD.FirebasePathName.QR_PREFIX + Id;
                IFormFile qr = CreateQRCode(qrAccountString);
                var url = await _firebaseService.UploadFileToFirebase(qr, pathName);
                if (url.IsSuccess)
                {
                    dto.file = qr;
                    dto.url = (string)url.Result;
                }
                result.Result = dto;
            }
            catch (Exception ex)
            {
                result = BuildAppActionResultError(result, ex.Message);
            }
            return result;
        }

        /* public IFormFile GenerateQRCodeImage(string data)
         {
             GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(data, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);

             // Save barcode as PNG in memory
             byte[] barcodeBytes = barcode.ToPngBinaryData();

             // Create a MemoryStream from the barcode bytes
             MemoryStream ms = new MemoryStream(barcodeBytes);

             // Create an IFormFile from the MemoryStream
             IFormFile formFile = new FormFile(ms, 0, ms.Length, "barcode.png", "image/png");

             // Set the position of the MemoryStream back to the beginning for subsequent reads
             ms.Position = 0;

             return formFile;
         }*/

        public IFormFile CreateQRCode(string qrCodeText)
        {
            byte[] qrCodeBytes;
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData data = qRCodeGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode bitmap = new BitmapByteQRCode(data);
            qrCodeBytes = bitmap.GetGraphic(20);

            MemoryStream ms = new MemoryStream(qrCodeBytes);

            // Create an IFormFile from the MemoryStream
            IFormFile formFile = new FormFile(ms, 0, ms.Length, "qrCode", "qrCode.png")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png"
            };

            // Reset the position of the MemoryStream to 0 for subsequent reads
            ms.Position = 0;

            return formFile;
        }


        private string EncryptData(string data, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                aes.IV = new byte[16]; // Assuming a zero IV for simplicity
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new System.IO.StreamWriter(cs))
                        {
                            sw.Write(data);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string DecryptData(string encryptedData, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = new byte[16];
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;// Assuming a zero IV for simplicity
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(Convert.FromBase64String(encryptedData)))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
