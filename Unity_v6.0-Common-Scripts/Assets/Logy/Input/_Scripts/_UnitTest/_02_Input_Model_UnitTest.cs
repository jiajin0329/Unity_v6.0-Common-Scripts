#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public struct _02_Input_Model_UnitTest
    {
        public static Input_Model model { get; private set; }

        public static void Check_Initialize()
        {
            model = new();

            model.Initialize();
        }

        public static void Check_Begin()
        {
            model.Begin();
        }

        public static void Check_Variable()
        {
            Assert.IsFalse(model.inputDown);
            Assert.IsFalse(model.input);
            Assert.IsFalse(model.inputUp);
            Assert.IsTrue(model.input_vector2 == Vector2.zero);
            Assert.IsTrue(model.input_distance is 0f);
            Assert.IsTrue(model.input_radian is 0f);
        }
    }
}
#endif