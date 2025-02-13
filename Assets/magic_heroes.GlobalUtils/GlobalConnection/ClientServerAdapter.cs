using System;
using System.Collections.Generic;
using magic_heroes.Client.Dto;
using magic_heroes.GlobalUtils.HttpApi;
using UnityEngine;

namespace magic_heroes.GlobalUtils.GlobalConnection
{
    public class ClientServerAdapter
    {
        private static ClientServerAdapter _instance;

        private static Dictionary<string, string> testFields = new Dictionary<string, string>()
        {
            {HttpAttributeNames.CONNECTION,
                JsonUtility.ToJson(new ConnectionDto()
            {
                isConnected = true,
                connectionId = 254325325
            })}
        };

        public static ClientServerAdapter Instance
        {
            get
            {
                _instance ??= new ClientServerAdapter();
                return _instance;
            }
        }

        public Response SendRequest(Request request)
        {
            Debug.Log($"MsgHandler name = {request.name}, Fields = {request.fields.ToDebugString()}");
            return new Response()
            {
                status = 200,
                fields = testFields
            };
        }
    }
}