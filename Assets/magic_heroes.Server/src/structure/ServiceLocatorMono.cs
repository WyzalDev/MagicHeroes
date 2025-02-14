using System;
using UnityEngine;

namespace magic_heroes.Server.src.structure
{
    public class ServiceLocatorMono : MonoBehaviour
    {
        private static ServiceLocatorMono Instance { get; set; }

        private IServiceLocator _serviceLocator;

        private void Awake()
        {
            if (Instance != null)
                return;
            DontDestroyOnLoad(this);
            _serviceLocator = new ServiceLocatorImpl();
            Configure(_serviceLocator);
            Instance = this;
        }
        
        //Register all server services and entities here 
        private void Configure(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            //example locator.Register<UtilityService>(new UtilityService(utilityServiceParams));
        }

        public bool TryGetService<T>(out object service)
        {
            service = _serviceLocator.Get<T>();
            return service != null;
        }
    }
}