using magic_heroes.Client.SceneManagement;
using UnityEngine;

namespace magic_heroes.GlobalUtils.Lifecycle.FsmUtils.States
{
    public class GameplayState  : FsmState
    {
        public const string STATE_NAME = "GameplayState";
        
        public static bool ResetHitted = false;

        public GameplayState(Fsm fsm) : base(fsm) => Name = STATE_NAME;

        public override void Update()
        {
            if (ResetHitted) Reset();
        } 

        private void Reset()
        {
            Debug.Log($"{fsm.FsmName}: Reset Started");
            ResetHitted = false;
            fsm.SetState(LoadingState.STATE_NAME);
        }
    }
}