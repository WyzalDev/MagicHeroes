namespace magic_heroes.Server.src.structure
{
    public interface IServiceLocator
    {
        void Register<T>(T service);
        
        bool Unregister<T>();
        
        T Get<T>();
        
        bool IsRegistered<T>();
    }
}