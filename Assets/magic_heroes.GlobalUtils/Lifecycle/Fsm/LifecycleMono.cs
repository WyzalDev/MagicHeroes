using System;
using UnityEngine;

namespace magic_heroes.GlobalUtils.Lifecycle.Fsm
{
    public class LifecycleMono : MonoBehaviour
    {
        private Fsm fsm { get; set; }

        public void Construct(Fsm fsm) => this.fsm = fsm;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update() => fsm.Update();
    }
}