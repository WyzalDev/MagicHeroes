using System.Collections.Generic;
using magic_heroes.Client.Dto;
using magic_heroes.Client.EventConnection;
using magic_heroes.Client.Infrastructure.States;
using magic_heroes.GlobalUtils;
using magic_heroes.GlobalUtils.GlobalConnection;
using magic_heroes.GlobalUtils.HttpApi;
using UnityEngine;

namespace magic_heroes.Client.Presenter
{
    public class PollingConnectionPresenter : IConnectionPresenter
    {
        #region CACHED_INFO
        private readonly ConnectionDto _failedConnection = new ConnectionDto()
        {
            isConnected = false,
            connectionId = -1
        };
        
        private Request _eventCheckRequest = new Request()
        {
            msgHandlerName = MessageHandlerNames.EventCheckMessageHandlerName,
            fields = new Dictionary<string, string>()
        };
        
        private Request _tryConnectRequest = new Request()
        {
            msgHandlerName = MessageHandlerNames.ConnectMessageHandlerName,
            fields = new Dictionary<string, string>()
        };
        #endregion

        public bool isConnected { get; private set; }

        public PollingConnectionPresenter()
        {
            isConnected = false;
        }

        public ConnectionDto SendConnectRequest( UserDto user, long battleInGameId)
        {
            RewriteEventCheckRequestDictionary(null, user, battleInGameId);
            var response = ClientServerAdapter.Instance.SendRequest(_tryConnectRequest);
            Debug.Log($"Response came back from {MessageHandlerNames.ConnectMessageHandlerName}, status = {response.status}, Fields = {response.fields.ToDebugString()}");
            if (response.status == 200 && response.fields.TryGetValue(HttpAttributeNames.CONNECTION, out var connection)
                                       && response.fields.TryGetValue(HttpAttributeNames.USER,out var currentTurnUserJson))
            {
                isConnected = true;
                var connectionDto = JsonUtility.FromJson<ConnectionDto>(connection);
                var currentTurnUser = JsonUtility.FromJson<UserDto>(currentTurnUserJson);
                EntryState.isClientTurn = currentTurnUser.id == user.id;
                return connectionDto;
            }
            else
            {
                return _failedConnection;
            }
        }

        public IncomingEvent SendEventCheckRequest(ConnectionDto connection, UserDto user, long battleInGameId)
        {
            if(!isConnected) return null;
            RewriteEventCheckRequestDictionary(connection, user, battleInGameId);
            var response = ClientServerAdapter.Instance.SendRequest(_eventCheckRequest);
            if (response.status == 200 && response.fields.TryGetValue(HttpAttributeNames.EVENT_NAME, out var field))
            {
                var incomingEvent = new IncomingEvent()
                {
                    name = field
                };
                Debug.Log($"Event came back from {MessageHandlerNames.EventCheckMessageHandlerName}, event_name = {field}");
                return incomingEvent;
            }
            else
            {
                return null;
            }
        }

        private void RewriteEventCheckRequestDictionary(ConnectionDto connection, UserDto user, long battleInGameId)
        {
            if (connection is null)
            {
                _tryConnectRequest.fields[HttpAttributeNames.USER] = JsonUtility.ToJson(user);
                _tryConnectRequest.fields[HttpAttributeNames.BATTLE_INGAME_ID] = battleInGameId.ToString();
            }
            else
            {
                _eventCheckRequest.fields[HttpAttributeNames.CONNECTION] = JsonUtility.ToJson(connection);
                _eventCheckRequest.fields[HttpAttributeNames.USER] = JsonUtility.ToJson(user);
                _eventCheckRequest.fields[HttpAttributeNames.BATTLE_INGAME_ID] = battleInGameId.ToString();
            }
        }
    }
}