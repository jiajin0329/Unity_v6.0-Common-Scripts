namespace Logy.Unity_Common_v01
{
    public struct Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            UnityEngine.Debug.Log(message);
#endif
        }

        public static void LogWarning(string message)
        {
#if DEBUG
            UnityEngine.Debug.LogWarning(message);
#endif
        }

        public static void LogError(string message)
        {
#if DEBUG
            UnityEngine.Debug.LogError(message);
#endif
        }
    }
}