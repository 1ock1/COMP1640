namespace COMP1640.Models
{
    public class Academic
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Topic> Topics { get; set; }
    }

    public class CreateAcademic
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
    }

    public class UpdateAcademic
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}


