#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestPlayMode02InputGenericModel
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest02InputGenericModel.CheckInitialize();
        }

        [Test]
        public void _99_RemoveAllInputActionListener()
        {
            UnitTest02InputGenericModel.RemoveAllInputActionListener();
        }
    }
}
#endif