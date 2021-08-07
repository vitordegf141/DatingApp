using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        public Task<AppUser> GetUserByIdAsync(int id);
        public Task<AppUser> GetUserByUserNameAsync(string username);
        public Task<IEnumerable<MemberDto>> GetMembersAsync();

        public Task<MemberDto> GetMemberAsync(string username);
        
    }
}