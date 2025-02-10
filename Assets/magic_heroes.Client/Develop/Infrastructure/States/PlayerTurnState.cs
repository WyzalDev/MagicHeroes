using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;

namespace magic_heroes.Client.Infrastructure.States
{
    public abstract class PlayerTurnState : FsmState
    {
        public static bool SwitchPlayerStateHit = false;
        
        protected PlayerTurnState(Fsm fsm) : base(fsm)
        {
        }
    }
}