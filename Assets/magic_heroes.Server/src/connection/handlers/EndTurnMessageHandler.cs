using magic_heroes.GlobalUtils.HttpApi;
using UnityEngine;

namespace magic_heroes.Server.connection.handlers
{
    public class EndTurnMessageHandler : IMessageHandler
    {
        public Response HandleMessage(Request request)
        {
            Debug.Log("SERVER_INFO : EndTurnMessageHandler::HandleMessage");
            return CachedResponses.StubResponse;
        }
    }
}