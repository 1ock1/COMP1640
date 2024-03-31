using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Repositories.Services.NotificationServices
{
    public class NotificationService : INotificationRepository
    {
        private readonly DataContext _dataContext;
        public NotificationService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<bool> CreateNotification(NotificationDTO dto)
        {
            try
            {
                Notification noti = new()
                {
                    Title= dto.Title,
                    Description= dto.Description,
                    Date= dto.Date,
                    IsRead= dto.IsRead,
                    ToUserId= dto.ToUserId,
                    FromUserId= dto.FromUserId,
                };
                this._dataContext.Notification.Add(noti);
                await this._dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteNotification(int notifyId)
        {
            var notify = this._dataContext.Notification.Find(notifyId);
            if (notify != null)
            {
                this._dataContext.Notification.Remove(notify);
                this._dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<NotifyReturnDTO>> GetAllNotifications(NotifyRequestDTO dto)
        {
            List<NotifyReturnDTO> list = new List<NotifyReturnDTO>();
            var result = await this._dataContext.Notification.Where(n => n.IsRead == dto.IsRead && n.ToUserId == dto.ToUserId).ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in result)
                {
                    NotifyReturnDTO noti = new()
                    {
                        Id= item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        Date = item.Date,
                        IsRead= item.IsRead,
                    };
                    list.Add(noti);
                }
                return list;
            }
        }
        public async Task<bool> UpdateIsRead(NotifyRequestIsReadedDTO dto)
        {
            var noti = this._dataContext.Notification.FirstOrDefault(n=>n.Id == dto.Id);    

            if (noti != null)
            {
                noti.IsRead = dto.IsRead;
                await this._dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
