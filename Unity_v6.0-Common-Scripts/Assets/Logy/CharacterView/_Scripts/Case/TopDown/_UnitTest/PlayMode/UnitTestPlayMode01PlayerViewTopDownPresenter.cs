#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class UnitTestPlayMode01PlayerViewTopDownPresenter
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest01PlayerViewTopDownPresenter.CheckInitialize();
        }
    }
}
#endif