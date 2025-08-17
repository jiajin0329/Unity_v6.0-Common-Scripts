#if UNITY_EDITOR
namespace Logy.UnityCommonV01
{
    public struct _01_StateMachine_UnitTest
    {
        public static StateMachine stateMachine { get; private set; }

        public static void Check_Initialize()
        {
            stateMachine = new();

            stateMachine.Initialize();
        }
    }
}
#endif