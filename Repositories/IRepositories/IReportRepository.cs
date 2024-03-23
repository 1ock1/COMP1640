using COMP1640.DTOs;

namespace COMP1640.Repositories.IRepositories
{
    public interface IReportRepository
    {
        public Task<string> CreateReportFirstTime(int topicId, int studentId, string filename, string type);
    }
}
