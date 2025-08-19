using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    public class AnimationFxEvent : MonoBehaviour
    {
        [SerializeField]
        private FootstepFxs footstepFx;
        public enum FxType
        {
            footstepDown,
            footstepLeft,
            footstepRight,
            footstepUp
        }

        private void Awake()
        {
            footstepFx.cancellationToken = this.GetCancellationTokenOnDestroy();
        }

        private void Play(FxType _fxType)
        {
            if (footstepFx.Play(_fxType)) return;
        }
    }
}