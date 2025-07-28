using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_View_TopDown
    {
        [SerializeField] private GameObject _prefab;
        protected virtual string _prefab_name { get; } = "hero";
        protected Animator _animator;

        public Character_View_TopDown[] views = new Character_View_TopDown[StateMachine_TopDown.Index.amount]
        {
            new(),
            new()
        };
        public Character_View_TopDown idle_view => views[StateMachine_TopDown.Index.idle];
        public Character_View_TopDown walk_view => views[StateMachine_TopDown.Index.walk];

        public bool is_prefab_is_notNull => _prefab != null;
        public bool is_animator_is_notNull => _animator != null;

        public async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);

            GameObject player = UnityEngine.Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);

            _animator = player.GetComponent<Animator>();

            views_Initialize();

            Add_View_Listener();
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.Variable_Null(_prefab, nameof(_prefab)))
            {
                _prefab = await UniTaskEX.Addressables_LoadAssetAsync<GameObject>(_prefab_name, _cancellationToken);
            }
        }

        private void views_Initialize()
        {
            for (byte i = 0; i < views.Length; i++)
            {
                views[i].Initialize();
            }
        }

        private void Add_View_Listener()
        {
            idle_view.Down_View_Action += Idle_Down_View;
            idle_view.Left_View_Action += Idle_Left_View;
            idle_view.Right_View_Action += Idle_Right_View;
            idle_view.Up_View_Action += Idle_Up_View;

            walk_view.Down_View_Action += Walk_Down_View;
            walk_view.Left_View_Action += Walk_Left_View;
            walk_view.Right_View_Action += Walk_Right_View;
            walk_view.Up_View_Action += Walk_Up_View;
        }

        private void Idle_Down_View()
        {
            _animator.Play("idle-down");
        }

        private void Idle_Left_View()
        {
            _animator.Play("idle-left");
        }

        private void Idle_Right_View()
        {
            _animator.Play("idle-right");
        }

        private void Idle_Up_View()
        {
            _animator.Play("idle-up");
        }

        private void Walk_Down_View()
        {
            _animator.Play("walk-down");
        }

        private void Walk_Left_View()
        {
            _animator.Play("walk-left");
        }

        private void Walk_Right_View()
        {
            _animator.Play("walk-right");
        }

        private void Walk_Up_View()
        {
            _animator.Play("walk-up");
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
    }
}