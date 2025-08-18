#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestPlayMode01ControllerInputAction
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest01ControllerInputAction.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest01ControllerInputAction.CheckVariable();
        }
        
        [Test]
        public void _99_RemoveAllInputActionListener()
        {
            UnitTest01ControllerInputAction.RemoveAllInputActionListener();
        }
    }
}
#endif