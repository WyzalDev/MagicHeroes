using System;
using System.Collections.Generic;
using System.Linq;

namespace magic_heroes.GlobalUtils.Lifecycle.FsmUtils
{
    public class Fsm
    {
        private FsmState CurrentState { get; set; }

        private readonly Dictionary<string, FsmState> _states = new Dictionary<string, FsmState>();

        public void AddState(FsmState state) => _states.Add(state.Name, state);

        public void SetState(string name)
        {
            if (CurrentState != null && CurrentState.Name.Equals(name)) return;
            if (!_states.TryGetValue(name, out var newState)) return;
            
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public bool ContainsState(string name) => _states.ContainsKey(name);

        public void Update() => CurrentState?.Update();
        
    }
}