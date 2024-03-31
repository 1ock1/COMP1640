using Azure.Storage.Blobs;
using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Repositories.Services.FileReportRepository
{
    public class FileReportServices : IFileReportRepository
    {
        private readonly DataContext dataContext;
        public FileReportServices(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<FileReportResponseDTO> GetAllFileOfOneReport(int reportId)
        {
            List<FileReportResponseDTO> list = new List<FileReportResponseDTO>();
            var result = this.dataContext.FileReports.Where(fr => fr.ReportId == reportId).ToList();
            foreach(var resultItem in result)
            {
                FileReportResponseDTO response = new()
                {
                    Id = resultItem.Id,
                    Type = resultItem.Type,
                };
                list.Add(response);
            }
            return list;
        }

        public string GetDocumentId(int reportId)
        {
            var result = this.dataContext.FileReports.FirstOrDefault(fr => fr.ReportId == reportId && fr.Type=="document");
            if (result == null)
            {
                return "-1";
            }
            return result.Id;
        }

        public async Task<List<DocumentImagesDTO>> GetDocumentImages(ReportImagesDTO dto)
        {
            List<DocumentImagesDTO> list = new List<DocumentImagesDTO>();
            var result = await this.dataContext.FileReports.Where(fr => fr.ReportId == dto.ReportId && fr.Type == dto.Type).ToListAsync();
            if(result.Count == 0) 
            {
                return null;
            }
            else
            {
                foreach (var item in result)
                {
                    DocumentImagesDTO images = new()
                    {
                        Id = item.Id,
                        Name = item.Name,
                    };
                    list.Add(images);
                }
                return list;
            }

        }

        public async Task<List<FileReportDTO>> UploadImagesInDatabase(UploadImagesDTO dto)
        {
            List<FileReportDTO> result = new List<FileReportDTO>();
            try
            {
                if (dto.Files == null || !dto.Files.Any())
                {
                    return null;
                }
                foreach (IFormFile file in dto.Files)
                {
                    Guid id = Guid.NewGuid();
                    FileReport fileReport = new()
                    {
                        Id = id.ToString(),
                        Name = file.FileName,
                        Type = "image",
                        ReportId = dto.ReportId,
                    };
                    FileReportDTO fileReportDTO = new()
                    {
                        Id = id.ToString(),
                        File = file,
                    };
                    result.Add(fileReportDTO);
                    this.dataContext.FileReports.Add(fileReport);
                    await this.dataContext.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
