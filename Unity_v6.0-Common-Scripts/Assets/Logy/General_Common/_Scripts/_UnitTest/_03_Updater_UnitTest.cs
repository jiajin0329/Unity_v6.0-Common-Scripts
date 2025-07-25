#if UNITY_EDITOR
using System.Threading;
using NUnit.Framework;

namespace Logy.Unity_Common_v01
{
    public struct _03_Updater_UnitTest
    {
        private static Updater _updater;
        private const string _owner_name = nameof(_03_Updater_UnitTest);
        private static CancellationTokenSource _cancellationTokenSource;

        public static void Check_Initialize()
        {
            _cancellationTokenSource = new();
            _updater = new(_owner_name, _cancellationTokenSource.Token);
            
            Process.Check_Initialize(_updater);
        }

        public static void Check_Variable()
        {
            Assert.AreEqual(_updater.name , $"{_owner_name} {nameof(Updater)}");
            Assert.AreNotEqual(_updater.cancellationToken, new CancellationToken());
        }
    }
}
#endif