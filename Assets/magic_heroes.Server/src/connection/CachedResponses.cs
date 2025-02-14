using System.Collections.Generic;
using magic_heroes.GlobalUtils.HttpApi;
using magic_heroes.Server.mappers.dto;
using UnityEngine;

namespace magic_heroes.Server.connection
{
    public static class CachedResponses
    {
        public static readonly Response NoContentResponse = new Response()
        {
            status = 204
        };

        public static readonly Response BadRequestResponse = new Response()
        {
            status = 400
        };

        //TODO delete when all Message handlers will be working
        public static readonly Response StubResponse = new Response()
        {
            status = 200,
            fields = new Dictionary<string, string>()
            {
                {
                    HttpAttributeNames.CONNECTION, JsonUtility.ToJson(new ConnectionDto()
                    {
                        isConnected = true,
                        connectionId = 254325325
                    })
                },
                {
                    HttpAttributeNames.USER, JsonUtility.ToJson(new UserDto()
                    {
                        id = 1,
                        name = "Client_User"
                    })
                }
            }
        };
    }
}