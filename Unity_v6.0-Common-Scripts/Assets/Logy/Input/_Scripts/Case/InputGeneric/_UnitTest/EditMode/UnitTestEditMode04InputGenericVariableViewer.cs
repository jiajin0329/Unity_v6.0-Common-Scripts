#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode04InputGenericVariableViewer
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest04InputGenericVariableViewer.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest04InputGenericVariableViewer.CheckVariable();
        }
    }
}
#endif