using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class IncomeService:IIncomeService
    {
        private readonly IAsyncRepository<Income> _incomeRepository;

        public IncomeService(IAsyncRepository<Income> incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        /*public async Task<List<IncomeResponseModel>> GetAllIncomes()
        {
            var incomes = await _incomeRepository.ListAllAsync();
            var incomeResponseList = new List<IncomeResponseModel>();
            foreach (var income in incomes)
            {
                incomeResponseList.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }

            return incomeResponseList;
        }

        public async Task<IncomeResponseModel> GetIncomeById(int id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            var incomeResponse = new IncomeResponseModel
            {
                Id = income.Id,
                UserId = income.UserId,
                Amount = income.Amount,
                Description = income.Description,
                IncomeDate = income.IncomeDate,
                Remarks = income.Remarks
            };

            return incomeResponse;
        }*/

        public async Task<IncomeResponseModel> CreateIncome(IncomeRequestModel incomeRequestModel)
        {
            var income = new Income
            {
                UserId = incomeRequestModel.UserId,
                Amount = incomeRequestModel.Amount,
                Description = incomeRequestModel.Description,
                IncomeDate = incomeRequestModel.IncomeDate,
                Remarks = incomeRequestModel.Remarks
            };

            var createdIncome = await _incomeRepository.AddAsync(income);

            var createdIncomeResponseModel = new IncomeResponseModel
            {
                Id = createdIncome.Id,
                UserId = createdIncome.UserId,
                Amount = createdIncome.Amount,
                Description = createdIncome.Description,
                IncomeDate = createdIncome.IncomeDate,
                Remarks = createdIncome.Remarks
            };

            return createdIncomeResponseModel;
        }

        public async Task<IncomeResponseModel> UpdateIncome(IncomeUpdateRequestModel incomeUpdateRequestModel)
        {
            var updateIncome = new Income
            {
                Id = incomeUpdateRequestModel.Id,
                UserId = incomeUpdateRequestModel.UserId,
                Amount = incomeUpdateRequestModel.Amount,
                Description = incomeUpdateRequestModel.Description,
                IncomeDate = incomeUpdateRequestModel.IncomeDate,
                Remarks = incomeUpdateRequestModel.Remarks
            };

            var updatedIncome = await _incomeRepository.UpdateAsync(updateIncome);

            var updatedIncomeResponseModel = new IncomeResponseModel
            {
                Id = updatedIncome.Id,
                UserId = updatedIncome.UserId,
                Amount = updatedIncome.Amount,
                Description = updatedIncome.Description,
                IncomeDate = updatedIncome.IncomeDate,
                Remarks = updatedIncome.Remarks
            };

            return updatedIncomeResponseModel;
        }

        public async Task<IncomeResponseModel> DeleteIncome(int id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);

            await _incomeRepository.DeleteAsync(income);

            var deletedIncomeResponseModel = new IncomeResponseModel
            {
                Id = income.Id,
                UserId = income.UserId,
                Amount = income.Amount,
                Description = income.Description,
                IncomeDate = income.IncomeDate,
                Remarks = income.Remarks
            };

            return deletedIncomeResponseModel;
        }
    }
}