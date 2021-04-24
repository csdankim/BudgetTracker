using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<UserResponseModel>> GetAllUsers();
        Task<UserDetailResponseModel> GetUserDetails(int id);
        Task<UserResponseModel> CreateUser(UserRequestModel userRequestModel);
        Task<UserResponseModel> UpdateUser(UserUpdateRequestModel userUpdateRequestModel);
        Task<UserResponseModel> DeleteUser(int id);
    }
}