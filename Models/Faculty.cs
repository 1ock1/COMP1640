namespace COMP1640.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<User> User { get; set; }
        public List<Topic> Topics { get; set; }

        public class CreateFaculty
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Status { get; set; }
            public string Description { get; set; }
            // Add more properties as needed
        }

        public class EditFaculty
        {
            public string Name { get; set; }
            public string Description { get; set; }
            // Add more properties as needed
        }
    }
}
