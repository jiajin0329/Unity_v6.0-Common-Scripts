#if UNITY_EDITOR
using System.Threading;
using NUnit.Framework;

namespace Logy.UnityCommonV01
{
    public struct UnitTest03Updater
    {
        private static Updater _updater;
        private const string _ownerName = nameof(UnitTest03Updater);
        private static CancellationTokenSource _cancellationTokenSource;

        public static void CheckInitialize()
        {
            _cancellationTokenSource = new();
            _updater = new(_ownerName, _cancellationTokenSource.Token);

            _updater.Initialize();
        }

        public static void CheckVariable()
        {
            Assert.AreEqual(_updater.name , $"{_ownerName} {nameof(Updater)}");
            Assert.AreNotEqual(_updater.cancellationToken, new CancellationToken());
        }
    }
}
#endif