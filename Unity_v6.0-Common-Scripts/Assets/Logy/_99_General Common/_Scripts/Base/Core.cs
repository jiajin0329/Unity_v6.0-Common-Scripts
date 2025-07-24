using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    public abstract class Core : Process
    {
        public Core(string _name) : base(_name) { }

        public abstract UniTask Reset(CancellationToken _cancellationToken);
        public abstract void Cancel();
    }
}