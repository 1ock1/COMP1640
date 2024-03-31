using COMP1640.DTOs;
using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IPublishedReportRepository
    {
        public Task<bool> CreatePublishedReport(PublishedReportDTO dto);
        public Task<List<PublishedReport>> GetPublishedReport();
        public bool IsReportPublished(int reportId);
    }
}
