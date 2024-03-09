using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IUserRepository
    {
        public Task<string> CreateShareFile(string shareFile);
        public Task<string> CreateContainer(string container);

        public Task<string> UploadFile(IFormFile file);
        public Task<string> DeleteFile(string file);
        public Task<string> RetrieveContentBlob(string file);
        public Task<string> RetrieveDocument();
        public Task<string> RetrieveDocumentCC2();
    }
}
