using magic_heroes.Client.Dto;
using magic_heroes.Client.EventConnection;

namespace magic_heroes.Client.Presenter
{
    public interface IConnectionPresenter
    {
        public bool isConnected { get; }

        public ConnectionDto SendConnectRequest(UserDto user, long battleInGameId);

        public IncomingEvent SendEventCheckRequest(ConnectionDto connection, UserDto user, long battleInGameId);
    }
}