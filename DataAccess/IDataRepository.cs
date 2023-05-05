namespace DailyNote.DataAccess
{

    /*
     *  T means target Entity ,
     *  R means target Entity's primary key's data type
     */
    public interface IDataRepository<T,R>
    {
        T? Save( T entity );

        T? GetById( R id );

        List<T> GetAll();

        void DeleteById( R id );

        T? Update(T entity);

    }
}
