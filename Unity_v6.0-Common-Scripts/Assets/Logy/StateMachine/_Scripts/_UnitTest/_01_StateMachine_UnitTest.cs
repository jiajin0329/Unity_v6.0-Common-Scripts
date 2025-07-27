#if UNITY_EDITOR
namespace Logy.Unity_Common_v01
{
    public struct _01_StateMachine_UnitTest
    {
        public static StateMachine_Model stateMachine { get; private set; }

        public static void Check_Initialize()
        {
            stateMachine = new();

            stateMachine.Initialize();
        }
    }
}
#endif