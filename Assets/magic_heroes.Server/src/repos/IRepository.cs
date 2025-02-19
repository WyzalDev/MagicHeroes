namespace magic_heroes.Server.repos
{
    public interface IRepository <T, ID>
    {
        T GetById(ID id);
        bool DeleteById(ID id);
        T Save(T entity);
        bool Exists(ID id);
    }
}