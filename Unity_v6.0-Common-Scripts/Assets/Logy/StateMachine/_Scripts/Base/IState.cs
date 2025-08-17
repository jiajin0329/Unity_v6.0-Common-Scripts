using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IState
    {
        public string name { get; }

        public event UnityAction OnEnter_Action;
        public event UnityAction Tick_Action;
        public event UnityAction OnExit_Action;
    }
}