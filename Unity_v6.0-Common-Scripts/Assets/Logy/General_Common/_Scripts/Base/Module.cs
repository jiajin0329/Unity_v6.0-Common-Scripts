using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    public abstract class Module : Process
    {
        public Module(string _name) : base(_name) {}

        public abstract UniTask Variable_Null_Handle(CancellationToken _cancellationToken);
        public abstract void Cancel();
    }
}