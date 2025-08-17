using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public class State_TopDown : State, IState_TopDown
    {
        private StateMachine_TopDown _stateMachine;

        public event UnityAction OnDown_Action;
        public event UnityAction OnLeft_Action;
        public event UnityAction OnRight_Action;
        public event UnityAction OnUp_Action;

        public State_TopDown(string _name, StateMachine_TopDown _stateMachine) : base(_name)
        {
            this._stateMachine = _stateMachine;
        }

        public override void Initialize()
        {
            OnEnter_Action += Switch_Direction;
        }

        public override byte Get_Next_State_Index()
        {
            return _stateMachine.is_move ? StateMachine_TopDown.Index.walk : StateMachine_TopDown.Index.idle;
        }

        public void Switch_Direction()
        {
            switch (_stateMachine.direction)
            {
                case StateMachine_TopDown.Direction.down:
                    OnDown_Action?.Invoke();
                    break;
                case StateMachine_TopDown.Direction.left:
                    OnLeft_Action?.Invoke();
                    break;
                case StateMachine_TopDown.Direction.right:
                    OnRight_Action?.Invoke();
                    break;
                case StateMachine_TopDown.Direction.up:
                    OnUp_Action?.Invoke();
                    break;
            }
        }
    }
}