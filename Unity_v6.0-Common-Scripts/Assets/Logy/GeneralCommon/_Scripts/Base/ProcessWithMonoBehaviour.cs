using System;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
#if UNITY_EDITOR
using NUnit.Framework;
#endif

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class ProcessWithMonoBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public ProcessState processState { get; private set; }
        protected bool _isHasInitialize { get; private set; }
        protected bool _isHasInitializeWithUniTask { get; private set; }
        protected bool _isHasBegin { get; private set; }
        protected bool _isHasBeginWithUniTask { get; private set; }
        protected bool _isHasTick { get; private set; }
        public bool isInitialized => processState > ProcessState.none;
        public bool isBegan => processState > ProcessState.initialized;
        public bool isFinish => processState > ProcessState.began;
        private string _name;
        public enum ProcessState : byte
        {
            none,
            initialized,
            began,
            finish
        }

        public ProcessWithMonoBehaviour(string _name) { this._name = _name; }

        private void CheckStructure()
        {
            _isHasInitialize = this is IHasInitialize;
            _isHasInitializeWithUniTask = this is IHasInitializeWithUniTask;
            _isHasBegin = this is IHasBegin;
            _isHasBeginWithUniTask = this is IHasBeginWithUniTask;
            _isHasTick = this is IHasTick;
        }

        public void Initialize()
        {
            CheckStructure();

            if (!_isHasInitialize)
            {
                Debug.LogError($"{nameof(IHasInitialize)} isn't inheritance.");
                return;
            }

            if (isInitialized)
            {
                Debug.LogWarning($"{_name} is already {nameof(ProcessState.initialized)}.");
                return;
            }

            if (_name is null)
                _name = GetType().Name;

            InitializeDetail();

            processState = this is IHasBegin or IHasBeginWithUniTask ? ProcessState.initialized : ProcessState.finish;

            Debug.Log($"{_name} is {nameof(ProcessState.initialized)}.");
        }

        protected virtual void InitializeDetail()
        {
            Debug.LogError($"{_name} {nameof(Initialize)} isn't implement!");
        }

        public async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            CheckStructure();

            if (!_isHasInitializeWithUniTask)
            {
                Debug.LogError($"{nameof(IHasInitializeWithUniTask)} isn't inheritance.");
                return;
            }

            if (isInitialized)
            {
                Debug.LogWarning($"{_name} is already {nameof(ProcessState.initialized)}.");
                return;
            }

            if (_name is null)
                _name = GetType().Name;

            await InitializeDetailWithUniTask(_cancellationToken);

            processState = this is IHasBegin or IHasBeginWithUniTask ? ProcessState.initialized : ProcessState.finish;

            Debug.Log($"{_name} is {nameof(ProcessState.initialized)}.");
        }

        protected virtual async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            Debug.LogError($"{_name} {nameof(InitializeWithUniTask)} isn't implement!");
            await UniTask.CompletedTask;
        }

        public void Begin()
        {
            if (!_isHasBegin)
            {
                Debug.LogError($"{nameof(IHasBegin)} isn't inheritance.");
                return;
            }

            if (isBegan)
            {
                Debug.LogWarning($"{_name} is already {nameof(ProcessState.began)}.");
                return;
            }

            BeginDetail();

            processState = ProcessState.finish;

            Debug.Log($"{_name} is {nameof(ProcessState.began)}.");
        }

        protected virtual void BeginDetail()
        {
            Debug.LogError($"{_name} {nameof(Begin)} isn't implement!");
        }

        public async UniTask BeginWithUniTask(CancellationToken _cancellationToken)
        {
            if (!!_isHasBeginWithUniTask)
            {
                Debug.LogError($"{nameof(IHasBeginWithUniTask)} isn't inheritance.");
                return;
            }

            if (isBegan)
            {
                Debug.LogWarning($"{_name} is already {nameof(ProcessState.began)}.");
                return;
            }

            await BeginWithUniTask(_cancellationToken);

            processState = ProcessState.finish;

            Debug.Log($"{_name} is {nameof(ProcessState.began)}.");
        }

        protected virtual async UniTask BeginDetailWithUniTask(CancellationToken _cancellationToken)
        {
            Debug.LogError($"{_name} {nameof(BeginWithUniTask)} isn't implement!");
            await UniTask.CompletedTask;
        }

        public void Tick()
        {
            if (!_isHasTick)
            {
                Debug.LogError($"{nameof(IHasTick)} isn't inheritance.");
                return;
            }

            TickDetail();
        }

        protected virtual void TickDetail()
        {
            Debug.LogError($"{_name} {nameof(Tick)} isn't implement!");
        }

#if UNITY_EDITOR
        public static void CheckInitialize(ProcessWithMonoBehaviour _process)
        {
            Assert.AreEqual(_process.processState, ProcessState.none);

            _process.Initialize();

            CheckAfterInitialize(_process);
        }

        private static void CheckAfterInitialize(ProcessWithMonoBehaviour _process)
        {
            if (_process is IHasBegin)
            {
                Assert.AreEqual(_process.processState, ProcessState.initialized);
                return;
            }

            Assert.AreEqual(_process.processState, ProcessState.finish);
        }

        public static async UniTask CheckInitializeWithUniTask(ProcessWithMonoBehaviour _process)
        {
            Assert.AreEqual(_process.processState, ProcessState.none);

            CancellationTokenSource _cancellationTokenSource = new();

            await _process.InitializeWithUniTask(_cancellationTokenSource.Token);

            _cancellationTokenSource.Cancel();

            CheckAfterInitialize(_process);
        }

        public static void CheckBegin(ProcessWithMonoBehaviour _process)
        {
            Assert.AreEqual(_process.processState, ProcessState.initialized);

            _process.Begin();

            Assert.AreEqual(_process.processState, ProcessState.finish);
        }

        public static async UniTask CheckBeginWithUniTask(ProcessWithMonoBehaviour _process)
        {
            Assert.AreEqual(_process.processState, ProcessState.initialized);

            CancellationTokenSource _cancellationTokenSource = new();

            await _process.BeginWithUniTask(_cancellationTokenSource.Token);

            _cancellationTokenSource.Cancel();

            Assert.AreEqual(_process.processState, ProcessState.finish);
        }
#endif
    }
}