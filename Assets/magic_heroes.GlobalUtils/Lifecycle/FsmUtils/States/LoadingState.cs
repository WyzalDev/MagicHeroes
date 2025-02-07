using magic_heroes.Client.Develop.SceneManagement;
using UnityEngine.SceneManagement;

namespace magic_heroes.GlobalUtils.Lifecycle.FsmUtils.States
{
    public class LoadingState : FsmState
    {
        public const string STATE_NAME = "LoadingState";

        public LoadingState(Fsm fsm) : base(fsm) => Name = STATE_NAME;

        public override void Enter()
        {
            base.Enter();
            SceneLoader.instance.LoadScene(SceneLoader.SceneName.Battle);
            fsm.SetState(GameplayState.STATE_NAME);
        }
    }
}