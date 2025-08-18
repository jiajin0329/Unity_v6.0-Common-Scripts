using System;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public struct FactoryStateMachineTopDown
    {
        public enum Type : byte
        {
            player,
        }

        public static StateMachineTopDown New(Type _type)
        {
            if (_type is Type.player)
            {
                StateMachineTopDown _stateMachine = new();

                StateTopDown[] _states = new StateTopDown[]
                {
                    new StateTopDown(nameof(StateMachineTopDown.Index.idle), _stateMachine),
                    new StateTopDown(nameof(StateMachineTopDown.Index.walk), _stateMachine),
                };

                _stateMachine.SetStates(_states);

                return _stateMachine;
            }

            return null;
        }
    }
}