using System;
using magic_heroes.Client.Dto;

namespace magic_heroes.Client
{
    [Serializable]
    public class ClientInfo
    {
        public UserDto user;

        public ConnectionDto connection;
        
        public long battleInGameId;
    }
}