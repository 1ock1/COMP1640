namespace COMP1640.DTOs
{
    public class AcademicDTOs
    {
        public class  CreateAcademic
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
}
