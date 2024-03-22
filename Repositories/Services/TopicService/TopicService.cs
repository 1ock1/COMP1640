using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Repositories.Services.TopicService
{
    public class TopicService: ITopicRepository
    {
        private readonly DataContext _datacontex;
        public TopicService(DataContext datacontex)
        {
            this._datacontex = datacontex;
        }

        public string CreateTopic(Topic topic)
        {

            _datacontex.Topics.Add(topic);
            _datacontex.SaveChanges();
            return "oke nhes";
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

        public string UpdateTopic(Topic topic)
        {

            _datacontex.Topics.Update(topic);
            _datacontex.SaveChanges();
            return "thanh_cong";
        }

    }
    
}
