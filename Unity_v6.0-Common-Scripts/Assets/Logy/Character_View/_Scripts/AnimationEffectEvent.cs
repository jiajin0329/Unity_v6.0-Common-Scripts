using Cysharp.Threading.Tasks;
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
        private bool _canStepFxPlay = true;
        private float _stepFxCooldown = 0.1f;
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
            if (!_canStepFxPlay) return;

            stepVfxRight.Play();
            stepSfx.Play();
            StepFxCooldown();
        }

        private void StepLeft()
        {
            if (!_canStepFxPlay) return;

            stepVfxLeft.Play();
            stepSfx.Play();
            StepFxCooldown();
        }

        private void StepUp()
        {
            if (!_canStepFxPlay) return;

            stepVfxUp.Play();
            stepSfx.Play();
            StepFxCooldown();
        }

        private void StepDown()
        {
            if (!_canStepFxPlay) return;

            stepVfxDown.Play();
            stepSfx.Play();
            StepFxCooldown();
        }

        private async void StepFxCooldown()
        {
            if (!_canStepFxPlay) return;

            _canStepFxPlay = false;
            await UniTask.Delay((int)(_stepFxCooldown * 1000f), cancellationToken: this.GetCancellationTokenOnDestroy());
            _canStepFxPlay = true;
        }
    }
}