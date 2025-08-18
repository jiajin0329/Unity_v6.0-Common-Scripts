#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode02MoveModel
    {
        [Test]
        public void _01_CheckInitialize()
        {
            UnitTest02MoveModel.CheckInitialize();
        }
    }
}
#endif