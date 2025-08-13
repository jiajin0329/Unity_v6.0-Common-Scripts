using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public abstract class Launcher : Process_With_MonoBehaviour
    {
        public static Transform launcher_transform;
        public CancellationTokenSource cancellationTokenSource { get; private set; }
        [SerializeField]
        private Game_Data _game_data;
        protected abstract Module _module { get; }

        public Launcher(string _name) : base(_name) { }

        private async void Reset()
        {
            launcher_transform = transform;

            cancellationTokenSource = new();

            await _module.Variable_Null_Handle(cancellationTokenSource.Token);

            cancellationTokenSource.Cancel();
        }

        private async void Awake()
        {
            cancellationTokenSource = new();

            _game_data = _game_data.Initialize_With_Return();

            if (this is IHas_Initialize) Initialize();

            if (this is IHas_Initialize_With_UniTask) await Initialize_With_UniTask(cancellationTokenSource.Token);

            if (_is_has_begin) Begin();

            if (_is_has_begin_with_uniTask) await Begin_Detail_With_UniTask(cancellationTokenSource.Token);
        }

        protected override void Initialize_Detail()
        {
            launcher_transform = transform;

            _module.Initialize();
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            launcher_transform = transform;

            await _module.Initialize_With_UniTask(_cancellationToken);
        }

        protected override void Begin_Detail()
        {
            _module.Begin();
        }

        protected override async UniTask Begin_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await _module.Initialize_With_UniTask(_cancellationToken);
        }

        private void FixedUpdate()
        {
            if (_is_has_tick && is_finish)
            {
                Tick();
            }
        }

        protected override void Tick_Detail()
        {
            _module.Tick();
        }

        private void OnDestroy()
        {
            Cancel();
        }

        public void Cancel()
        {
            cancellationTokenSource?.Cancel();

            _module.Cancel();

            launcher_transform = null;
        }
    }
}