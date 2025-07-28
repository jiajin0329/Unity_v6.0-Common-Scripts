#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public class _02_Player_View_TopDown_UnitTest_EditMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _02_Player_View_TopDown_UnitTest.Check_Initialize();
        }
    }
}
#endif