using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IExpenditureService
    {
        Task<List<ExpenditureResponseModel>> GetAllExpenditures();
        Task<ExpenditureResponseModel> GetExpenditureById(int id);
        Task<ExpenditureResponseModel> CreateExpenditure(ExpenditureRequestModel expenditureRequestModel);
        Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureUpdateRequestModel expenditureUpdateRequestModel);
        Task<ExpenditureResponseModel> DeleteExpenditure(int id);
    }
}