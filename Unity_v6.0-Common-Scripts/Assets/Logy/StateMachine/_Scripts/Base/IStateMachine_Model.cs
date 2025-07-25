using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface IStateMachine_Model
    {
        public byte current_state_index { get; }
        public event UnityAction<byte> Get_current_state_index_Action;

        public IState[] states { get; }

        public void Update();
        public abstract void Add_All_State_Start_Action(UnityAction _unityAction);
        public abstract void Add_All_State_Update_Action(UnityAction _unityAction);
    }
}