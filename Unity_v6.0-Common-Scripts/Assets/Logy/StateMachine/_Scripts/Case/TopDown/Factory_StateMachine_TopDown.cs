using System;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public struct Factory_StateMachine_TopDown
    {
        public enum Type : byte
        {
            player,
        }

        public static StateMachine_TopDown New(Type _type)
        {
            if (_type is Type.player)
            {
                StateMachine_TopDown _stateMachine = new();

                State_TopDown[] _states = new State_TopDown[]
                {
                    new State_TopDown(nameof(StateMachine_TopDown.Index.idle), _stateMachine),
                    new State_TopDown(nameof(StateMachine_TopDown.Index.walk), _stateMachine),
                };

                _stateMachine.Set_states(_states);

                return _stateMachine;
            }

            return null;
        }
    }
}