using MyFirstServerSideBlazor.Authentification.Contracts;
using MyFirstServerSideBlazor.Database;
using MyFirstServerSideBlazor.Database.Entities;
using MyFirstServerSideBlazor.DataTransferObjects_DTO;

namespace MyFirstServerSideBlazor.Authentification
{
    public class UserServise : IUserServise
    {
        private readonly ICryptographyServise _cryptographyServise;
        private readonly WebDatabaseContext _webDatabaseContext;

        public UserServise(
            ICryptographyServise cryptographyServise, 
            WebDatabaseContext webDatabaseContext)
        {
            _cryptographyServise = cryptographyServise;
            _webDatabaseContext = webDatabaseContext;
        }        

        public UserData VerifyLogin(string userName, string password)
        {
            var hashedPassword = _cryptographyServise.Hash(password);
            var user = _webDatabaseContext.Users.Where(x => x.UserName == userName && x.PasswordHash == hashedPassword).FirstOrDefault();

            return user == null
                ? null
                : new UserData
                {
                    UserName = user.UserName,
                    Role = user.Role
                };
        }

        public async Task<Results> CreateUser(string userName, string password)
        {
            var hashedPassword = _cryptographyServise.Hash(password);

            _webDatabaseContext.Users.Add(new BlazorUser
            {
                UserName = userName,
                PasswordHash = hashedPassword,
                Role = "Base User",
                Created = DateTime.Now,
                LastSeen = DateTime.Now
            });

            await _webDatabaseContext.SaveChangesAsync();
        }
    }
}
