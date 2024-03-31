using COMP1640.DTOs;

namespace COMP1640.Repositories.IRepositories
{
    public interface INotificationRepository
    {
        public Task<bool> CreateNotification(NotificationDTO dto);
        public Task<List<NotifyReturnDTO>> GetAllNotifications(NotifyRequestDTO dto);
        public Task<bool> UpdateIsRead(NotifyRequestIsReadedDTO dto);
        public bool DeleteNotification(int notifyId);
    }
}
