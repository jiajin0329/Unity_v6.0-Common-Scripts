using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public abstract class State : IState
    {
        [field: SerializeField] public string name { get; private set; }

        public event UnityAction OnEnterAction;
        public event UnityAction TickAction;
        public event UnityAction OnExitAction;

        public State(string _name) { name = _name; }

        public virtual void Initialize()
        {
            OnEnterAction = null;
            TickAction = null;
            OnExitAction = null;

#if UNITY_EDITOR
            AddActionLog();
#endif
        }

#if UNITY_EDITOR
        private void AddActionLog()
        {
            OnEnterAction += () => Debug.Log($"{name} {nameof(OnEnterAction)}");
            TickAction += () => Debug.Log($"{name} {nameof(TickAction)}");
            OnExitAction += () => Debug.Log($"{name} {nameof(OnExitAction)}");
        }
#endif

        public abstract byte GetNextStateIndex();

        public void OnEnter() { OnEnterAction?.Invoke(); }
        public void OnTick() { TickAction?.Invoke(); }
        public void OnExit() { OnExitAction?.Invoke(); }
    }
}