using System;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class StateMachine_TopDown : StateMachine, IStateMachine_TopDown
    {
        private State_TopDown[] _states;
        public IState_TopDown[] sates => _states;
        private IMoveModel _move_model;
        public bool is_move => _move_model.velocity.magnitude > 0f;
        [field: SerializeField]
        public Direction direction { get; private set; }

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

        public void Set_Reference(IMoveModel _move_model) { this._move_model = _move_model; }

        public override void Initialize()
        {
            base.Initialize();

            Tick_Action += Switch_Direction;
        }

        public void Switch_Direction()
        {
            if (!is_move) return;

            Direction _tempDirection;
            if (Is.Radian.Right(_move_model.moveRadian))
                _tempDirection = Direction.right;
            else if (Is.Radian.Left(_move_model.moveRadian))
                _tempDirection = Direction.left;
            else if (Is.Radian.Up(_move_model.moveRadian))
                _tempDirection = Direction.up;
            else
                _tempDirection = Direction.down;

            if (_tempDirection == direction) return;
            direction = _tempDirection;

            _states[_current_state_index].Switch_Direction();
        }
    }
}