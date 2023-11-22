using LoansApp.Data.Repositories.User;
using LoansApp.Domain.Etities;
using Microsoft.EntityFrameworkCore;

namespace LoansApp.Infra.Database.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfEmailAlreadyInUse(string email)
        {
            UserEntity? user = await _dbContext.User.FirstOrDefaultAsync(user => user.Email == email);

            return user is not null;
        }

        public async Task<bool> CheckIfExist(string id)
        {
            UserEntity? user = await _dbContext.User.FirstOrDefaultAsync(user => user.Id == id);

            return user is not null;
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            UserEntity? user = await _dbContext.User.FirstOrDefaultAsync(user => user.Email == email);

            return user;
        }

        public async Task<UserEntity?> GetById(string id)
        {
            UserEntity? user = await _dbContext.User.FirstOrDefaultAsync(user => user.Id == id);

            return user;
        }

        public async Task Save(UserEntity input)
        {
            _dbContext.User.Add(input);
            await _dbContext.SaveChangesAsync();
        }
    }
}