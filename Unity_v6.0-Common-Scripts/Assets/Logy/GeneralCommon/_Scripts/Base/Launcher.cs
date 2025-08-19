using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    public abstract class Launcher : ProcessWithMonoBehaviour
    {
        public static Transform launcherTransform;
        public CancellationTokenSource cancellationTokenSource { get; private set; }
        [SerializeField]
        private GameData _gameData;
        protected abstract Module _module { get; }

        public Launcher(string _name) : base(_name) { }

        private async void Reset()
        {
            launcherTransform = transform;

            cancellationTokenSource = new();

            await _module.VariableNullHandle(cancellationTokenSource.Token);

            cancellationTokenSource.Cancel();
        }

        private async void Awake()
        {
            cancellationTokenSource = new();

            _gameData = _gameData.InitializeWithReturn();

            if (this is IHasInitialize) Initialize();

            if (this is IHasInitializeWithUniTask) await InitializeWithUniTask(cancellationTokenSource.Token);

            if (_isHasBegin) Begin();

            if (_isHasBeginWithUniTask) await BeginDetailWithUniTask(cancellationTokenSource.Token);
        }

        protected override void InitializeDetail()
        {
            launcherTransform = transform;

            _module.Initialize();
        }

        protected override async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            launcherTransform = transform;

            await _module.InitializeWithUniTask(_cancellationToken);
        }

        protected override void BeginDetail()
        {
            _module.Begin();
        }

        protected override async UniTask BeginDetailWithUniTask(CancellationToken _cancellationToken)
        {
            await _module.BeginWithUniTask(_cancellationToken);
        }

        private void FixedUpdate()
        {
            if (_isHasTick && isFinish)
            {
                Tick();
            }
        }

        protected override void TickDetail()
        {
            _module.Tick();
        }

        private void OnDestroy()
        {
            Destroy();
        }

        public void Destroy()
        {
            cancellationTokenSource?.Cancel();

            _module.Destroy();

            launcherTransform = null;
        }
    }
}