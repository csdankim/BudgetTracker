using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class UserService:IUserService
    {
        private readonly EFRepository<User> _userRepository;

        public UserService(EFRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.ListAllAsync();
            var userResponseList = new List<UserResponseModel>();
            foreach (var user in users)
            {
                userResponseList.Add(new UserResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Fullname = user.Fullname,
                    JoinedOn = user.JoinedOn
                });
            }

            return userResponseList;
        }

        public async Task<UserDetailResponseModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            var incomeList = new List<UserDetailResponseModel.IncomeResponseModel>();
            foreach (var income in user.Incomes)
            {
                incomeList.Add(new UserDetailResponseModel.IncomeResponseModel
                {
                    Id = income.Id,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }

            var expenditureList = new List<UserDetailResponseModel.ExpenditureResponseModel>();
            foreach (var expenditure in user.Expenditures)
            {
                expenditureList.Add(new UserDetailResponseModel.ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }

            var userDetailResponseModel = new UserDetailResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Fullname = user.Fullname,
                JoinedOn = user.JoinedOn,
                Incomes = incomeList,
                Expenditures = expenditureList
            };

            return userDetailResponseModel;
        }

        public async Task<UserResponseModel> CreateUser(UserRequestModel userRequestModel)
        {
            var user = new User
            {
                Email = userRequestModel.Email,
                Fullname = userRequestModel.Fullname,
                Password = userRequestModel.Password,
                JoinedOn = userRequestModel.JoinedOn
            };

            var createdUser = await _userRepository.AddAsync(user);

            var createdUserResponseModel = new UserResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                Fullname = createdUser.Fullname,
                JoinedOn = createdUser.JoinedOn
            };

            return createdUserResponseModel;
        }

        public async Task<UserResponseModel> UpdateUser(UserUpdateRequestModel userUpdateRequestModel)
        {
            var updateUser = new User
            {
                Id = userUpdateRequestModel.Id,
                Email = userUpdateRequestModel.Email,
                Fullname = userUpdateRequestModel.Fullname,
                Password = userUpdateRequestModel.Password,
                JoinedOn = userUpdateRequestModel.JoinedOn
            };

            var updatedUser = await _userRepository.UpdateAsync(updateUser);

            var updatedUserResponseModel = new UserResponseModel
            {
                Id = updatedUser.Id,
                Email = updatedUser.Email,
                Fullname = updatedUser.Fullname,
                JoinedOn = updatedUser.JoinedOn
            };

            return updatedUserResponseModel;
        }

        public async Task<UserResponseModel> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            await _userRepository.DeleteAsync(user);

            var deletedUserResponseModel = new UserResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Fullname = user.Fullname,
                JoinedOn = user.JoinedOn
            };

            return deletedUserResponseModel;
        }
    }
}