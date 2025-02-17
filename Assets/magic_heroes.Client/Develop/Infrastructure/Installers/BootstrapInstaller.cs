using magic_heroes.Client.EventConnection;
using magic_heroes.Client.Presenter;
using magic_heroes.Client.UI;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace magic_heroes.Client.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameObject connectionLifecyclePrefab;

        [SerializeField] private GameObject waitForConnectionUIPrefab;
        
        private const string CONNECTION_LIFECYCLE_FSM_NAME = "ConnectionLifecycleFSM";
        
        public override void InstallBindings()
        {
            BindWaitForConnectionUI();
            BindResetPresenter();
            BindEndTurnPresenter();
            BindConnectionPresenter();
            BindEventHandler();
            BindConnectionLifecycleFSM();
            Debug.Log("BootstrapInstaller InstallBindings");
        }

        private void BindWaitForConnectionUI()
        {
            var waitForConnectionUIMarkInstance = Container.InstantiatePrefabForComponent<WaitForConnectionUIMark>(waitForConnectionUIPrefab);
            DontDestroyOnLoad(waitForConnectionUIMarkInstance);
            Container.BindInstance(waitForConnectionUIMarkInstance).AsSingle();
        }

        private void BindEndTurnPresenter()
        {
            Container.BindInterfacesAndSelfTo<EndTurnPresenter>().AsSingle();
        }

        private void BindResetPresenter()
        {
            Container.BindInterfacesAndSelfTo<ResetPresenter>().AsSingle();
        }

        private void BindConnectionPresenter()
        {
            Container
                .BindInterfacesTo<PollingConnectionPresenter>()
                .AsSingle();
        }
        
        private void BindEventHandler()
        {
            Container
                .BindInterfacesTo<ClientEventHandler>()
                .AsSingle();
        }
        
        private void BindConnectionLifecycleFSM()
        {
            var connectionFsmObject = Container.InstantiatePrefab(connectionLifecyclePrefab).GetComponent<ClientObjectMarker>();
            DontDestroyOnLoad(connectionFsmObject);
            Container.Bind<ClientObjectMarker>().FromInstance(connectionFsmObject).AsSingle();

            var connectionFsm = new Fsm(CONNECTION_LIFECYCLE_FSM_NAME);
            connectionFsm.AddState(Container.Instantiate<ClientDisconnectedState>(new object[] { connectionFsm }));
            connectionFsm.AddState(Container.Instantiate<ClientConnectedState>(new object[] { connectionFsm }));
            
            connectionFsmObject.GetComponent<LifecycleMono>().Construct(connectionFsm);
            connectionFsm.SetState(ClientDisconnectedState.STATE_NAME);
        }
    }
}