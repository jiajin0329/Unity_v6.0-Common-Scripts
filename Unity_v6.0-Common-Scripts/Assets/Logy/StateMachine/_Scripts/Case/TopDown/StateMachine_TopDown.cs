using System;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class StateMachine_TopDown : StateMachine, IStateMachine_TopDown
    {
        private State_TopDown[] _states;
        public IState_TopDown[] sates => _states;
        public IInput_Model input_model;
        public bool is_move => input_model.input_distance > 0.2f;
        [field: SerializeField] public Direction direction { get; private set; }

        public State_TopDown state_idle => _states[Index.idle];
        public State_TopDown state_walk => _states[Index.walk];

        public IState_TopDown iState_idle => state_idle;
        public IState_TopDown iState_walk => state_walk;

        public struct Index
        {
            public const byte idle = 0;
            public const byte walk = 1;
            public const int amount = 2;
        }
        public enum Direction
        {
            down,
            left,
            right,
            up
        }

        public void Set_states(State_TopDown[] _set)
        {
            _states = _set;

            base.Set_states(_set);
        }

        public void Switch_Direction()
        {
            if (Is.Radian.Right(input_model.input_radian))
                direction = Direction.right;
            else if (Is.Radian.Left(input_model.input_radian))
                direction = Direction.left;
            else if (Is.Radian.Up(input_model.input_radian))
                direction = Direction.up;
            else
                direction = Direction.down;
            
            _states[_current_state_index].Switch_Direction();
        }
    }
}