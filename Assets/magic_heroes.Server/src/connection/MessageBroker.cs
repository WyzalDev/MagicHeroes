using System.Collections.Generic;
using magic_heroes.GlobalUtils.GlobalConnection;
using magic_heroes.GlobalUtils.HttpApi;
using magic_heroes.Server.connection.handlers;
using magic_heroes.Server.structure;
using UnityEngine;

namespace magic_heroes.Server.connection
{
    public class MessageBroker
    {
        #region SINGLETON_CODE

        private static MessageBroker _instance;

        public static MessageBroker Instance
        {
            get
            {
                _instance ??= new MessageBroker();
                return _instance;
            }
        }

        #endregion

        private readonly ServiceLocatorMono _serviceLocator = ServiceLocatorMono.Instance;

        public Response GetResponse(Request request)
        {
            return request.msgHandlerName switch
            {
                MessageHandlerNames.EventCheckMessageHandlerName =>
                    HandleMessageWithNeededMessageHandler<EventCheckMessageHandler>(request),
                MessageHandlerNames.ConnectMessageHandlerName =>
                    HandleMessageWithNeededMessageHandler<ConnectionMessageHandler>(request),
                MessageHandlerNames.ResetMessageHandlerName =>
                    HandleMessageWithNeededMessageHandler<ResetMessageHandler>(request),
                MessageHandlerNames.EndTurnMessageHandler =>
                    HandleMessageWithNeededMessageHandler<EndTurnMessageHandler>(request),
                _ => CachedResponses.BadRequestResponse
            };
        }

        private Response HandleMessageWithNeededMessageHandler<T>(Request request) where T : IMessageHandler
        {
            if (_serviceLocator.TryGetService<T>(out var handler))
            {
                var messageHandler = (T)handler;
                return messageHandler?.HandleMessage(request);
            }
            else
            {
                Debug.LogError($"SERVER_ERROR: No service for type {typeof(T).Name}");
                return CachedResponses.BadRequestResponse;
            }
        }
    }
}