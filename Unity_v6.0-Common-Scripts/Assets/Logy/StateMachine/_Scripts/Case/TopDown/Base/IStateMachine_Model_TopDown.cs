namespace Logy.Unity_Common_v01
{
    public interface IStateMachine_Model_TopDown : IStateMachine_Model
    {
        public IState state_idle_down { get; }
        public IState state_idle_left { get; }
        public IState state_idle_right { get; }
        public IState state_idle_up { get; }
        public IState state_walk_down { get; }
        public IState state_walk_left { get; }
        public IState state_walk_right { get; }
        public IState state_walk_up { get; }
    }
}