namespace COMP1640.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FalcutyId { get; set; }
        public Falcuty Falcuty { get; set; }
        public int AcademicId { get; set; }
        public Academic Academic { get; set; }
        public DateTime EntriesDate { get; set; }
        public DateTime FinalDate { get; set; }
        public List<Report> Reports { get; set; }
    }
}
