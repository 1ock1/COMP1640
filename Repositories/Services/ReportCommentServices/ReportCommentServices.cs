using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Repositories.Services.ReportCommentServices
{
    public class ReportCommentServices : IReportCommentRepository
    {
        private readonly DataContext dataContext;
        public ReportCommentServices(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<bool> CreateComment(ReportCommentDTO dto)
        {
            try
            {
                ReportComment comment = new()
                {
                    Content = dto.Content,
                    Date = dto.Date,
                    IsEdited = dto.IsEdited,
                    PublishedReportId = dto.PublishedReportId,
                    ReportId = dto.ReportId,
                    ResponseForUserId = dto.ResponseForUserId,
                };
                this.dataContext.ReportComments.Add(comment);
                await this.dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<ReportCommentResponseDTO>> GetComments(ReportCommentRequestDTO dto)
        {
            List<ReportCommentResponseDTO> list = new List<ReportCommentResponseDTO>();
            var result = await this.dataContext.ReportComments.Where(
                rp => rp.PublishedReportId == dto.PublishedReportId &&
                rp.ReportId == dto.ReportId &&
                rp.ResponseForUserId == dto.ResponseForUserId
            ).ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in result)
                {
                    ReportCommentResponseDTO cmt = new()
                    {
                        Content = item.Content,
                        Date = item.Date,
                    };
                    list.Add(cmt);
                }
                return list;
            }
        }
    }
}
