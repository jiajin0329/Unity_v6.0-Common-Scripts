#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public struct _01_Launcher_Input_Generic_TopDown_UnitTest
    {
        private static Launcher_Input_Generic_TopDown _launcher;

        public static async UniTask Check_Initialize_EditMode()
        {
            await Instantiate_Launcher_TopDown_Input_Generic();

            await Process_With_MonoBehaviour.Check_Initialize_With_UniTask(_launcher);
        }

        public static async UniTask Check_Initialize_PlayMode()
        {
            await Instantiate_Launcher_TopDown_Input_Generic();

            await UniTaskEX.WaitUntil(() => _launcher.is_initialized, _launcher.cancellationTokenSource.Token);
        }

        private static async UniTask Instantiate_Launcher_TopDown_Input_Generic()
        {
            CancellationTokenSource _cancellationTokenSource = new();

            GameObject _prefab = await UniTaskEX.Addressables_LoadAssetAsync<GameObject>("Launcher Input Generic TopDown", _cancellationTokenSource.Token);

            _cancellationTokenSource.Cancel();

            _launcher = GameObject.Instantiate(_prefab).GetComponent<Launcher_Input_Generic_TopDown>();

            Debug.Log(nameof(Instantiate_Launcher_TopDown_Input_Generic));
        }

        public static void Check_Begin_EditMode()
        {
            Process_With_MonoBehaviour.Check_Begin(_launcher);
        }

        public static async UniTask Check_Begin_PlayMode()
        {
            await UniTaskEX.WaitUntil(() => _launcher.is_finish, _launcher.cancellationTokenSource.Token);
        }

        public static void Cancel()
        {
            _launcher.Cancel();
        }
    }
}
#endif