using COMP1640.DTOs;
using COMP1640.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Repositories.IRepositories
{
    public interface IUserRepository
    {
        public bool SignIn();
        public bool Logout();
        public Task<bool> CreateAccount(UserSignUpDTO user);
        public Task<bool> CheckUserByEmail(string email);
        public User GetUserInformation(UserDTO user);
        public bool IsMultipleRole(UserDTO user);
        public CoordinatorInforResponseDTO GetCoordinatorInformation(GetCoordinatorInforDTO dto);
    }
}
