using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;

namespace COMP1640.Repositories.Services.ReportRepository
{
    public class ReportServices : IReportRepository
    {
        private readonly DataContext dataContext;
        public ReportServices(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        private int GetCreatedReportId(int topicId, int studentId)
        {
            var result = this.dataContext.Reports.FirstOrDefault(rp=>rp.TopicId==topicId && rp.StudentId == studentId);
            if (result == null)
            {
                return -1;
            }
            return result.Id;
        }
        public async Task<string> CreateReportFirstTime(int topicId, int studentId, string filename, string type)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime lastDateComment = currentDate.AddDays(14);
                Report report = new()
                {
                    Status = "Pending",
                    LastDateComment = lastDateComment,
                    TopicId = topicId,
                    StudentId = studentId,
                };
                this.dataContext.Reports.Add(report);
                await this.dataContext.SaveChangesAsync();
                
                var reportId = GetCreatedReportId(report.TopicId, report.StudentId);
                if (reportId == -1)
                {
                    return "false";
                }
                Guid FileID = Guid.NewGuid();
                FileReport fileReport = new()
                {
                    Id = FileID.ToString(),
                    Name = filename,
                    Type = type,
                    ReportId = reportId,
                };
                this.dataContext.FileReports.Add(fileReport);
                await this.dataContext.SaveChangesAsync();

                return FileID.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "false";
            }
        }

        public async Task<int> IsReportExistWithTopicId(ReportDTO reportDTO)
        {
            var row = this.dataContext.Reports.FirstOrDefault(rp => rp.TopicId == reportDTO.TopicId && rp.StudentId == reportDTO.StudentId);
            if(row == null)
            {
                return -1;
            }
            return row.Id;
        }
    }
}
