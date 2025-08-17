using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class FootStepFx
    {
        [SerializeField]
        private ParticleSystem footStepVfxDown;
        [SerializeField]
        private ParticleSystem footStepVfxLeft;
        [SerializeField]
        private ParticleSystem footStepVfxRight;
        [SerializeField]
        private ParticleSystem footStepVfxUp;
        [SerializeField]
        private AudioSource footStepSfx;
        private bool _canfootStepFxPlay = true;
        private float _footStepFxCooldown = 0.1f;
        public CancellationToken cancellationToken;

        public bool Play(AnimationFxEvent.FxType _fxType)
        {
            switch (_fxType)
            {
                case AnimationFxEvent.FxType.footStepDown:
                    StepDown();
                    return true;
                case AnimationFxEvent.FxType.footStepLeft:
                    StepLeft();
                    return true;
                case AnimationFxEvent.FxType.footStepRight:
                    StepRight();
                    return true;
                case AnimationFxEvent.FxType.footStepUp:
                    StepUp();
                    return true;
                default:
                    return false;
            }
        }

        private void StepRight()
        {
            if (!_canfootStepFxPlay) return;

            footStepVfxRight.Play();
            footStepSfx.Play();
            StepFxCooldown();
        }

        private void StepLeft()
        {
            if (!_canfootStepFxPlay) return;

            footStepVfxLeft.Play();
            footStepSfx.Play();
            StepFxCooldown();
        }

        private void StepUp()
        {
            if (!_canfootStepFxPlay) return;

            footStepVfxUp.Play();
            footStepSfx.Play();
            StepFxCooldown();
        }

        private void StepDown()
        {
            if (!_canfootStepFxPlay) return;

            footStepVfxDown.Play();
            footStepSfx.Play();
            StepFxCooldown();
        }

        private async void StepFxCooldown()
        {
            if (!_canfootStepFxPlay) return;

            _canfootStepFxPlay = false;
            await UniTask.Delay((int)(_footStepFxCooldown * 1000f), cancellationToken: cancellationToken);
            _canfootStepFxPlay = true;
        }
    }
}