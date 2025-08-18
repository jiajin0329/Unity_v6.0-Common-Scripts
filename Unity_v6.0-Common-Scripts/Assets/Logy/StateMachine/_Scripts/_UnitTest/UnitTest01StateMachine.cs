#if UNITY_EDITOR
namespace Logy.UnityCommonV01
{
    public struct UnitTest01StateMachine
    {
        public static StateMachine stateMachine { get; private set; }

        public static void CheckInitialize()
        {
            stateMachine = new();
            stateMachine.Initialize();
        }
    }
}
#endif