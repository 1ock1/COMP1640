using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Linq;

namespace COMP1640.Repositories.Services.PublishedReportServices
{
    public class PublishedReportService : IPublishedReportRepository
    {
        private readonly DataContext _dataContext;
        public PublishedReportService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<bool> CreatePublishedReport(PublishedReportDTO dto)
        {
            try
            {
                PublishedReport publishedReport = new()
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    PublishedDate = dto.PublishedDate,
                    ViewedNumber = dto.ViewedNumber,
                    ReportId = dto.ReportId,
                };
                this._dataContext.PublishedReports.Add(publishedReport);
                await this._dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<PublishedReport>> GetPublishedReport()
        {
            var result = await this._dataContext.PublishedReports.ToListAsync();
            return result;
        }

        public bool IsReportPublished(int reportId)
        {
            var result = this._dataContext.PublishedReports.FirstOrDefault(pl=>pl.ReportId == reportId);
            if (result == null)
                return false;
            return true;
        }
    }
}
