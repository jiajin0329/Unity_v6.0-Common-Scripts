using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class PlayerViewTopDown
    {
        [SerializeField]
        private Animator _animator;
        protected virtual string _prefabName { get; } = "hero";
        private Data _data;
        public CharacterViewTopDown[] views = new CharacterViewTopDown[StateMachineTopDown.Index.amount]
        {
            new(),
            new()
        };
        public CharacterViewTopDown idleView => views[StateMachineTopDown.Index.idle];
        public CharacterViewTopDown walkView => views[StateMachineTopDown.Index.walk];

        public bool isAnimatorNotNull => _animator != null;

        public struct Data
        {
            public Transform parent;
            public IMoveModel move_model;
        }

        public void SetReference(Data _data) { this._data = _data; }

        public async UniTask InitializeWithUniTask(CancellationToken _cancellationToken)
        {
            await VariableNullHandle(_cancellationToken);

            _animator = UnityEngine.Object.Instantiate(_animator, _data.parent);

            ViewsInitialize();

            AddViewListener();
        }

        public async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            if (Is.VariableNull(_animator, nameof(_animator)))
            {
                GameObject _load = await UniTaskEX.AddressablesLoadAssetAsync<GameObject>(_prefabName, _cancellationToken);
                _animator = _load.GetComponent<Animator>();
            }
        }

        private void ViewsInitialize()
        {
            for (byte i = 0; i < views.Length; i++)
            {
                views[i].Initialize();
            }
        }

        private void AddViewListener()
        {
            idleView.DownViewAction += IdleDownView;
            idleView.LeftViewAction += IdleLeftView;
            idleView.RightViewAction += IdleRightView;
            idleView.UpViewAction += IdleUpView;

            walkView.DownViewAction += WalkDownView;
            walkView.LeftViewAction += WalkLeftView;
            walkView.RightViewAction += WalkRightView;
            walkView.UpViewAction += WalkUpView;
        }

        private void IdleDownView()
        {
            SwitchAnimation("idle-down");
        }

        private void SwitchAnimation(string name)
        {
            _animator.Play(name, 0, GetNormalizedTime());
        }

        private float GetNormalizedTime()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }

        private void IdleLeftView()
        {
            SwitchAnimation("idle-left");
        }

        private void IdleRightView()
        {
            SwitchAnimation("idle-right");
        }

        private void IdleUpView()
        {
            SwitchAnimation("idle-up");
        }

        private void WalkDownView()
        {
            SwitchAnimation("walk-down");
        }

        private void WalkLeftView()
        {
            SwitchAnimation("walk-left");
        }

        private void WalkRightView()
        {
            SwitchAnimation("walk-right");
        }

        private void WalkUpView()
        {
            SwitchAnimation("walk-up");
        }

        public void Tikc()
        {
            UpdateAnimatorSpeed();
        }

        private void UpdateAnimatorSpeed()
        {
            switch (_data.move_model.speedRatio)
            {
                case > 0.98f:
                    _animator.speed = 1f;
                    break;
                case 0f:
                    _animator.speed = 1f;
                    break;
                default:
                    _animator.speed = _data.move_model.speedRatio;
                    break;
            }
        }
    }
}