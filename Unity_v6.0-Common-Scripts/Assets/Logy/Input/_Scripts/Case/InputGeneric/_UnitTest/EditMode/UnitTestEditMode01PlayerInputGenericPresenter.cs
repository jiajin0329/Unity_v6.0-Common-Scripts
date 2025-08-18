#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode01PlayerInputGenericPresenter
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest01PlayerInputGenericPresenter.CheckInitialize();
        }

        [Test]
        public void _99_RemoveAllInputActionListener()
        {
            UnitTest01PlayerInputGenericPresenter.RemoveAllInputActionListener();
        }
    }
}
#endif