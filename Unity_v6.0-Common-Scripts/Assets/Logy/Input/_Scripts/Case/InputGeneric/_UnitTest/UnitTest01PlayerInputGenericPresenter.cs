#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public struct UnitTest01PlayerInputGenericPresenter
    {
        private static PlayerInputGenericPresenter _presenter;

        public async static UniTask CheckInitialize()
        {
            _presenter = new();

            await Process.CheckInitializeWithUniTask(_presenter);
        }

        public static void RemoveAllInputActionListener()
        {
            _presenter.model.controller.RemoveAllInputActionListener();
        }
    }
}
#endif