using DailyNote.data;
using DailyNote.Exceptions.Custom;
using DailyNote.Models.Constants;
using DailyNote.Models.Entities;

namespace DailyNote.DataAccess.User
{
    public class UserRepository : IDataRepository<UserEntity, int>
    {

        private readonly ApplicationDBContext _db;

        public UserRepository( ApplicationDBContext db )
        {
            _db = db;            
        }

        public void DeleteById(int id) 
        {
            UserEntity? savedUser = GetById(id);

            if (savedUser == null)
                throw new NotFoundException(Messages.NOT_FOUND);

             _db.User.Remove(savedUser);
            _db.SaveChanges();

        }

        public List<UserEntity> GetAll()
        {
            return _db.User.ToList();
        }

        public UserEntity? GetByEmail(string email)
        {
            UserEntity? savedUser = _db.User
                                    .Where(user => user.Email.Equals(email))
                                    .FirstOrDefault();
            return savedUser;
        }

        public UserEntity? GetById(int id)
        {
            return _db.User
                .SingleOrDefault( user => user.Id == id );
        }

        public UserEntity? Save(UserEntity entity)
        {
            try
            {
                _db.User.Add(entity);
                _db.SaveChanges();
                return entity;
            }
            catch(  Exception e )
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public UserEntity? Update( UserEntity userEntity )
        {
            try
            {
                _db.User.Update(userEntity);
                _db.SaveChanges();
                return userEntity;
            }
            catch( Exception e )
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
