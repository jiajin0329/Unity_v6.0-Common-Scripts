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
            _states[_currentStateIndex].OnTick();

            byte _nextStateIndex = _states[_currentStateIndex].GetNextStateIndex();

            if (_nextStateIndex != _currentStateIndex)
            {
                _states[_currentStateIndex].OnExit();
                _currentStateIndex = _nextStateIndex;
                _states[_currentStateIndex].OnEnter();
            }

#if DEBUG
            UpdateCurrentStateName();
#endif
        }

        public void AddAllStateTickListener(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].TickAction += _unityAction;
            }
        }

        public void RemoveAllStateTickListener(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].TickAction += _unityAction;
            }
        }

        public void AddAllStateOnEnterListener(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].OnEnterAction += _unityAction;
            }
        }

        public void RemoveAllStateOnEnterListener(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].OnEnterAction += _unityAction;
            }
        }

        public void AddAllStateOnExitListener(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].OnExitAction += _unityAction;
            }
        }
        
        
        public void RemoveAllStateOnExitListener(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].OnExitAction += _unityAction;
            }
        }
    }
}