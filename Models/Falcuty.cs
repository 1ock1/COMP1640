﻿namespace COMP1640.Models
{
    public class Falcuty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        
        public List<User> User { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
