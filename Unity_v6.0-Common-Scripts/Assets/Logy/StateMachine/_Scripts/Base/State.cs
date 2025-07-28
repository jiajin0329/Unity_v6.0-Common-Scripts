using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public abstract class State : IState
    {
        [field: SerializeField] public string name { get; private set; }

        public event UnityAction OnEnter_Action;
        public event UnityAction Update_Action;
        public event UnityAction OnExit_Action;

        public State(string _name) { name = _name; }

        public virtual void Initialize()
        {
            OnEnter_Action = null;
            Update_Action = null;
            OnExit_Action = null;

#if UNITY_EDITOR
            Add_Action_Log();
#endif
        }

#if UNITY_EDITOR
        private void Add_Action_Log()
        {
            OnEnter_Action += () => Debug.Log($"{name} {nameof(OnEnter_Action)}");
            Update_Action += () => Debug.Log($"{name} {nameof(Update_Action)}");
            OnExit_Action += () => Debug.Log($"{name} {nameof(OnExit_Action)}");
        }
#endif

        public abstract byte Get_Next_State_Index();

        public void OnEnter() { OnEnter_Action?.Invoke(); }
        public void OnUpdate() { Update_Action?.Invoke(); }
        public void OnExit() { OnExit_Action?.Invoke(); }
    }
}