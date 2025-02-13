using UnityEngine;

namespace magic_heroes.GlobalUtils.Lifecycle.FsmUtils
{
    public class LifecycleMono : MonoBehaviour
    {
        private Fsm fsm { get; set; }

        public void Construct(Fsm fsm) => this.fsm = fsm;

        private void Update() => fsm.Update();
    }
}