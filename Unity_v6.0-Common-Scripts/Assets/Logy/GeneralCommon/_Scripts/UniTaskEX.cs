using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Logy.UnityCommonV01
{
    public struct UniTaskEX
    {
        public static async UniTask WaitUntil(Func<bool> condition, CancellationToken _cancellationToken, int pollInterval = 16)
        {
            while (!condition())
            {
                Debug.Log(nameof(WaitUntil));

                if (pollInterval == 0) continue;

                await UniTask.Delay(pollInterval, cancellationToken: _cancellationToken);
            }
        }

        public static async UniTask<T> AddressablesLoadAssetAsync<T>(string _fileName, CancellationToken _cancellationToken)
        {
            AsyncOperationHandle<T> _handle = Addressables.LoadAssetAsync<T>(_fileName);
            await _handle.ToUniTask(cancellationToken: _cancellationToken);

            return _handle.Result;
        }
    }
}