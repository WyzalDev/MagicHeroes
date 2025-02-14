using System;
using System.Collections.Generic;

namespace magic_heroes.Server.src.structure
{
    public class ServiceLocatorImpl : IServiceLocator
    {
        private readonly Dictionary<Type, object> _services = new();
        
        public void Register<T>(T service)
        {
            _services[typeof(T)] = service;
        }

        public bool Unregister<T>()
        {
            return _services.Remove(typeof(T));
        }

        public T Get<T>()
        {
            return (T)_services[typeof(T)];
        }

        public bool IsRegistered<T>()
        {
            return _services.ContainsKey(typeof(T));
        }
    }
}