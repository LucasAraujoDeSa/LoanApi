using LoansApp.Domain.Etities;

namespace LoansApp.Data.Repositories.User
{
    public interface IUserRepository
    {
        Task Save(UserEntity input);
        Task<bool> CheckIfEmailAlreadyInUse(string email);
        Task<UserEntity?> GetByEmail(string email);
        Task<UserEntity?> GetById(string id);
        Task<bool> CheckIfExist(string id);
    }
}