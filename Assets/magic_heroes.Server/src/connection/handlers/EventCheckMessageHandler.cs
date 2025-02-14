using System.Collections.Generic;
using magic_heroes.GlobalUtils.HttpApi;
using UnityEngine;

namespace magic_heroes.Server.connection.handlers
{
    public class EventCheckMessageHandler : IMessageHandler
    {
        
        private static readonly Queue<string> Events = new Queue<string>();
        
        public Response HandleMessage(Request request)
        {
            if (Events.Count == 0)
            {
                return CachedResponses.NoContentResponse;
            }
            else
            {
                var eventName = Events.Dequeue();
                Debug.Log($"SERVER_INFO: Event {eventName} was founded");
                return new Response()
                {
                    status = 200,
                    fields = new Dictionary<string, string>()
                    {
                        { HttpAttributeNames.EVENT_NAME, eventName }
                    }
                };
            }
        }
        
        public static void AddEvent(string eventName) => Events.Enqueue(eventName);
    }
}