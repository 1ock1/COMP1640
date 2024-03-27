using COMP1640.Models;

namespace COMP1640.DTOs
{
    public class TopicDTOs
    {
        public class CreateTopic
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int AcademicId { get; set; }
            public int FalcutyId { get; set; }
            
            public DateTime EntriesDate { get; set; }
            public DateTime FinalDate { get; set; }
            
           public int FalcutyId { get; set; }
           public int AcademicId { get; set; }
        }

        public class UpdateTopic
        {
            public string Name { get; set; }
            public string Description { get; set; }

            public DateTime EntriesDate { get; set; }
            public DateTime FinalDate { get; set; }
        }   


    }
}
