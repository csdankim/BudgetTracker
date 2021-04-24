using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IIncomeService
    {
        Task<List<IncomeResponseModel>> GetAllIncomes();
        Task<IncomeResponseModel> GetIncomeById(int id);
        Task<IncomeResponseModel> CreateIncome(IncomeRequestModel incomeRequestModel);
        Task<IncomeResponseModel> UpdateIncome(IncomeUpdateRequestModel incomeUpdateRequestModel);
        Task<IncomeResponseModel> DeleteIncome(int id);
    }
}