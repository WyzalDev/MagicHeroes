using System;

namespace magic_heroes.Client.Dto
{
    [Serializable]
    public class ConnectionDto
    {
        public bool isConnected;
        
        public long connectionId;
    }
}