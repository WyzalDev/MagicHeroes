namespace magic_heroes.Server.structure
{
    public interface IServiceLocator
    {
        void Register<T>(T service);
        
        bool Unregister<T>();
        
        T Get<T>();
        
        bool IsRegistered<T>();
    }
}