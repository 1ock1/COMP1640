using COMP1640.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Repositories.IRepositories
{
    public interface ITopicRepository
    {
        public IEnumerable<Topic> GetAllTopics();
        public Topic GetTopicById(int id);
        public string CreateTopic(Topic topic);
        public string UpdateTopic(Topic topic);
        public string DeleteTopic(int id);
        public List<CurrentTopicsDTO> GetCurrentTopicsDTO(CurrentTopicsDTORequest dto);
        public bool CheckTopicIsAllowed(IsTopicAllowedDTO dto);
    }
}
