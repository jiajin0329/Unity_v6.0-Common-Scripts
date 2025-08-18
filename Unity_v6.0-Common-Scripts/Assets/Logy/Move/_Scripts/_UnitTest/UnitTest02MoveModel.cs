#if UNITY_EDITOR

namespace Logy.UnityCommonV01
{
    public struct UnitTest02MoveModel
    {
        public static MoveModel model { get; private set; }

        public static void CheckInitialize()
        {
            BuildObject();
            model.Initialize();
        }

        private static void BuildObject()
        {
            model = new();
            model.SetReference(UnitTest02InputModel.model);
        }
    }
}
#endif