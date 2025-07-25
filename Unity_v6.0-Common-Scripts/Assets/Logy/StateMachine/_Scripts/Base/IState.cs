using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    public interface IState
    {
        public string name { get; }

        public event UnityAction Start_Action;
        public event UnityAction Update_Action;
        public event UnityAction End_Action;
    }
}