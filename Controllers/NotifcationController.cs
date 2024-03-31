using COMP1640.DTOs;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifcationController : ControllerBase
    {
        private readonly INotificationRepository notificationRepository;
        public NotifcationController(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }
        [HttpPost("CreateNoti")]
        public async Task<ActionResult> CreateNotifycation(NotificationDTO dto)
        {
            var result = await notificationRepository.CreateNotification(dto);
            return StatusCode(200, result);
        }
        [HttpPost("GetNotification")]
        public async Task<ActionResult> GetNotification(NotifyRequestDTO dto)
        {
            var result = await notificationRepository.GetAllNotifications(dto);
            return StatusCode(200, result);
        }
        [HttpPut("UpdateNotifcation")]
        public async Task<ActionResult> UpdateNotifcation(NotifyRequestIsReadedDTO dto)
        {
            var result = await notificationRepository.UpdateIsRead(dto);
            return StatusCode(200, result);
        }
        [HttpDelete("DeleteNotification")]
        public ActionResult DeleteNotification(int notifyId)
        {
            var result = notificationRepository.DeleteNotification(notifyId);
            return StatusCode(200, result);
        }
    }
}
