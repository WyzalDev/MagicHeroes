namespace magic_heroes.GlobalUtils.Lifecycle.FsmUtils.States
{
    public class GlobalBootstrapState : FsmState
    {
        public const string STATE_NAME = "GlobalBootstrapState";

        public GlobalBootstrapState(Fsm fsm) : base(fsm) => Name = STATE_NAME;

        public override void Enter()
        {
            base.Enter();
            fsm.SetState(LoadingState.STATE_NAME);
        }

    }
}