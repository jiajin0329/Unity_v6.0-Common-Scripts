using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IStateMachine
    {
#if DEBUG
        public string current_state_name { get; }
#endif
        public event UnityAction Tick_Action;
    }
}