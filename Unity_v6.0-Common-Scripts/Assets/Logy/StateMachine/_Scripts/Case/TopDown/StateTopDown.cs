using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public class StateTopDown : State, IStateTopDown
    {
        private StateMachineTopDown _stateMachine;

        public event UnityAction OnDownAction;
        public event UnityAction OnLeftAction;
        public event UnityAction OnRightAction;
        public event UnityAction OnUpAction;

        public StateTopDown(string _name, StateMachineTopDown _stateMachine) : base(_name)
        {
            this._stateMachine = _stateMachine;
        }

        public override void Initialize()
        {
            OnEnterAction += SwitchDirection;
        }

        public override byte GetNextStateIndex()
        {
            return _stateMachine.is_move ? StateMachineTopDown.Index.walk : StateMachineTopDown.Index.idle;
        }

        public void SwitchDirection()
        {
            switch (_stateMachine.direction)
            {
                case StateMachineTopDown.Direction.down:
                    OnDownAction?.Invoke();
                    break;
                case StateMachineTopDown.Direction.left:
                    OnLeftAction?.Invoke();
                    break;
                case StateMachineTopDown.Direction.right:
                    OnRightAction?.Invoke();
                    break;
                case StateMachineTopDown.Direction.up:
                    OnUpAction?.Invoke();
                    break;
            }
        }
    }
}