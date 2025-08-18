using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IStateMachine
    {
#if DEBUG
        public string currentStateName { get; }
#endif
        public event UnityAction TickAction;
    }
}