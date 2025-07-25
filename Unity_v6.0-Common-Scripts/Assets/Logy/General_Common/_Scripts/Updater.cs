using UnityEngine.Events;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Updater : Process
    {
        public string name { get; private set; }
        public CancellationToken cancellationToken  { get; private set; }
        public event UnityAction Update_Action;
        private bool updating;
        public int delay_ms = 16;

        public Updater(string _owner_name, CancellationToken _cancellationToken) : base($"{_owner_name} {nameof(Updater)}")
        {
            name = $"{_owner_name} {nameof(Updater)}";
            this.cancellationToken = _cancellationToken;
        }

        protected override void Initialize_Detail()
        {
            Update_Action = null;
        }

        public void Start_Update()
        {
            if (updating)
            {
                Debug.LogWarning($"{name} is already running.");
                return;
            }

            Update();
        }

        public void Stop_Update()
        {
            if (!updating)
            {
                Debug.LogWarning($"{name} is not running.");
                return;
            }

            updating = false;

            Debug.Log($"{nameof(Updater)} stopped.");
        }

        private async void Update()
        {
            if (updating)
            {
                Debug.LogWarning($"{name} is already updating.");
                return;
            }

            updating = true;
            
            while (updating)
            {
                Update_Action?.Invoke();
                await UniTask.Delay(delay_ms, cancellationToken : cancellationToken);
                Debug.Log("Update");
            }
        }
    }
}