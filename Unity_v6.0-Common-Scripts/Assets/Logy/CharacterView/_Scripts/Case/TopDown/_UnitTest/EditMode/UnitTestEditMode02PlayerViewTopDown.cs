#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode02PlayerViewTopDown
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest02PlayerViewTopDown.CheckInitialize();
        }
    }
}
#endif