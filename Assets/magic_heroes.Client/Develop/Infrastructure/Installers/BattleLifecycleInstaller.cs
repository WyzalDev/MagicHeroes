using magic_heroes.Client.Infrastructure.States;
using magic_heroes.Client.UI;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using UnityEngine;
using Zenject;

namespace magic_heroes.Client.Infrastructure.Installers
{
    public class BattleLifecycleInstaller : MonoInstaller
    {
        [SerializeField] private CurrentTurnUIMark _currentTurnUIMark;
        [SerializeField] private GameObject _battleLifecyclePrefab;
        
        private const string BATTLE_LIFECYCLE_FSM_NAME = "BattleLifecycleFSM";
        
        public override void InstallBindings()
        {
            BindCurrentTurnUIMark();
            BindBattleLifecycleFSM();
        }

        private void BindBattleLifecycleFSM()
        {
            var battleLifecycleFSM = new Fsm(BATTLE_LIFECYCLE_FSM_NAME);
            
            battleLifecycleFSM.AddState(Container.Instantiate<EntryState>(new object[] { battleLifecycleFSM }));
            battleLifecycleFSM.AddState(Container.Instantiate<ClientPlayerTurnState>(new object[] { battleLifecycleFSM }));
            battleLifecycleFSM.AddState(Container.Instantiate<EnemyPlayerTurnState>(new object[] { battleLifecycleFSM }));
            battleLifecycleFSM.AddState(Container.Instantiate<ExitState>(new object[] { battleLifecycleFSM }));

            battleLifecycleFSM.SetState(EntryState.STATE_NAME);
            var battleLifecyclePrefabInstance = Container.InstantiatePrefabForComponent<LifecycleMono>(_battleLifecyclePrefab);
            battleLifecyclePrefabInstance.Construct(battleLifecycleFSM);
            
            //TODO when connection presenter is ready - delete
            //EntryState.GameStarted = true;
        }

        private void BindCurrentTurnUIMark()
        {
            Container.Bind<CurrentTurnUIMark>().FromInstance(_currentTurnUIMark).AsSingle();
        }
    }
}