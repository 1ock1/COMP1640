using COMP1640.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Repositories.IRepositories
{
    public interface ITopicRepository
    {
        public IEnumerable<Topic> GetAllTopics();
        public Topic GetTopicById(int id);
        public IActionResult CreateTopic(Topic topic);
        public IActionResult UpdateTopic(Topic topic);
        public IActionResult DeleteTopic(int id);

    }
}
