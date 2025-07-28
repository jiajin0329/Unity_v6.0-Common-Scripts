namespace Logy.Unity_Common_v01
{
    public interface IStateMachine_TopDown : IStateMachine
    {
        
        public IState_TopDown[] sates { get; }

        public IState_TopDown iState_idle { get; }
        public IState_TopDown iState_walk { get; }
    }
}