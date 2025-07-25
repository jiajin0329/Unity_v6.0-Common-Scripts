using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public abstract class Character_View_TopDown : Process
    {
        [SerializeField] private GameObject _prefab;
        protected abstract string _prefab_name { get; }
        private Animator _animator;

        public event UnityAction Idle_Down_View_Action;
        public event UnityAction Idle_Left_View_Action;
        public event UnityAction Idle_Right_View_Action;
        public event UnityAction Idle_Up_View_Action;
        public event UnityAction Walk_Down_View_Action;
        public event UnityAction Walk_Left_View_Action;
        public event UnityAction Walk_Right_View_Action;
        public event UnityAction Walk_Up_View_Action;

        public bool is_prefab_is_notNull => _prefab != null;
        public bool is_animator_is_notNull => _animator != null;

        public Character_View_TopDown(String _name) : base(_name) {}

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);

            GameObject player = UnityEngine.Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);

            _animator = player.GetComponent<Animator>();
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.Variable_Null(_prefab, nameof(_prefab)))
            {
                _prefab = await UniTaskEX.Addressables_LoadAssetAsync<GameObject>(_prefab_name, _cancellationToken);
            }
        }

        public void Update_Animator_Speed(float _input_distance)
        {
            if (_input_distance > 0.98f)
            {
                _animator.speed = 1f;
                return;
            }

            if (_input_distance == 0f)
            {
                _animator.speed = 1f;
                return;
            }

            _animator.speed = _input_distance;
        }

        public virtual void Idle_Down_View()
        {
            _animator.Play("idle-down");

            Idle_Down_View_Action?.Invoke();
        }

        public virtual void Idle_Left_View()
        {
            _animator.Play("idle-left");

            Idle_Left_View_Action?.Invoke();
        }

        public virtual void Idle_Right_View()
        {
            _animator.Play("idle-right");

            Idle_Right_View_Action?.Invoke();
        }

        public virtual void Idle_Up_View()
        {
            _animator.Play("idle-up");

            Idle_Up_View_Action?.Invoke();
        }

        public virtual void Walk_Down_View()
        {
            _animator.Play("walk-down");

            Walk_Down_View_Action?.Invoke();
        }

        public virtual void Walk_Left_View()
        {
            _animator.Play("walk-left");

            Walk_Left_View_Action?.Invoke();
        }

        public virtual void Walk_Right_View()
        {
            _animator.Play("walk-right");

            Walk_Right_View_Action?.Invoke();
        }

        public virtual void Walk_Up_View()
        {
            _animator.Play("walk-up");

            Walk_Up_View_Action?.Invoke();
        }
    }
}