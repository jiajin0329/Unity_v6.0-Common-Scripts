#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode01RigidbodyMove
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest01RigidbodyMove.CheckInitialize();
        }
    }
}
#endif