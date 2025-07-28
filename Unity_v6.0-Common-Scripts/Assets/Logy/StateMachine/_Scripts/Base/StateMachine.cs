using System;
using UnityEngine.Events;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class StateMachine : IStateMachine
    {
        protected byte _current_state_index;
        private State[] _states;
#if DEBUG
        [SerializeField] private string current_state_name;
        [SerializeField] private string[] show_all_state_name;

        public event UnityAction<string> Get_current_state_name_Action;
#endif

        public void Initialize()
        {
            Initialize_State();

#if DEBUG
            Initialize_current_state_name();

            Initialize_state_names();
#endif
        }

        public void Set_states(State[] _set) { _states = _set; } 

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

            Get_current_state_name_Action?.Invoke(current_state_name);
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

        public void Update()
        {
            _states[_current_state_index].OnUpdate();

            byte _next_state_index = _states[_current_state_index].Get_Next_State_Index();

            if (_next_state_index == _current_state_index) return;

            _states[_current_state_index].OnExit();

            _current_state_index = _next_state_index;

            _states[_current_state_index].OnEnter();
            _states[_current_state_index].OnUpdate();

#if UNITY_EDITOR
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
                _states[i].Update_Action += _unityAction;
            }
        }
    }
}