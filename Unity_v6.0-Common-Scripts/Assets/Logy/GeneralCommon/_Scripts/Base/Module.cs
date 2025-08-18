using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.UnityCommonV01
{
    public abstract class Module : Process
    {
        public Module(string _name) : base(_name) {}

        public abstract UniTask VariableNullHandle(CancellationToken _cancellationToken);
        public abstract void Cancel();
    }
}