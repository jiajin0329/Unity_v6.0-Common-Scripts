using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    public class AnimationFxEvent : MonoBehaviour
    {
        [SerializeField]
        private FootStepFx footStepFx;
        public enum FxType
        {
            footStepDown,
            footStepLeft,
            footStepRight,
            footStepUp
        }

        private void Awake()
        {
            footStepFx.cancellationToken = this.GetCancellationTokenOnDestroy();
        }

        private void Play(FxType _fxType)
        {
            if (footStepFx.Play(_fxType)) return;
        }
    }
}