namespace Logy.UnityCommonV01
{
    public interface IStateMachineTopDown : IStateMachine
    {
        
        public IStateTopDown[] sates { get; }

        public IStateTopDown iStateIdle { get; }
        public IStateTopDown iStateWalk { get; }
    }
}