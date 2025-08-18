using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IState
    {
        public string name { get; }

        public event UnityAction OnEnterAction;
        public event UnityAction TickAction;
        public event UnityAction OnExitAction;
    }
}