using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    public interface IStateTopDown : IState
    {
        public event UnityAction OnDownAction;
        public event UnityAction OnLeftAction;
        public event UnityAction OnRightAction;
        public event UnityAction OnUpAction;
    }
}