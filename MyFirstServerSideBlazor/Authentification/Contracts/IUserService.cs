using MyFirstServerSideBlazor.DataTransferObjects_DTO;
using MyFirstServerSideBlazor.Structures;

namespace MyFirstServerSideBlazor.Authentification.Contracts
{
    public interface IUserServise
    {
        public UserData VerifyLogin(string userName, string password);

        public Task<Result<UserData>> CreateUser(string userName, string password);
    }
}
