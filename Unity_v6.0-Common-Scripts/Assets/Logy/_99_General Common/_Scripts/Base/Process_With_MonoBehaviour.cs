using System;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
#if UNITY_EDITOR
using NUnit.Framework;
#endif

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Process_With_MonoBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public State process_state { get; private set; }
        public bool is_initialized => process_state > State.none;
        public bool is_began => process_state > State.initialized;
        public bool is_finish => process_state > State.began;
        private string _name;
        public enum State : byte
        {
            none,
            initialized,
            began,
            finish
        }
        public enum Type : byte
        {
            normal,
            uniTask,
        }

        public Process_With_MonoBehaviour(string _name) { this._name = _name; }

        public void Initialize()
        {
            if (is_initialized)
            {
                Debug.LogWarning($"{_name} is already {nameof(State.initialized)}.");
                return;
            }

            if (_name is null)
                _name = GetType().Name;

            Initialize_Detail();

            process_state = this is IHas_Begin ? State.initialized : State.finish;

            Debug.Log($"{_name} is {nameof(State.initialized)}.");
        }

        protected virtual void Initialize_Detail()
        {
            Debug.LogError($"{nameof(Initialize)} isn't implement!");
        }

        public async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            if (is_initialized)
            {
                Debug.LogWarning($"{_name} is already {nameof(State.initialized)}.");
                return;
            }

            if (_name is null)
                _name = GetType().Name;

            await Initialize_Detail_With_UniTask(_cancellationToken);

            process_state = this is IHas_Begin ? State.initialized : State.finish;

            Debug.Log($"{_name} is {nameof(State.initialized)}.");
        }

        protected virtual async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            Debug.LogError($"{nameof(Initialize_With_UniTask)} isn't implement!");
            await UniTask.CompletedTask;
        }

        public void Begin()
        {
            if (is_began)
            {
                Debug.LogWarning($"{_name} is already {nameof(State.began)}.");
                return;
            }

            Begin_Detail();

            process_state = State.finish;

            Debug.Log($"{_name} is {nameof(State.began)}.");
        }

        protected virtual void Begin_Detail()
        {
            Debug.LogError($"{nameof(Begin)} isn't implement!");
        }

        public async UniTask Begin_With_UniTask(CancellationToken _cancellationToken)
        {
            if (is_began)
            {
                Debug.LogWarning($"{_name} is already {nameof(State.began)}.");
                return;
            }

            await Begin_With_UniTask(_cancellationToken);

            process_state = State.finish;

            Debug.Log($"{_name} is {nameof(State.began)}.");
        }

        protected virtual async UniTask Begin_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            Debug.LogError($"{nameof(Begin_With_UniTask)} isn't implement!");
            await UniTask.CompletedTask;
        }

#if UNITY_EDITOR
        public static void Check_Initialize(Process_With_MonoBehaviour _process)
        {
            Assert.AreEqual(_process.process_state, State.none);

            _process.Initialize();

            Check_After_Initialize(_process);
        }

        private static void Check_After_Initialize(Process_With_MonoBehaviour _process)
        {
            if (_process is IHas_Begin)
            {
                Assert.AreEqual(_process.process_state, State.initialized);
                return;
            }

            Assert.AreEqual(_process.process_state, State.finish);
        }

        public static async UniTask Check_Initialize_With_UniTask(Process_With_MonoBehaviour _process)
        {
            Assert.AreEqual(_process.process_state, State.none);

            CancellationTokenSource _cancellationTokenSource = new();

            await _process.Initialize_With_UniTask(_cancellationTokenSource.Token);

            _cancellationTokenSource.Cancel();

            Check_After_Initialize(_process);
        }

        public static void Check_Begin(Process_With_MonoBehaviour _process)
        {
            Assert.AreEqual(_process.process_state, State.initialized);

            _process.Begin();

            Assert.AreEqual(_process.process_state, State.finish);
        }

        public static async UniTask Check_Begin_With_UniTask(Process_With_MonoBehaviour _process)
        {
            Assert.AreEqual(_process.process_state, State.initialized);

            CancellationTokenSource _cancellationTokenSource = new();

            await _process.Begin_With_UniTask(_cancellationTokenSource.Token);

            _cancellationTokenSource.Cancel();

            Assert.AreEqual(_process.process_state, State.finish);
        }
#endif
    }
}