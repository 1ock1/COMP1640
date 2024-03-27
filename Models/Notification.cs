using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
    }
}
