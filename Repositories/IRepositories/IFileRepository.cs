namespace COMP1640.Repositories.IRepositories
{
    public interface IFileRepository
    {
        public Task<string> CreateShareFile(string shareFile);
        public Task<string> CreateContainer(string container);

        public Task<string> UploadFile(IFormFile file, string guid);
        public Task<string> DeleteFile(string file);
        public Task<string> RetrieveContentBlob(string file);
        public Task<string> RetrieveDocument(string file);
        public Task<string> RetrieveDocumentCC2();
        public void SaveDocument(IFormCollection data);
        public Task<string> UploadMultipleImages(List<IFormFile> files);
    }
}
