using API.Entities;

namespace API.Interfaces
{
    public interface IUserRespository
    {
     void Update(AppUser user);
     Task<bool> SaveAllAsync();
     Task<IEnumerable<AppUser>> GetUserAsync();   
     Task<AppUser> GetUserByIdAsync(int id);   
     Task<AppUser> GetUserByUserNameAsync(string username);   
    }
}