#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public struct UnitTest01PlayerViewTopDownPresenter
    {
        private static PlayerViewTopDownPresenter _viewPresenter;

        public static async UniTask CheckInitialize()
        {
            BuildObject();

            await Process.CheckInitializeWithUniTask(_viewPresenter);
        }

        private static void BuildObject()
        {
            _viewPresenter = new();

            PlayerViewTopDownPresenter.Data _data = new()
            {
                moveModel = UnitTest02MoveModel.model,
                stateMachine = UnitTest02StateMachineTopDown.stateMachine,
            };

            _viewPresenter.SetReference(_data);
        }
    }
}
#endif