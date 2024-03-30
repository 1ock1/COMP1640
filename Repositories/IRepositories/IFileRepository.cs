using COMP1640.DTOs;
using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IFileRepository
    {
        public Task<string> CreateShareFile(string shareFile);
        public Task<string> CreateContainer(string container);

        public Task<string> UploadFile(IFormFile file, string guid);
        public Task<string> UpdateFile(IFormFile file, string guid);
        public Task<string> DeleteFile(string file);
        public Task<string> RetrieveContentBlob(string file);
        public Task<string> RetrieveDocument(string file);
        public Task<string> RetrieveDocumentCC2();
        public void SaveDocument(SaveFileDTO dto);
        public Task<string> UploadMultipleImages(List<FileReportDTO> listFileReport);
    }
}
