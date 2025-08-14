using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface IStateMachine
    {
#if DEBUG
        public string current_state_name { get; }
#endif
        public event UnityAction Tick_Action;
    }
}