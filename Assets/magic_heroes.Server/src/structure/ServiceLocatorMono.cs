using System;
using magic_heroes.Server.connection.handlers;
using UnityEngine;

namespace magic_heroes.Server.structure
{
    public class ServiceLocatorMono : MonoBehaviour
    {
        public static ServiceLocatorMono Instance { get; private set; }

        private IServiceLocator _serviceLocator;

        private void Awake()
        {
            if (Instance != null) return;
            DontDestroyOnLoad(this);
            _serviceLocator = new ServiceLocatorImpl();
            RegisterAllDependencies();
            Instance = this;
            Debug.Log("SERVER_INFO: ServiceLocatorMono Awake");
        }

        //Register all server services and entities here 
        private void RegisterAllDependencies()
        {
            _serviceLocator.Register<EventCheckMessageHandler>(new EventCheckMessageHandler());
            _serviceLocator.Register<ConnectionMessageHandler>(new ConnectionMessageHandler());
            _serviceLocator.Register<ResetMessageHandler>(new ResetMessageHandler());
            _serviceLocator.Register<EndTurnMessageHandler>(new EndTurnMessageHandler());
            //example locator.Register<UtilityService>(new UtilityService(utilityServiceParams));
            Debug.Log("SERVER_INFO: ServiceLocatorMono RegisterAllDependencies complete");
        }

        public bool TryGetService<T>(out object service)
        {
            service = _serviceLocator.Get<T>();
            return service != null;
        }
    }
}