using System;
using UnityEngine.Events;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class StateMachine : IStateMachine
    {
        protected byte _current_state_index;
        private State[] _states;
#if DEBUG
        [field: SerializeField]
        public string current_state_name { get; private set; }
        [SerializeField]
        private string[] show_all_state_name;
#endif

        public event UnityAction Tick_Action;

        public void Set_states(State[] _set) { _states = _set; } 

        public virtual void Initialize()
        {
            Initialize_State();

#if DEBUG
            Initialize_current_state_name();

            Initialize_state_names();
#endif
        }

        private void Initialize_State()
        {
            if (_states is null) return;

            for (byte i = 0; i < _states.Length; i++)
            {
                State _state = _states[i];
                _state.Initialize();
            }
        }

#if DEBUG
        private void Initialize_current_state_name()
        {
            if (_states is null) return;

            Update_current_state_name();
        }

        private void Update_current_state_name()
        {
            current_state_name = _states[_current_state_index].name;
        }
        
        private void Initialize_state_names()
        {
            if (_states is null) return;

            show_all_state_name = new string[_states.Length];

            for (byte i = 0; i < show_all_state_name.Length; i++)
            {
                show_all_state_name[i] = _states[i].name;
            }
        }
#endif

        public void Tick()
        {
            byte _next_state_index = _states[_current_state_index].Get_Next_State_Index();

            if (_next_state_index != _current_state_index)
            {
                _states[_current_state_index].OnExit();
                _current_state_index = _next_state_index;
                _states[_current_state_index].OnEnter();
            }

            _states[_current_state_index].OnTick();
            Tick_Action?.Invoke();

#if DEBUG
            Update_current_state_name();
#endif
        }

        public void Add_All_State_Start_Action(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].OnEnter_Action += _unityAction;
            }
        }

        public void Add_All_State_Update_Action(UnityAction _unityAction)
        {
            for (byte i = 0; i < _states.Length; i++)
            {
                _states[i].Tick_Action += _unityAction;
            }
        }
    }
}