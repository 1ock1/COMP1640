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
        private readonly IFacultyRepository _falcutyRepository;
        private readonly IAcademicRepository _academicRepository;

        public TopicController(ITopicRepository topicRepository, IFacultyRepository facultyRepository, IAcademicRepository academicRepository)
        {
            _topicRepository = topicRepository;
            _falcutyRepository = facultyRepository;
            _academicRepository = academicRepository;
            
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
            createTopic.EntriesDate = topic.EntriesDate;
            createTopic.FinalDate = topic.FinalDate;

            createTopic.FalcutyId = topic.FalcutyId;
            createTopic.AcademicId = topic.AcademicId;
                                           
            _topicRepository.CreateTopic(createTopic);
                    
            return createTopic;
        }

        [HttpPut("UpdateTopic")]
        public Topic UpdateTopic(int id, UpdateTopic topic)
        {
            // Call the service to update topic
            Topic topicInformation = _topicRepository.GetTopicById(id);
            topicInformation.Name = topic.Name;
            topicInformation.Description = topic.Description ;
            topicInformation.EntriesDate = topic.FinalDate;
            topicInformation.FinalDate = topic.FinalDate;

            _topicRepository.UpdateTopic(topicInformation);

            return topicInformation;
        }

        [HttpDelete("DeleteTopic")]

        public Topic DeleteTopic(int id)
        {
           Topic deleteTopic= _topicRepository.GetTopicById(id);
             _topicRepository.DeleteTopic(id);
            // Call the service to delete topic
            return deleteTopic;
        }
        
        [HttpPost("GetTopicsByAcademicAndFalcuty")]
        public ActionResult GetTopicsByAcademicAndFalcuty(CurrentTopicsDTORequest dto)
        {
            var result = this._topicRepository.GetCurrentTopicsDTO(dto);
            return StatusCode(200, result);
        }

        [HttpPost("CheckIsTopicAllowed")]
        public ActionResult CheckIsTopicAllowed(IsTopicAllowedDTO dto)
        {
            var result = this._topicRepository.CheckTopicIsAllowed(dto);
            return StatusCode(200, result);
        }
    }
}
