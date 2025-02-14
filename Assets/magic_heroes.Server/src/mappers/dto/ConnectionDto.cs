using System;

namespace magic_heroes.Server.mappers.dto
{
    [Serializable]
    public class ConnectionDto
    {
        public bool isConnected;
        
        public long connectionId;
    }
}