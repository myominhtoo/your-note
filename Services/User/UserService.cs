using DailyNote.DataAccess.User;
using DailyNote.Models.Constants;
using DailyNote.Models.Entities;
using DailyNote.Models.ViewModels.Request;

namespace DailyNote.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserRepository userRepo;

        public UserService( UserRepository _userRepo )
        {
            userRepo = _userRepo;
        }

        public string CreateUser( RegisterRequestViewModel newUser)
        {
            if (this.IsDuplicateEmail(newUser.Email))
                return Messages.DUPLICATE_USER;

            UserEntity userEntity = new UserEntity()
            {
                Email = newUser.Email,
                Username = newUser.Username,
                Password = newUser.Password,
                CreatedDate = DateTime.Now,
                UpdatedDate = null
            };

            UserEntity? savedEntity = userRepo.Save(userEntity);

            if (savedEntity == null)
                return Messages.REGISTER_FAILED;

            return Messages.REGISTER_SUCCESS;
        }

        public string DeleteUser(int userId)
        {
            try
            {
                userRepo.DeleteById(userId);
                return Messages.DELETE_SUCCESS;
            }
            catch 
            { 

                return Messages.DELETE_FAILED;
            }
        }

        public UserEntity? GetUserByEmail(string email)
        {
            return userRepo.GetByEmail(email);
        }

        public UserEntity? GetUserById(int userId)
        {
            return userRepo.GetById(userId);
        }

        public string UpdateUser( UpdateUserRequestViewModel updateUser)
        {
            UserEntity? savedUserEntity = userRepo.GetById(updateUser.Id);

            if (savedUserEntity == null)
                return Messages.NOT_FOUND;

            if (!updateUser.Email.Equals(savedUserEntity.Email) && GetUserByEmail(updateUser.Email) != null)
                return Messages.DUPLICATE_USER;

            savedUserEntity.Username = updateUser.Username;
            savedUserEntity.Email = updateUser.Email;
            savedUserEntity.Password = updateUser.Password;
            savedUserEntity.UpdatedDate = DateTime.Now;

            savedUserEntity = userRepo.Update(savedUserEntity);

            if (savedUserEntity != null)
                return Messages.UPDATE_FAILED;

            return Messages.UPDATE_SUCCESS;
        }

        public bool IsDuplicateEmail( string email )
        {
            return GetUserByEmail(email) != null;
        }
    }
}
