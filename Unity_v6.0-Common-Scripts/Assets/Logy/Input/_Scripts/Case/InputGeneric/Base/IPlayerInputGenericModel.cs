namespace Logy.UnityCommonV01
{
    public interface IPlayerInputGenericModel
    {
        public IControllerInputAction controller { get; }
        public IInputModel inputModel { get; }
        public ITouchInputModel touchInputModel { get; }

    }
}