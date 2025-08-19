using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IStateMachine
    {
#if DEBUG
        public string currentStateName { get; }
#endif

        public void AddAllStateTickListener(UnityAction _unityAction);
        public void RemoveAllStateTickListener(UnityAction _unityAction);
        public void AddAllStateOnEnterListener(UnityAction _unityAction);
        public void RemoveAllStateOnEnterListener(UnityAction _unityAction);
        public void AddAllStateOnExitListener(UnityAction _unityAction);
        public void RemoveAllStateOnExitListener(UnityAction _unityAction);
    }
}