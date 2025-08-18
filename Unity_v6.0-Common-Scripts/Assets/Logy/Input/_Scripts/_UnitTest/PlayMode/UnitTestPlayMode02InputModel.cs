#if UNITY_EDITOR
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestPlayMode02InputModel
    {
        [Test]
        public void _01_CheckInitialize()
        {            
            UnitTest02InputModel.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest02InputModel.CheckVariable();
        }
    }
}
#endif