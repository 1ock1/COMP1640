using COMP1640.DTOs;
using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IReportRepository
    {
        public Task<UploadNewReportDTO> CreateReportFirstTime(int topicId, int studentId, string filename, string type);
        public List<ReportResponseDTO> GetListReportBaseStatus(ReportRequestDTO reportRequestDTO);
        public Task<int> IsReportExistWithTopicId(ReportDTO reportDTO);
        public Report GetReportInformation(int reportId);

        public bool UpdateReportStatus(UpdateReportStatusDTO dto);
    }
}
