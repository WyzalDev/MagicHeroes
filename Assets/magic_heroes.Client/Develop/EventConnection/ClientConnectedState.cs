using System.Collections;
using magic_heroes.Client.Dto;
using magic_heroes.Client.Presenter;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using UnityEngine;

namespace magic_heroes.Client.EventConnection
{
    public class ClientConnectedState : FsmState
    {
        public const string STATE_NAME = "ClientConnectedState";

        private readonly IConnectionPresenter _connectionPresenter;
        
        private readonly IEventHandler _eventHandler;

        private readonly ClientInfo _clientInfo;

        private readonly ClientObjectMarker _coroutinesBase;

        private readonly WaitForSeconds _cachedYieldReturn = new WaitForSeconds(1f);

        public ClientConnectedState(Fsm fsm, IConnectionPresenter connectionPresenter, IEventHandler eventHandler,
            ClientInfo clientInfo, ClientObjectMarker coroutinesBase) : base(fsm)
        {
            Name = STATE_NAME;
            _connectionPresenter = connectionPresenter;
            _clientInfo = clientInfo;
            _coroutinesBase = coroutinesBase;
            _eventHandler = eventHandler;
        }

        public override void Enter()
        {
            _coroutinesBase.StartCoroutine(TryGetEventsToHandleCoroutine());
        }

        public override void Exit()
        {
            _coroutinesBase.StopCoroutine(TryGetEventsToHandleCoroutine());
        }

        private IEnumerator TryGetEventsToHandleCoroutine()
        {
            IncomingEvent incomingEvent;
            do
            {
                do
                {
                    incomingEvent = _connectionPresenter.SendEventCheckRequest(_clientInfo.connection,
                        _clientInfo.user, _clientInfo.battleInGameId);
                    yield return _cachedYieldReturn;
                } while (incomingEvent is null);
                Debug.Log($"{fsm.FsmName}: Event {incomingEvent.name} received");
                _eventHandler.HandleIncomingEvent(incomingEvent);
                incomingEvent = null;
            } while (_connectionPresenter.isConnected);

            fsm.SetState(ClientDisconnectedState.STATE_NAME);
        }
    }
}