using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
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
            var userResponse = new List<UserResponseModel>();
            foreach (var user in users)
            {
                userResponse.Add(new UserResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Fullname = user.Fullname,
                    JoinedOn = user.JoinedOn
                });
            }

            return userResponse;
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
    }
}