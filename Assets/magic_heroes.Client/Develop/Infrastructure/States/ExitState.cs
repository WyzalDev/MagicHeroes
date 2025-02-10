using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;

namespace magic_heroes.Client.Infrastructure.States
{
    public class ExitState : FsmState
    {
        public const string STATE_NAME = "ExitState";

        public ExitState(Fsm fsm) : base(fsm) => Name = STATE_NAME;

    }
}