using System;
using System.Collections.Generic;
using magic_heroes.Client.Dto;
using magic_heroes.GlobalUtils.HttpApi;
using magic_heroes.Server.connection;
using UnityEngine;

namespace magic_heroes.GlobalUtils.GlobalConnection
{
    public class ClientServerAdapter
    {
        
        
        #region SINGLETON_CODE
        private static ClientServerAdapter _instance;
        
        public static ClientServerAdapter Instance
        {
            get
            {
                _instance ??= new ClientServerAdapter();
                return _instance;
            }
        }
        #endregion

        private static readonly MessageBroker MessageBrokerInstance = MessageBroker.Instance;

        public Response SendRequest(Request request)
        {
            Debug.Log($"MsgHandler name = {request.msgHandlerName}, Fields = {request.fields.ToDebugString()}");
            return MessageBrokerInstance.GetResponse(request);
        }
    }
}