#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode03ControllerInputActionGeneric
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest03ControllerInputActionGeneric.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest03ControllerInputActionGeneric.CheckVariable();
        }
        
        [Test]
        public void _99_RemoveAllInputActionListener()
        {
            UnitTest03ControllerInputActionGeneric.RemoveAllInputActionListener();
        }
    }
}
#endif