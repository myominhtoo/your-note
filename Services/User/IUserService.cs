
using DailyNote.Models.Entities;
using DailyNote.Models.ViewModels.Request;

namespace DailyNote.Services.User
{
    public interface IUserService
    {

        string CreateUser( RegisterRequestViewModel newUser );

        string UpdateUser( UpdateUserRequestViewModel updateUser );

        string DeleteUser( int userId );

        UserEntity? GetUserById( int userId );

        UserEntity? GetUserByEmail( string email );

        bool IsDuplicateEmail( string email );

    }
}
