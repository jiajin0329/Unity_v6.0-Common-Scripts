#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class _01_Rigidbody_Move_UnitTest_EditMode
    {
        [Test]
        public async Task _01_Check_Initialize()
        {
            await _01_Rigidbody_Move_UnitTest.Check_Initialize();
        }
    }
}
#endif