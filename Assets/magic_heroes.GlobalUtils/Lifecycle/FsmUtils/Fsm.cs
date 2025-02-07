using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting.FullSerializer.Internal;

namespace magic_heroes.GlobalUtils.Lifecycle.FsmUtils
{
    public class Fsm
    {
        private FsmState CurrentState { get; set; }

        private readonly Dictionary<string, FsmState> _states = new Dictionary<string, FsmState>();

        public void AddState(Type type)
        {
            if (type is null || !typeof(FsmState).IsAssignableFrom(type)) return;
            
            //create object of concrete type derived from FsmState through reflection
            var constructors = type.GetConstructors();
            var args = new object[1];
            args[0] = this;
            var state = (FsmState)constructors[0]?.Invoke(args);
            
            if (state is not null)
                _states.Add(state.Name, state);
        }

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