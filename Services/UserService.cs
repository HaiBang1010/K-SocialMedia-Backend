using ChatChit.Data;
using ChatChit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatChit.Repositories
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetAllUser();
        public Task<UserModel> GetUser(string id);
        public Task<UserModel> AddUser(UserModel user);
        public Task<UserModel> UpdateUser(UserModel user, Guid id);
        public Task DeleteUser(UserModel deleteUser);
    }

    public class UserService : IUserService
    {
        private readonly ChatChitContex _context;

        public UserService(ChatChitContex context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<UserModel> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, Guid id)
        {
            if (id == user.id)
            {
                var updateUser = await _context.Users.FindAsync(id);
                if (updateUser != null)
                {
                    _context.Entry(updateUser).State = EntityState.Modified;
                    return updateUser;
                }
            }
            return null;
        }

        public async Task DeleteUser(UserModel deleteUser)
        {
            _context.Users.Remove(deleteUser);
            await _context.SaveChangesAsync();
        }
    }
}
