namespace COMP1640.DTOs
{
        public class CreateFacultyDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Status { get; set; }
            public string Description { get; set; }
            // Add more properties as needed
        }

        public class EditFacultyDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Status { get; set; }
            public string Description { get; set; }
        }
}
