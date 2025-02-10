using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using UnityEngine;

namespace magic_heroes.Client.Infrastructure.States
{
    public class EntryState : FsmState
    {
        public const string STATE_NAME = "EntryState";
        
        public static bool GameStarted = false;

        public EntryState(Fsm fsm) : base(fsm) => Name = STATE_NAME;

        public override void Update()
        {
            if (GameStarted)
            {
                fsm.SetState(FirstPlayerTurnState.STATE_NAME);
                GameStarted = false;
            }
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Game Started");
        }
    }
}