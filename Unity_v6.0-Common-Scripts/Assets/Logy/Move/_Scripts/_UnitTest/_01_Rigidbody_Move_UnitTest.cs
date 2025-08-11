#if UNITY_EDITOR
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    public struct _01_Rigidbody_Move_UnitTest
    {
        private static Rigidbody_Move _rigidbody_move;

        public static async UniTask Check_Initialize()
        {
            Build_Object();

            await Process.Check_Initialize_With_UniTask(_rigidbody_move);
        }

        private static void Build_Object()
        {
            _rigidbody_move = new();

            _rigidbody_move.Set_Reference(_02_Input_Model_UnitTest.model);
        }
    }
}
#endif