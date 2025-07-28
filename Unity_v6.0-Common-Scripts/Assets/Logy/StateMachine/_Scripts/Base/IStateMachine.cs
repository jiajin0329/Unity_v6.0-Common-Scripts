using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface IStateMachine
    {
#if DEBUG
        public event UnityAction<string> Get_current_state_name_Action;
#endif
    }
}