using UnityEngine;

namespace Logy.Unity_Common_v01
{
    public class AnimationEffectEvent : MonoBehaviour
    {
        [Header("Step FX")]
        [SerializeField]
        private ParticleSystem stepVfxDown;
        [SerializeField]
        private ParticleSystem stepVfxLeft;
        [SerializeField]
        private ParticleSystem stepVfxRight;
        [SerializeField]
        private ParticleSystem stepVfxUp;
        [SerializeField]
        private AudioSource stepSfx;
        private enum FxType
        {
            stepDown,
            stepLeft,
            stepRight,
            stepUp
        }

        private void Play(FxType _fxType)
        {
            switch (_fxType)
            {
                case FxType.stepDown:
                    StepDown();
                    break;
                case FxType.stepLeft:
                    StepLeft();
                    break;
                case FxType.stepRight:
                    StepRight();
                    break;
                case FxType.stepUp:
                    StepUp();
                    break;
            }
        }

        private void StepRight()
        {
            stepVfxRight.Play();
            stepSfx.Play();
        }

        private void StepLeft()
        {
            stepVfxLeft.Play();
            stepSfx.Play();
        }

        private void StepUp()
        {
            stepVfxUp.Play();
            stepSfx.Play();
        }

        private void StepDown()
        {
            stepVfxDown.Play();
            stepSfx.Play();
        }
    }
}