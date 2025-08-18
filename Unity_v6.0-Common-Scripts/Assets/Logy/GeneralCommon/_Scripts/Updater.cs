using UnityEngine.Events;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class Updater
    {
        public string name { get; private set; }
        public CancellationToken cancellationToken  { get; private set; }
        public event UnityAction UpdateAction;
        private bool updating;
        public int delayMs = 16;

        public Updater(string _owner_name, CancellationToken _cancellationToken)
        {
            name = $"{_owner_name} {nameof(Updater)}";
            this.cancellationToken = _cancellationToken;
        }

        public void Initialize()
        {
            UpdateAction = null;
        }

        public void StartUpdate()
        {
            if (updating)
            {
                Debug.LogWarning($"{name} is already running.");
                return;
            }

            Update();
        }

        public void StopUpdate()
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
                UpdateAction?.Invoke();
                await UniTask.Delay(delayMs, cancellationToken : cancellationToken);
                Debug.Log("Update");
            }
        }
    }
}