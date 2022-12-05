using AutoMapper;
using BelajarASPNetMVC.Application.Helper;
using BelajarASPNetMVC.Application.Services.Users.Dto;
using BelajarASPNetMVC.Data;
using BelajarASPNetMVC.Data.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserAppService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Create(UserDto userDto)
        {
            var newUser = _mapper.Map<User>(userDto);
            newUser.passwordSalt = userDto.surName;
            newUser.Password = SecurityHelper.GenerateHashWithSalt(userDto.Password, newUser.passwordSalt);
            newUser.lastChangePassword = DateTime.Now;

            _context.User.Add(newUser);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldUser = _context.User.FirstOrDefault(w => w.Id == id);

            _context.User.Remove(oldUser);
            _context.Entry(oldUser).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        //public PagedData<User> GetAll(List<User> filter, User search, int pageIndex = 1, int pageSize = 10)
        //{
        //    var context = new MeetingRoomEntities();

        //    var data = context.MstUsers.AsQueryable();

        //    if (search != null)
        //    {
        //        data = data.Where(w => w.userName.ToLower().Contains(search.userName.ToLower()));
        //    }

        //    var result = new PagedData<User>
        //    {
        //        TotalRecord = data.Count(),
        //        CurrentIndex = pageIndex,
        //        Data = Mapper.Map<IEnumerable<MstUser>, IEnumerable<User>>(data.OrderBy(o => o.userName).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList().AsEnumerable())
        //    };

        //    return result;
        //}

        public IEnumerable<UserDto> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            var data = _context.User.AsQueryable();

            return _mapper.Map<IEnumerable<UserDto>>(data);
        }

        public UserDto GetUserByEmail(string email)
        {
            UserDto returnUser = null;

            var user = _context.User.FirstOrDefault(w => w.Email == email);

            if (user != null)
            {
                returnUser = _mapper.Map<UserDto>(user);
            }

            return returnUser;
        }

        public UserDto GetUserById(int userId)
        {
            UserDto returnUser = null;

            User user = _context.User.FirstOrDefault(w => w.Id == userId);

            if (user != null)
            {
                returnUser = _mapper.Map<UserDto>(user);
            }

            return returnUser;
        }

        public UserDto GetUserByName(string userName)
        {
            var user = _context.User.FirstOrDefault(w => w.userName == userName);

            return _mapper.Map<UserDto>(user);
        }

        public bool IsUserExist(string email, string password)
        {
            var user = _context.User.FirstOrDefault(w => w.Email == email);
            if (user != null)
            {
                string Password = SecurityHelper.GenerateHashWithSalt(password, user.passwordSalt);
                user = _context.User.FirstOrDefault(w => w.Email == email && w.Password.Equals(Password));

                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Update(UserDto user)
        {
                var userModel = _context.User.FirstOrDefault(w => w.Id == user.Id);

                userModel.passwordSalt = user.userName;
                userModel.Password = SecurityHelper.GenerateHashWithSalt(user.Password, userModel.passwordSalt);
                userModel.lastChangePassword = DateTime.Now;

                _context.User.Attach(userModel);
                _context.Entry(userModel).State = EntityState.Modified;
                _context.SaveChanges();
        }
    }
}
