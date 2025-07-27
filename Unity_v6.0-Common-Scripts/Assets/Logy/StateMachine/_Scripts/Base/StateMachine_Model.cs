using System;
using UnityEngine.Events;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class StateMachine_Model : IStateMachine_Model
    {
        [field: SerializeField] public byte current_state_index { get; private set; }
        protected State[] _states;
        public IState[] states => _states;
#if UNITY_EDITOR
        [SerializeField] private string current_state_name;
        [SerializeField] private string[] state_names;
#endif
        public event UnityAction<byte> Get_current_state_index_Action;

        public void Initialize()
        {
            Initialize_All_State();

#if UNITY_EDITOR
            Initialize_current_state_name();

            Initialize_state_names();
#endif
        }

        private void Initialize_All_State()
        {
            if (_states is null) return;

            for (byte i = 0; i < _states.Length; i++)
            {
                State _state = _states[i];
                _state.Initialize();
            }
        }

#if UNITY_EDITOR
        private void Initialize_current_state_name()
        {
            if (_states is null) return;

            Update_current_state_name();
        }

        private void Update_current_state_name()
        {
            current_state_name = _states[current_state_index].name;
        }
        
        private void Initialize_state_names()
        {
            if (_states is null) return;

            state_names = new string[_states.Length];

            for (byte i = 0; i < state_names.Length; i++)
            {
                state_names[i] = _states[i].name;
            }
        }
#endif

        public void Begin()
        {
            Get_current_state_index_Action?.Invoke(current_state_index);
        }

        public void Update()
        {
            Switch_State(_states[current_state_index].Get_Next_State_Index());
        }

        public void Switch_State(byte _index)
        {
            if (_index == current_state_index)
            {
                _states[current_state_index].Update();
                return;
            }    

            _states[current_state_index].End();

            //start next state
            Set_current_state_index(_index);
#if UNITY_EDITOR
            Update_current_state_name();
#endif

            _states[current_state_index].Start();
        }

        private void Set_current_state_index(byte _set)
        {
            current_state_index = _set;
            Get_current_state_index_Action?.Invoke(current_state_index);
        }

        public void Add_All_State_Start_Action(UnityAction _unityAction)
        {
            for (byte i = 0; i < states.Length; i++)
            {
                states[i].Start_Action += _unityAction;
            }
        }

        public void Add_All_State_Update_Action(UnityAction _unityAction)
        {
            for (byte i = 0; i < states.Length; i++)
            {
                states[i].Update_Action += _unityAction;
            }
        }
    }
}