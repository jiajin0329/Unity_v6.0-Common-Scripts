using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface IState
    {
        public string name { get; }

        public event UnityAction OnEnter_Action;
        public event UnityAction Update_Action;
        public event UnityAction OnExit_Action;
    }
}