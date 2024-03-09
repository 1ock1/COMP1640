using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Files.Shares;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.DocIO.DLS;
using System.Text.Json.Nodes;
using Syncfusion.EJ2.DocumentEditor;
using WordDocument = Syncfusion.EJ2.DocumentEditor.WordDocument;
using System.Runtime.InteropServices.JavaScript;

namespace COMP1640.Repositories.Services.UserService
{
    public class UserService : IUserRepository
    {
        private readonly DataContext _dataContext;
        private string connectionString = "DefaultEndpointsProtocol=https;AccountName=comp1640storage;AccountKey=2NKxU3inA06uyA64hwJeBtofizsRP+TRzG5wbkZmbzFLMiMJIp0ToAoiefMxLzFEk8kUXBrxpQMv+ASt6f1FNw==;EndpointSuffix=core.windows.net";
        public UserService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<string> CreateShareFile(string shareFile)
        {
            ShareServiceClient serviceClient = new ShareServiceClient(this.connectionString);
            ShareClient shareClient = serviceClient.GetShareClient(shareFile);
            if(!shareClient.Exists())
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
        public async Task<string> UploadFile(IFormFile file)
        {
            var blobServiceClient = new BlobServiceClient(this.connectionString);
            var fileContainer = blobServiceClient.GetBlobContainerClient("hehe");
            BlobClient client = fileContainer.GetBlobClient(file.FileName);
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
        public async Task<string> RetrieveDocument()
        {
            Stream stream = new MemoryStream();
            BlobServiceClient blobServiceClient = new BlobServiceClient(this.connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("hehe");
            BlockBlobClient blockBlobClient = containerClient.GetBlockBlobClient("cc.docx");
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
    }
}
