#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public struct UnitTest01RigidbodyMove
    {
        private static RigidbodyMove _rigidbodyMove;

        public static async UniTask CheckInitialize()
        {
            BuildObject();
            await Process.CheckInitializeWithUniTask(_rigidbodyMove);
        }

        private static void BuildObject()
        {
            _rigidbodyMove = new();
            _rigidbodyMove.SetReference(UnitTest02InputModel.model);
        }
    }
}
#endif