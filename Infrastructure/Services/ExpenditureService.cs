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
    public class ExpenditureService:IExpenditureService
    {
        private readonly IAsyncRepository<Expenditure> _expenditureRepository;

        public ExpenditureService(IAsyncRepository<Expenditure> expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }

        public async Task<List<ExpenditureResponseModel>> GetAllExpenditures()
        {
            var expenditures = await _expenditureRepository.ListAllAsync();
            var expenditureResponseList = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                expenditureResponseList.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description, 
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }

            return expenditureResponseList;
        }

        public async Task<ExpenditureResponseModel> GetExpenditureById(int id)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id);
            var expenditureResponse = new ExpenditureResponseModel
            {
                Id = expenditure.Id,
                UserId = expenditure.UserId,
                Amount = expenditure.Amount,
                Description = expenditure.Description,
                ExpDate = expenditure.ExpDate,
                Remarks = expenditure.Remarks
            };

            return expenditureResponse;
        }

        public async Task<ExpenditureResponseModel> CreateExpenditure(ExpenditureRequestModel expenditureRequestModel)
        {
            var expenditure = new Expenditure
            {
                UserId = expenditureRequestModel.UserId,
                Amount = expenditureRequestModel.Amount,
                Description = expenditureRequestModel.Description,
                ExpDate = expenditureRequestModel.ExpDate,
                Remarks = expenditureRequestModel.Remarks
            };

            var createdExpenditure= await _expenditureRepository.AddAsync(expenditure);

            var createdExpenditureResponseModel = new ExpenditureResponseModel
            {
                Id = createdExpenditure.Id,
                UserId = createdExpenditure.UserId,
                Amount = createdExpenditure.Amount,
                Description = createdExpenditure.Description,
                ExpDate = createdExpenditure.ExpDate,
                Remarks = createdExpenditure.Remarks
            };

            return createdExpenditureResponseModel;
        }

        public async Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureUpdateRequestModel expenditureUpdateRequestModel)
        {
            var updateExpenditure = new Expenditure
            {
                Id = expenditureUpdateRequestModel.Id,
                UserId = expenditureUpdateRequestModel.UserId,
                Amount = expenditureUpdateRequestModel.Amount,
                Description = expenditureUpdateRequestModel.Description,
                ExpDate = expenditureUpdateRequestModel.ExpDate,
                Remarks = expenditureUpdateRequestModel.Remarks
            };

            var updatedExpenditure = await _expenditureRepository.UpdateAsync(updateExpenditure);

            var updatedExpenditureResponseModel = new ExpenditureResponseModel
            {
                Id = updatedExpenditure.Id,
                UserId = updatedExpenditure.UserId,
                Amount = updatedExpenditure.Amount,
                Description = updatedExpenditure.Description,
                ExpDate = updatedExpenditure.ExpDate,
                Remarks = updatedExpenditure.Remarks
            };

            return updatedExpenditureResponseModel;
        }

        public async Task<ExpenditureResponseModel> DeleteExpenditure(int id)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id);

            await _expenditureRepository.DeleteAsync(expenditure);

            var deletedExpenditureResponseModel = new ExpenditureResponseModel
            {
                Id = expenditure.Id,
                UserId = expenditure.UserId,
                Amount = expenditure.Amount,
                Description = expenditure.Description,
                ExpDate = expenditure.ExpDate,
                Remarks = expenditure.Remarks
            };

            return deletedExpenditureResponseModel;
        }
    }
}