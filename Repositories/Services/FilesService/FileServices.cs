using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Syncfusion.EJ2.DocumentEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using Azure.Core;
using COMP1640.DTOs;
using COMP1640.Models;

namespace COMP1640.Repositories.Services.FilesService
{
    public class FileServices : IFileRepository
    {
        private readonly DataContext _dataContext;
        private string connectionString = "DefaultEndpointsProtocol=https;AccountName=comp1640storage;AccountKey=2NKxU3inA06uyA64hwJeBtofizsRP+TRzG5wbkZmbzFLMiMJIp0ToAoiefMxLzFEk8kUXBrxpQMv+ASt6f1FNw==;EndpointSuffix=core.windows.net";
        public FileServices(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<string> CreateShareFile(string shareFile)
        {
            ShareServiceClient serviceClient = new ShareServiceClient(this.connectionString);
            ShareClient shareClient = serviceClient.GetShareClient(shareFile);
            if (!shareClient.Exists())
            {
                shareClient.Create();
                return "Create share file";
            }
            else
            {
                return "hehe";
            }
        }

        public async Task<string> CreateContainer(string containerName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(this.connectionString);
            BlobContainerClient container = await blobServiceClient.CreateBlobContainerAsync(containerName);
            if (await container.ExistsAsync())
            {
                return "Created Container Successfully";
            }
            return "Failure";
        }
        public async Task<string> UploadFile(IFormFile file, string guid)
        {
            var blobServiceClient = new BlobServiceClient(this.connectionString);
            var fileContainer = blobServiceClient.GetBlobContainerClient("hehe");
            Console.WriteLine(file.FileName);
            BlobClient client = fileContainer.GetBlobClient(guid);
            using (Stream stream = file.OpenReadStream())
            {
                await client.UploadAsync(stream, true);
            }
            return "Uploaded File Successfully";
        }
        public async Task<string> DeleteFile(string file)
        {
            var blobServiceClient = new BlobServiceClient(this.connectionString);
            var fileContainer = blobServiceClient.GetBlobContainerClient("hehe");
            var result = await this._dataContext.FileReports.FindAsync(file);
            if (result == null)
            {
                return "Not Found";
            }
            this._dataContext.FileReports.Remove(result);
            await this._dataContext.SaveChangesAsync();
            BlobClient client = fileContainer.GetBlobClient(file);
            await client.DeleteAsync();
            return "Deleted Successfully";
        }
        public async Task<string> RetrieveContentBlob(string file)
        {
            var blobServiceClient = new BlobServiceClient(this.connectionString);
            var fileContainer = blobServiceClient.GetBlobContainerClient("hehe");
            BlobClient client = fileContainer.GetBlobClient(file);
            BlobDownloadResult blobDownloadInfo = await client.DownloadContentAsync();
            Console.WriteLine(blobDownloadInfo.Content);
            return "cc";
        }
        public async Task<string> RetrieveDocument(string file)
        {
            Stream stream = new MemoryStream();
            BlobServiceClient blobServiceClient = new BlobServiceClient(this.connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("hehe");
            BlockBlobClient blockBlobClient = containerClient.GetBlockBlobClient(file);
            blockBlobClient.DownloadTo(stream);
            WordDocument document = WordDocument.Load(stream, FormatType.Docx);
            document.OptimizeSfdt = false;
            Console.WriteLine(document);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(document);
            document.Dispose();
            stream.Close();
            return json;
        }
        public async Task<string> RetrieveDocumentCC2()
        {
            MemoryStream stream = new MemoryStream();
            BlobServiceClient blobServiceClient = new BlobServiceClient(this.connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("hehe");
            BlockBlobClient blockBlobClient = containerClient.GetBlockBlobClient("cc2.doc");
            blockBlobClient.DownloadTo(stream);
            WordDocument document = WordDocument.Load(stream, FormatType.Doc);
            Console.WriteLine("ehee");
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(document);
            document.Dispose();
            stream.Close();
            return json;
        }
        private string GetValue(IFormCollection data, string key)
        {
            if (data.ContainsKey(key))
            {
                string[] values = data[key];
                if (values.Length > 0)
                {
                    return values[0];
                }
            }
            return "";
        }
        public async void SaveDocument(SaveFileDTO dto)
        {
            if (dto.data.Files.Count == 0)
                return;
            Console.WriteLine(dto.data.Files[0]);
            try
            {
                BlobClientOptions blobOptions = new BlobClientOptions()
                {
                    Retry = {
                    Delay = TimeSpan.FromSeconds(2),
                    MaxRetries = 10,
                    Mode = RetryMode.Exponential,
                    MaxDelay = TimeSpan.FromSeconds(10),
                    NetworkTimeout = TimeSpan.FromSeconds(100)
                },
                };
                BlobServiceClient blobServiceClient = new BlobServiceClient(this.connectionString, blobOptions);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("hehe");

                IFormFile file = dto.data.Files[0];

                // Get a reference to the blob
                BlobClient blobClient = containerClient.GetBlobClient(dto.Name);
                using (Stream stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        public async Task<string> UploadMultipleImages(List<FileReportDTO> listFileReport)
        {
            try
            {
                if (listFileReport == null || !listFileReport.Any())
                {
                    return "Not Found";
                }
                var blobServiceClient = new BlobServiceClient(this.connectionString);
                var fileContainer = blobServiceClient.GetBlobContainerClient("hehe");
                foreach (FileReportDTO dto in listFileReport)
                {
                    BlobClient client = fileContainer.GetBlobClient(dto.Id);
                    using (Stream stream = dto.File.OpenReadStream())
                    {
                        await client.UploadAsync(stream, true);
                    }
                }
                return "Upload Images SuccessFully";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Upload Failure";
            }
        }
    }
}
