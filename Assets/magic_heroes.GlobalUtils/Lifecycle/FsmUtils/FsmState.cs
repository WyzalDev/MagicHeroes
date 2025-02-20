﻿using UnityEngine;

namespace magic_heroes.GlobalUtils.Lifecycle.FsmUtils
{
    public abstract class FsmState
    {
        public string Name { get; protected set; }

        protected readonly Fsm fsm;

        public FsmState(Fsm fsm) => this.fsm = fsm;

        public virtual void Enter() => Debug.Log($"{fsm.FsmName}: Enter [{Name}] state");

        public virtual void Exit() => Debug.Log($"{fsm.FsmName}: Exit [{Name}] state -> switching states");

        public virtual void Update() { }

    }
}