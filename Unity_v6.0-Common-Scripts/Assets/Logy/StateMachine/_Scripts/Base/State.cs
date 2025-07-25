using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public abstract class State : Process, IState
    {
        [field: SerializeField] public string name { get; private set; }

        public event UnityAction Start_Action;
        public event UnityAction Update_Action;
        public event UnityAction End_Action;

        public State(string _name) : base(_name)
        {
            name  = _name;
        }

        protected override void Initialize_Detail()
        {
            Start_Action = null;
            Update_Action = null;
            End_Action = null;

#if UNITY_EDITOR
            Add_Action_Log();
#endif
        }

#if UNITY_EDITOR
        private void Add_Action_Log()
        {
            Start_Action += () => Debug.Log($"{name} {nameof(Start_Action)}");
            Update_Action += () => Debug.Log($"{name} {nameof(Update_Action)}");
            End_Action += () => Debug.Log($"{name} {nameof(End_Action)}");
        }
#endif

        public abstract byte Get_Next_State_Index();

        public void Start()
        {
            Start_Action?.Invoke();
        }

        public void Update()
        {
            Update_Action?.Invoke();
        }

        public void End()
        {
            End_Action?.Invoke();
        }
    }
}