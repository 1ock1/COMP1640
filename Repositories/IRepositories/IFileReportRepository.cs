using COMP1640.DTOs;
using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IFileReportRepository
    {
        public string GetDocumentId(int reportId);
        public Task<List<FileReportDTO>> UploadImagesInDatabase(UploadImagesDTO dto);
        public Task<List<DocumentImagesDTO>> GetDocumentImages(ReportImagesDTO dto);
        public List<FileReportResponseDTO> GetAllFileOfOneReport(int reportId);
    }
}
