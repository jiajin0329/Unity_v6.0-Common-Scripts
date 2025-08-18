#if UNITY_EDITOR
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public class UnitTestEditMode03StateMachineVariableViewer
    {
        [Test]
        public async Task _01_CheckInitialize()
        {
            await UnitTest03StateMachineVariableViewer.CheckInitialize();
        }

        [Test]
        public void _02_CheckVariable()
        {
            UnitTest03StateMachineVariableViewer.CheckVariable();
        }
    }
}
#endif