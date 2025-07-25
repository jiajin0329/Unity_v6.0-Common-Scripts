using System;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class StateMachine_Model_TopDown : StateMachine_Model, IStateMachine_Model_TopDown
    {
        public struct Index
        {
            public const byte idle_down = 0;
            public const byte idle_left = 1;
            public const byte idle_right = 2;
            public const byte idle_up = 3;
            public const byte walk_down = 4;
            public const byte walk_left = 5;
            public const byte walk_right = 6;
            public const byte walk_up = 7;
            public const int amount = 8;
        }

        public IState state_idle_down => states[Index.idle_down];
        public IState state_idle_left => states[Index.idle_left];
        public IState state_idle_right => states[Index.idle_right];
        public IState state_idle_up => states[Index.idle_up];
        public IState state_walk_down => states[Index.walk_down];
        public IState state_walk_left => states[Index.walk_left];
        public IState state_walk_right => states[Index.walk_right];
        public IState state_walk_up => states[Index.walk_up];

        public class State_Data
        {
            public State idle_down;
            public State idle_left;
            public State idle_right;
            public State idle_up;
            public State walk_down;
            public State walk_left;
            public State walk_right;
            public State walk_up;
        }

        public StateMachine_Model_TopDown(State_Data _state_data)
        {
            //new state
            _states = new State[Index.amount];

            _states[Index.idle_down] = _state_data.idle_down;
            _states[Index.idle_left] = _state_data.idle_left;
            _states[Index.idle_right] = _state_data.idle_right;
            _states[Index.idle_up] = _state_data.idle_up;
            _states[Index.walk_down] = _state_data.walk_down;
            _states[Index.walk_left] = _state_data.walk_left;
            _states[Index.walk_right] = _state_data.walk_right;
            _states[Index.walk_up] = _state_data.walk_up;
        }

        public static bool Is_Index_idle_down(byte _index)
        {
            return _index == Index.idle_down;
        }

        public static bool Is_Index_idle_left(byte _index)
        {
            return _index == Index.idle_left;
        }

        public static bool Is_Index_idle_right(byte _index)
        {
            return _index == Index.idle_right;
        }

        public static bool Is_Index_idle_up(byte _index)
        {
            return _index == Index.idle_up;
        }

        public static bool Is_Index_walk_down(byte _index)
        {
            return _index == Index.walk_down;
        }

        public static bool Is_Index_walk_left(byte _index)
        {
            return _index == Index.walk_left;
        }

        public static bool Is_Index_walk_right(byte _index)
        {
            return _index == Index.walk_right;
        }

        public static bool Is_Index_walk_up(byte _index)
        {
            return _index == Index.walk_up;
        }
    }
}