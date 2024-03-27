namespace COMP1640.DTOs
{
    public class NotificationDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
    }
    public class NotifyReturnDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }

    public class NotifyRequestDTO
    {
        public int ToUserId { get; set; }
        public bool IsRead { get; set; }
    }
    public class NotifyRequestIsReadedDTO
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
    }
}
