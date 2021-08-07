using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await this._context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            return await this._context.Users
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(X => X.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await this._context.Users
            .Include(p => p.Photos)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this._context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        async Task<MemberDto> IUserRepository.GetMemberAsync(string username)
        {
            return await _context.Users
                    .Where(x => x.UserName == username)
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();

        }

        async Task<IEnumerable<MemberDto>> IUserRepository.GetMembersAsync()
        {
            return await _context.Users
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                    
        }
    }
}