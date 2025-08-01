using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface IState_TopDown : IState
    {
        public event UnityAction OnDown_Action;
        public event UnityAction OnLeft_Action;
        public event UnityAction OnRight_Action;
        public event UnityAction OnUp_Action;
    }
}