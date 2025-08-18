#if UNITY_EDITOR
using NUnit.Framework;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    public struct UnitTest02InputModel
    {
        public static InputModel model { get; private set; }

        public static void CheckInitialize()
        {
            model = new();

            model.Initialize();
        }

        public static void CheckVariable()
        {
            Assert.IsFalse(model.inputDown);
            Assert.IsFalse(model.input);
            Assert.IsFalse(model.inputUp);
            Assert.IsTrue(model.inputVector2 == Vector2.zero);
            Assert.IsTrue(model.inputRadian is 0f);
        }
    }
}
#endif