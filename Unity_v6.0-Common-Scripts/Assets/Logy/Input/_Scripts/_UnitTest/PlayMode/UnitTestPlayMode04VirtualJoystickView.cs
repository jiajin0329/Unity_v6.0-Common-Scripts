#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestPlayMode04VirtualJoystickView
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest04VirtualJoystickView.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest04VirtualJoystickView.CheckVariable();
        }
    }
}
#endif