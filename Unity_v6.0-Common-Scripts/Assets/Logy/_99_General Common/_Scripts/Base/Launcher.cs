using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public abstract class Launcher : Process_With_MonoBehaviour
    {
        public static Transform launcher_transform;
        public CancellationTokenSource cancellationTokenSource { get; private set; }

        [SerializeField] private Game_Data _game_data;
        protected abstract Core _core { get; }

        public Launcher(string _name) : base(_name) {}

        private async void Reset()
        {
            launcher_transform = transform;

            cancellationTokenSource = new();

            await _core.Reset(cancellationTokenSource.Token);

            cancellationTokenSource.Cancel();
        }

        private async void Awake()
        {
            cancellationTokenSource = new();

            _game_data.Initialize();

            if (this is IHas_Initialize) Initialize();

            if (this is IHas_Initialize_With_UniTask) await Initialize_With_UniTask(cancellationTokenSource.Token);

            if (this is IHas_Begin) Begin();
            
            if (this is IHas_Begin_With_UniTask) await Begin_Detail_With_UniTask(cancellationTokenSource.Token);
        }

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            launcher_transform = transform;

            await _core.Initialize_With_UniTask(_cancellationToken);
        }

        protected override void Begin_Detail()
        {
            _core.Begin();
        }

        private void OnDestroy()
        {
            Cancel();
        }

        public void Cancel()
        {
            cancellationTokenSource?.Cancel();

            _core.Cancel();

            launcher_transform = null;
        }
    }
}