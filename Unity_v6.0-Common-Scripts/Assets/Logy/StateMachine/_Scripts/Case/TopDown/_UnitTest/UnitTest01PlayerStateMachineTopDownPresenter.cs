#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public struct UnitTest01PlayerStateMachineTopDownPresenter
    {
        private static PlayerStateMachineTopDownPresenter _presenter;

        public static async UniTask CheckInitialize()
        {
            _presenter = new();
            _presenter.SetReference(UnitTest02MoveModel.model);
            
            await Process.CheckInitializeWithUniTask(_presenter);
        }
    }
}
#endif