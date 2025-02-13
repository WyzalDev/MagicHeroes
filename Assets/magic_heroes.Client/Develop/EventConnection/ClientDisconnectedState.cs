using System.Collections;
using JetBrains.Annotations;
using magic_heroes.Client.Dto;
using magic_heroes.Client.Infrastructure.States;
using magic_heroes.Client.Presenter;
using magic_heroes.Client.UI;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using UnityEngine;

namespace magic_heroes.Client.EventConnection
{
    public class ClientDisconnectedState : FsmState
    {
        public const string STATE_NAME = "ClientDisconnectedState";

        private readonly IConnectionPresenter _connectionPresenter;

        private readonly ClientInfo _clientInfo;

        private readonly ClientObjectMarker _coroutinesBase;

        private WaitForConnectionUIMark _waitForConnectionUIMark;

        private readonly WaitForSeconds _cachedYieldReturn = new WaitForSeconds(1f);

        public ClientDisconnectedState(Fsm fsm, IConnectionPresenter connectionPresenter, ClientInfo clientInfo,
            WaitForConnectionUIMark waitForConnectionUIMar, ClientObjectMarker coroutinesBase) : base(fsm)
        {
            Name = STATE_NAME;
            _connectionPresenter = connectionPresenter;
            _clientInfo = clientInfo;
            _coroutinesBase = coroutinesBase;
            _waitForConnectionUIMark = waitForConnectionUIMar;
        }

        public override void Enter()
        {
            base.Enter();
            if (!_waitForConnectionUIMark.gameObject.activeSelf)
            {
                _waitForConnectionUIMark.gameObject.SetActive(true);
            }
            _coroutinesBase.StartCoroutine(TryToConnectCoroutine());
        }

        public override void Exit()
        {
            base.Exit();
            if (_waitForConnectionUIMark.gameObject.activeSelf)
            {
                _waitForConnectionUIMark.gameObject.SetActive(false);
            }
            _coroutinesBase.StopCoroutine(TryToConnectCoroutine());
        }

        private IEnumerator TryToConnectCoroutine()
        {
            ConnectionDto connection;
            do
            {
                connection = _connectionPresenter.SendConnectRequest(_clientInfo.user, _clientInfo.battleInGameId);
                yield return _cachedYieldReturn;
            } while (!connection.isConnected);

            Debug.Log($"{fsm.FsmName}: Connection established");

            _clientInfo.connection.isConnected = connection.isConnected;
            _clientInfo.connection.connectionId = connection.connectionId;
            EntryState.GameStarted = true;

            fsm.SetState(ClientConnectedState.STATE_NAME);
        }
    }
}