using BelajarASPNetMVC.Application.Services.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Users
{
    public interface IUserAppService
    {
        UserDto GetUserById(int userId);
        UserDto GetUserByName(string userName);
        UserDto GetUserByEmail(string email);

        bool IsUserExist(string email, string password);

        //PagedData<User> GetAll(List<User> filter, User search, int pageIndex = 1,
        //    int pageSize = GlobalSetting.DEFAULT_PAGESIZE);
        IEnumerable<UserDto> GetAll(int pageIndex = 1, int pageSize = 10);
        void Create(UserDto user);
        void Update(UserDto user);
        void Delete(int id);
    }
}
