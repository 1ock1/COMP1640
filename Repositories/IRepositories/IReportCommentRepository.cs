using COMP1640.DTOs;

namespace COMP1640.Repositories.IRepositories
{
    public interface IReportCommentRepository
    {
        public Task<bool> CreateComment(ReportCommentDTO dto);
        public Task<List<ReportCommentResponseDTO>> GetComments(ReportCommentRequestDTO dto);
    }
}
