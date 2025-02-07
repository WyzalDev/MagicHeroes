namespace magic_heroes.GlobalUtils.Lifecycle.FsmUtils.States
{
    public class GameplayState  : FsmState
    {
        public const string STATE_NAME = "GameplayState";

        public GameplayState(Fsm fsm) : base(fsm) => Name = STATE_NAME;

        public override void Update()
        { }
    }
}