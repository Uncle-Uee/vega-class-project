using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace StateMachine
{
    public abstract class FsmBase : MonoBehaviour
    {
        public StateBase CurrentState;
        private readonly Dictionary<string, StateBase> _states = new();
        [SerializeField] private UnityEvent<StateBase> stateChange;

        protected void AddState(StateBase state)
        {
            _states.Add(state.GetType().Name, state);
        }

        private void Update()
        {
            CurrentState?.OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            CurrentState?.OnFixedUpdate(Time.fixedDeltaTime);
        }

        public T TransitionToState<T>() where T : StateBase
        {
            if (!_states.ContainsKey(typeof(T).Name))
            {
                Debug.Log($"{typeof(T).Name} was not found in the state dictionary");
                return null;
            }

            
            var state = _states[typeof(T).Name];

            CurrentState?.OnExit();
            CurrentState = state;
            CurrentState.OnEnter();
            
            stateChange.Invoke(state);
            return (T) state;
        }
    }
}