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
        public Process_State process_state { get; private set; }
        protected bool _is_has_initialize { get; private set; }
        protected bool _is_has_initialize_with_uniTask { get; private set; }
        protected bool _is_has_begin { get; private set; }
        protected bool _is_has_begin_with_uniTask { get; private set; }
        protected bool _is_has_tick { get; private set; }
        public bool is_initialized => process_state > Process_State.none;
        public bool is_began => process_state > Process_State.initialized;
        public bool is_finish => process_state > Process_State.began;
        private string _name;
        public enum Process_State : byte
        {
            none,
            initialized,
            began,
            finish
        }

        public Process_With_MonoBehaviour(string _name) { this._name = _name; }

        private void Check_Structure()
        {
            _is_has_initialize = this is IHas_Initialize;
            _is_has_initialize_with_uniTask = this is IHas_Initialize_With_UniTask;
            _is_has_begin = this is IHas_Begin;
            _is_has_begin_with_uniTask = this is IHas_Begin_With_UniTask;
            _is_has_tick = this is IHas_Tick;
        }

        public void Initialize()
        {
            Check_Structure();

            if (!_is_has_initialize)
            {
                Debug.LogError($"{nameof(IHas_Initialize)} isn't inheritance.");
                return;
            }

            if (is_initialized)
            {
                Debug.LogWarning($"{_name} is already {nameof(Process_State.initialized)}.");
                return;
            }

            if (_name is null)
                _name = GetType().Name;

            Initialize_Detail();

            process_state = this is IHas_Begin or IHas_Begin_With_UniTask ? Process_State.initialized : Process_State.finish;

            Debug.Log($"{_name} is {nameof(Process_State.initialized)}.");
        }

        protected virtual void Initialize_Detail()
        {
            Debug.LogError($"{_name} {nameof(Initialize)} isn't implement!");
        }

        public async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            Check_Structure();

            if (!_is_has_initialize_with_uniTask)
            {
                Debug.LogError($"{nameof(IHas_Initialize_With_UniTask)} isn't inheritance.");
                return;
            }

            if (is_initialized)
            {
                Debug.LogWarning($"{_name} is already {nameof(Process_State.initialized)}.");
                return;
            }

            if (_name is null)
                _name = GetType().Name;

            await Initialize_Detail_With_UniTask(_cancellationToken);

            process_state = this is IHas_Begin or IHas_Begin_With_UniTask ? Process_State.initialized : Process_State.finish;

            Debug.Log($"{_name} is {nameof(Process_State.initialized)}.");
        }

        protected virtual async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            Debug.LogError($"{_name} {nameof(Initialize_With_UniTask)} isn't implement!");
            await UniTask.CompletedTask;
        }

        public void Begin()
        {
            if (!_is_has_begin)
            {
                Debug.LogError($"{nameof(IHas_Begin)} isn't inheritance.");
                return;
            }

            if (is_began)
            {
                Debug.LogWarning($"{_name} is already {nameof(Process_State.began)}.");
                return;
            }

            Begin_Detail();

            process_state = Process_State.finish;

            Debug.Log($"{_name} is {nameof(Process_State.began)}.");
        }

        protected virtual void Begin_Detail()
        {
            Debug.LogError($"{_name} {nameof(Begin)} isn't implement!");
        }

        public async UniTask Begin_With_UniTask(CancellationToken _cancellationToken)
        {
            if (!!_is_has_begin_with_uniTask)
            {
                Debug.LogError($"{nameof(IHas_Begin_With_UniTask)} isn't inheritance.");
                return;
            }

            if (is_began)
            {
                Debug.LogWarning($"{_name} is already {nameof(Process_State.began)}.");
                return;
            }

            await Begin_With_UniTask(_cancellationToken);

            process_state = Process_State.finish;

            Debug.Log($"{_name} is {nameof(Process_State.began)}.");
        }

        protected virtual async UniTask Begin_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            Debug.LogError($"{_name} {nameof(Begin_With_UniTask)} isn't implement!");
            await UniTask.CompletedTask;
        }

        public void Tick()
        {
            if (!_is_has_tick)
            {
                Debug.LogError($"{nameof(IHas_Tick)} isn't inheritance.");
                return;
            }

            Tick_Detail();
        }

        protected virtual void Tick_Detail()
        {
            Debug.LogError($"{_name} {nameof(Tick)} isn't implement!");
        }

#if UNITY_EDITOR
        public static void Check_Initialize(Process _process)
        {
            Assert.AreEqual(_process.process_state, Process_State.none);

            _process.Initialize();

            Check_After_Initialize(_process);
        }

        private static void Check_After_Initialize(Process _process)
        {
            if (_process is IHas_Begin)
            {
                Assert.AreEqual(_process.process_state, Process_State.initialized);
                return;
            }

            Assert.AreEqual(_process.process_state, Process_State.finish);
        }

        public static async UniTask Check_Initialize_With_UniTask(Process _process)
        {
            Assert.AreEqual(_process.process_state, Process_State.none);

            CancellationTokenSource _cancellationTokenSource = new();

            await _process.Initialize_With_UniTask(_cancellationTokenSource.Token);

            _cancellationTokenSource.Cancel();

            Check_After_Initialize(_process);
        }

        public static void Check_Begin(Process _process)
        {
            Assert.AreEqual(_process.process_state, Process_State.initialized);

            _process.Begin();

            Assert.AreEqual(_process.process_state, Process_State.finish);
        }

        public static async UniTask Check_Begin_With_UniTask(Process _process)
        {
            Assert.AreEqual(_process.process_state, Process_State.initialized);

            CancellationTokenSource _cancellationTokenSource = new();

            await _process.Begin_With_UniTask(_cancellationTokenSource.Token);

            _cancellationTokenSource.Cancel();

            Assert.AreEqual(_process.process_state, Process_State.finish);
        }
#endif
    }
}