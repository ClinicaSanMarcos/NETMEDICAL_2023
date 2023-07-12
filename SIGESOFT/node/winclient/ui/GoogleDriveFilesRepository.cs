using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Web;

namespace Sigesoft.Node.WinClient.BLL
{
    public class GoogleDriveFilesRepository
    {
        public void SaveFileOnGoogleDrive(string nameFile, byte[] fileBytes, string nameForDrive)
        {
            var path = "";
            if (fileBytes == null)
            {
                if (nameFile.Contains("ESPIROMETRÍA"))
                {
                    path = Common.Utils.GetApplicationConfigValue("ImgESPIROOrigen").ToString();
                }
                else if (nameFile.Contains("CARDIOLOGÍA"))
                {
                    path = Common.Utils.GetApplicationConfigValue("ImgEKGOrigen").ToString();
                }
                else if (nameFile.Contains("PSICOLOGÍA"))
                {
                    path = Common.Utils.GetApplicationConfigValue("ImgPSICOOrigen").ToString();
                }
                else if (nameFile.Contains("RAYOS"))
                {
                    path = Common.Utils.GetApplicationConfigValue("ImgRxOrigen").ToString();
                }
                else if (nameFile.Contains("LABORA"))
                {
                    path = Common.Utils.GetApplicationConfigValue("ImgLABOrigen").ToString();
                }
            }
            
            string[] scopes = new string[] { DriveService.Scope.Drive,
                          DriveService.Scope.DriveAppdata,
                          DriveService.Scope.DriveFile,
                          DriveService.Scope.DriveMetadataReadonly,
                          DriveService.Scope.DriveReadonly,
                          DriveService.Scope.DriveScripts };
            var clientId = Common.Utils.GetApplicationConfigValue("ClientIdGoogleDrive").ToString();
            var clientSecret = Common.Utils.GetApplicationConfigValue("ClientSecretGoogleDrive").ToString();

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret,

            },
            scopes,
            Environment.UserName,
            CancellationToken.None,
            new FileDataStore("Default")).Result;
           
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "CTM",
            });

            string filePath = path + nameFile;
            if (fileBytes == null)
            {
                uploadFile(service, filePath, "Envíos NATCLAR", nameForDrive, "pdf");
            }
            else
            {
                Image newImg = ConvertByteArrayToImage(fileBytes);
                var rutaImagenesTemporales = Common.Utils.GetApplicationConfigValue("ImagenesTemporales").ToString();
                var rutaImagen = rutaImagenesTemporales + nameForDrive + ".jpg";
                bool ok = SaveImage(newImg, rutaImagen);
                if (ok)
                {
                    uploadFile(service, rutaImagen, "Envíos NATCLAR", nameForDrive, "jpg");
                }
                
            }

            
        }
        public static void uploadFile(DriveService _service, string _uploadFile, string _descrp, string nameForDrive, string ext)
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                var body = new Google.Apis.Drive.v3.Data.File();
                body.Name = nameForDrive;
                string folderId = Common.Utils.GetApplicationConfigValue("FolderIdGoogleDrive").ToString();
                body.Description = _descrp;
                body.MimeType = GetMimeType(ext);
                if (folderId != null)
                {
                    body.Parents = new List<string>
                    {
                        folderId
                    };
                }
                

                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(_uploadFile, System.IO.FileMode.Open))
                {
                    request = _service.Files.Create(body, stream, body.MimeType);

                    request.Fields = "id";
                    request.Upload();
                }
                var file = request.ResponseBody;
                var fili = file.Id;
            }

        }

        private static string GetMimeType(string ext)
        {
            string mimeType = "application/unknown";
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        public Image ConvertByteArrayToImage(byte[] bytes)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes);
            return Image.FromStream(stream);
        }

        public bool SaveImage(Image image, string path)
        {
            try
            {
                image.Save(path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        
    }
}
