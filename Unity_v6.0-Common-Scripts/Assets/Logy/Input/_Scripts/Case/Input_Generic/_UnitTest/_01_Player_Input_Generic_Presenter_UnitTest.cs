#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public struct _01_Player_Input_Generic_Presenter_UnitTest
    {
        private static Player_Input_Generic_Presenter _presenter;

        public async static UniTask Check_Initialize()
        {
            _presenter = new();

            await Process.CheckInitializeWithUniTask(_presenter);
        }
    }
}
#endif