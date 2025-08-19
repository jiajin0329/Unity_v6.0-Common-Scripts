using System;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class StateMachineTopDown : StateMachine, IStateMachineTopDown
    {
        private StateTopDown[] _states;
        public IStateTopDown[] sates => _states;
        private IMoveModel _move_model;
        public bool is_move => _move_model.velocity.magnitude > 0f;
        [field: SerializeField]
        public Direction direction { get; private set; }

        public StateTopDown state_idle => _states[Index.idle];
        public StateTopDown state_walk => _states[Index.walk];

        public IStateTopDown iStateIdle => state_idle;
        public IStateTopDown iStateWalk => state_walk;

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

        public void SetStates(StateTopDown[] _set)
        {
            _states = _set;

            base.SetStates(_set);
        }

        public void SetReference(IMoveModel _move_model) { this._move_model = _move_model; }

        public override void Initialize()
        {
            base.Initialize();

            AddAllStateTickListener(SwitchDirection);
        }

        public void SwitchDirection()
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

            _states[_currentStateIndex].SwitchDirection();
        }
    }
}