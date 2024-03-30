using COMP1640.Models;

namespace COMP1640.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserMultipleRoleDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleSelected { get; set; }
    }
    public class UserSignUpDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }

    public class UserUpdateDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }   
    public class TokenDTO
    {
        public string Token { get; set; }
    }
}
