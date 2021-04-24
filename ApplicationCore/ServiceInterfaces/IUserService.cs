using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<UserResponseModel>> GetAllUsers();
        Task<UserDetailResponseModel> GetUserDetails(int id);
    }
}