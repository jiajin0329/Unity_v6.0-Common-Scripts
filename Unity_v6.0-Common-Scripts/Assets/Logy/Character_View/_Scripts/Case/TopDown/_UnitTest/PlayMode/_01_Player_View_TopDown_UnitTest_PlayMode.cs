#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _01_Player_View_TopDown_Presenter_UnitTest_PlayMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await Player_View_TopDown_Presenter_UnitTest.Check_Initialize();
        }
    }
}
#endif