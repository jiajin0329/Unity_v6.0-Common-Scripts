#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _02_StateMachine_Model_TopDown_UnitTest
    {
        public static StateMachine_Model_TopDown model { get; private set; }

        public static void Check_Initialize()
        {
            model = Factory_StateMachine_Model_TopDown.New(Factory_StateMachine_Model_TopDown.Type.player);

            model.Initialize();
        }

        public static void Check_Begin()
        {
            model.Begin();
        }

        public static void Check_Variable()
        {
            Assert.AreEqual(model.state_idle_down.name, nameof(StateMachine_Model_TopDown.Index.idle_down));
            Assert.AreEqual(model.state_idle_left.name, nameof(StateMachine_Model_TopDown.Index.idle_left));
            Assert.AreEqual(model.state_idle_right.name, nameof(StateMachine_Model_TopDown.Index.idle_right));
            Assert.AreEqual(model.state_idle_up.name, nameof(StateMachine_Model_TopDown.Index.idle_up));
            Assert.AreEqual(model.state_walk_down.name, nameof(StateMachine_Model_TopDown.Index.walk_down));
            Assert.AreEqual(model.state_walk_left.name, nameof(StateMachine_Model_TopDown.Index.walk_left));
            Assert.AreEqual(model.state_walk_right.name, nameof(StateMachine_Model_TopDown.Index.walk_right));
            Assert.AreEqual(model.state_walk_up.name, nameof(StateMachine_Model_TopDown.Index.walk_up));
        }
    }
}
#endif