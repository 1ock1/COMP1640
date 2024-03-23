namespace COMP1640.DTOs
{
        public class CreateFacultyDto
        {
          
            public string Name { get; set; }
            public bool Status { get; set; }
            
            // Add more properties as needed
        }

        public class EditFacultyDto
        {
            
            public string Name { get; set; }
            public bool Status { get; set; }
            
        }
}
