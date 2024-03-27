using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static COMP1640.DTOs.TopicDTOs;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;

        public TopicController(ITopicRepository topicRepository)
        {
            this._topicRepository = topicRepository;
        }



        [HttpGet("GetAllTopic")]
        public IEnumerable<Topic> GetAllTopics()
        {
            // Call the service to get all topics
            IEnumerable<Topic> topics = _topicRepository.GetAllTopics();
            return topics;
        }

        [HttpGet("GetTopicById")]
        public Topic GetTopicById(int id)
        {
            // Call the service to get topic by id
            Topic topic = _topicRepository.GetTopicById(id);
            return topic;
        }

        [HttpPost("CreateTopic")]
        public Topic CreateTopic(CreateTopic topic)
        {
            // Call the service to create topic
            Topic createTopic = new Topic();
            createTopic.Name = topic.Name;
            createTopic.Description = topic.Description;
            createTopic.EntriesDate = topic.FinalDate;
            createTopic.FinalDate = topic.FinalDate;

            createTopic.FalcutyId = 1;
            createTopic.AcademicId = 1;
            _topicRepository.CreateTopic(createTopic);

            return createTopic;
        }

        [HttpPut("UpdateTopic")]
        public Topic UpdateTopic(int id, UpdateTopic topic)
        {
            // Call the service to update topic
            Topic topicInformation = _topicRepository.GetTopicById(id);
            topicInformation.Name = topic.Name ?? topicInformation.Name;
            topicInformation.Description = topic.Description ?? topicInformation.Description;
            topicInformation.EntriesDate = topic.FinalDate;
            topicInformation.FinalDate = topic.FinalDate;

            _topicRepository.UpdateTopic(topicInformation);

            return topicInformation;
        }

        [HttpDelete("DeleteTopic")]
        public string DeleteTopic(int id)
        {
            _topicRepository.DeleteTopic(id);
            return "Delete SuccessFully";
        }

        [HttpPost("GetTopicsByAcademicAndFalcuty")]
        public ActionResult GetTopicsByAcademicAndFalcuty(CurrentTopicsDTORequest dto)
        {
            var result = this._topicRepository.GetCurrentTopicsDTO(dto);
            return StatusCode(200, result);
        }
    }
}
