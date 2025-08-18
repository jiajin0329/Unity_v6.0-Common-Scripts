using System;
using UnityEngine.Events;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class StateMachine : IStateMachine
    {
        protected byte _currentStateIndex;
        private State[] _states;
#if DEBUG
        [field: SerializeField]
        public string currentStateName { get; private set; }
        [SerializeField]
        private string[] showAllStateName;
#endif

        public event UnityAction TickAction;

        public void SetStates(State[] _set) { _states = _set; } 

        public virtual void Initialize()
        {
            InitializeState();

#if DEBUG
            InitializeCurrentStateName();

            InitializeStateNames();
#endif
        }

        private void InitializeState()
        {
            if (_states is null) return;

            for (byte i = 0; i < _states.Length; i++)
            {
                State _state = _states[i];
                _state.Initialize();
            }
        }

#if DEBUG
        private void InitializeCurrentStateName()
        {
            if (_states is null) return;

            UpdateCurrentStateName();
        }

        private void UpdateCurrentStateName()
        {
            currentStateName = _states[_currentStateIndex].name;
        }
        
        private void InitializeStateNames()
        {
            if (_states is null) return;

            showAllStateName = new string[_states.Length];

            for (byte i = 0; i < showAllStateName.Length; i++)
            {
                showAllStateName[i] = _states[i].name;
            }
        }
#endif

        public void Tick()
        {
            byte _nextStateIndex = _states[_currentStateIndex].GetNextStateIndex();

            if (_nextStateIndex != _currentStateIndex)
            {
                _states[_currentStateIndex].OnExit();
                _currentStateIndex = _nextStateIndex;
                _states[_currentStateIndex].OnEnter();
            }

            _states[_currentStateIndex].OnTick();
            TickAction?.Invoke();

#if DEBUG
            UpdateCurrentStateName();
#endif
        }

        public void AddAllStateStartAction(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].OnEnterAction += _unityAction;
            }
        }

        public void AddAllStateUpdateAction(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].TickAction += _unityAction;
            }
        }
    }
}