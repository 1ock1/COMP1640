using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Repositories.Services.TopicServices
{
    public class TopicService: ITopicRepository
    {
        private readonly DataContext _datacontex;
        public TopicService(DataContext datacontex)
        {
            this._datacontex = datacontex;
        }

        public IActionResult CreateTopic(Topic topic)
        {
            
            _datacontex.Topics.Add(topic);
            _datacontex.SaveChanges();
            return new OkResult();
        }

        public IActionResult DeleteTopic(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            return _datacontex.Topics.ToList();
        }

        public Topic GetTopicById(int id)
        {
            
            return _datacontex.Topics.Find(id);
        }

        public IActionResult UpdateTopic(Topic topic)
        {
            
            _datacontex.Topics.Update(topic);
            _datacontex.SaveChanges();
            return new OkResult();
        }
    }
}
