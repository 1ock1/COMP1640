using COMP1640.DTOs;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP1640.Repositories.Services.UserService
{
    public class UserService : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<bool> CreateAccount(UserSignUpDTO userDTO)
        {
            try
            {
                User user = new()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                    Status = userDTO.Status,
                    Role = userDTO.Role,
                    BirthDate = userDTO.BirthDate,
                    PhoneNumber = userDTO.PhoneNumber,
                };
                this._dataContext.User.Add(user);
                await this._dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public async Task<bool> CheckUserByEmail(string email)
        {
            var user = this._dataContext.User.FirstOrDefault(u=>u.Email == email);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public bool SignIn()
        {
            throw new NotImplementedException();
        }

        public User GetUserInformation(UserDTO userDTO)
        {
            var user = this._dataContext.User.FirstOrDefault(u => u.Email == userDTO.Email);
            if (user != null)
            {
                if(userDTO.Password == user.Password)
                {
                    return user;
                }
            }

            return null;
        }

        public bool IsMultipleRole(UserDTO userDTO)
        {
            var user = this._dataContext.User.FirstOrDefault(u => u.Email == userDTO.Email);
            if (user != null)
            {
                if (userDTO.Password == user.Password)
                {
                    bool IsMulipleRole = user.Role.Contains(",");
                    if (IsMulipleRole)
                    {
                        return true;
                    }
                    return false;
                }
            }

            return false;
        }

        public CoordinatorInforResponseDTO GetCoordinatorInformation(GetCoordinatorInforDTO dto)
        {
            var user = this._dataContext.User.FirstOrDefault(u => u.Role == dto.Role && u.FalcutyId == dto.FalcutyId);
            if (user != null)
            {
                CoordinatorInforResponseDTO result = new()
                {
                    Name = user.Name,
                    Id = user.Id,
                    Email = user.Email,
                };
                return result;
            }

            return null;
        }
    }
}
