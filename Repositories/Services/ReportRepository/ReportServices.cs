using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.Data.SqlClient;
using System.Data;

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
        public async Task<UploadNewReportDTO> CreateReportFirstTime(int topicId, int studentId, string filename, string type)
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
                    return null;
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
                UploadNewReportDTO result = new()
                {
                    GUID = FileID.ToString(),
                    ReportID = reportId,
                };
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
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

        public List<ReportResponseDTO> GetListReportBaseStatus(ReportRequestDTO reportRequestDTO)
        {
            List<ReportResponseDTO> list = new List<ReportResponseDTO>();
            try
            {
                SqlConnection conn = Conn.Connection();
                SqlCommand cmdRevenue = new SqlCommand("PRO_QueryReportOfTopicBasedStatus", conn);
                cmdRevenue.CommandType = CommandType.StoredProcedure;
                cmdRevenue.Parameters.AddWithValue("@topicId", reportRequestDTO.TopicId);
                cmdRevenue.Parameters.AddWithValue("@reportStatus", reportRequestDTO.Status);
                conn.Open();

                SqlDataReader cmdRdRevenue = cmdRevenue.ExecuteReader();
                while (cmdRdRevenue.Read())
                {
                    ReportResponseDTO rp = new()
                    {
                        ReportId = cmdRdRevenue.GetValue(0).ToString(),
                        Name = cmdRdRevenue.GetValue(1).ToString(),
                        Status = cmdRdRevenue.GetValue(2).ToString(),
                        Quality = cmdRdRevenue.GetValue(3).ToString(),
                        LastDateComment = cmdRdRevenue.GetValue(4).ToString(),
                    };
                    list.Add(rp);
                }
                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Report GetReportInformation(int reportId)
        {
            var result = this.dataContext.Reports.FirstOrDefault(r=>r.Id == reportId);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public bool UpdateReportStatus(UpdateReportStatusDTO dto)
        {
            var report = this.dataContext.Reports.FirstOrDefault(r=>r.Id== dto.ReportId);

            if (report != null)
            {
                report.Status = dto.Status;
                report.Quality = dto.Quality;
                if (dto.Role == "STUDENT")
                {
                    DateTime currentDate = DateTime.Now;
                    DateTime lastDateComment = currentDate.AddDays(14);
                    report.LastDateComment = lastDateComment;
                }
                this.dataContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
