using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_View_TopDown
    {
        [SerializeField]
        private Animator _animator;
        protected virtual string _prefab_name { get; } = "hero";
        private Data _data;
        public Character_View_TopDown[] views = new Character_View_TopDown[StateMachine_TopDown.Index.amount]
        {
            new(),
            new()
        };
        public Character_View_TopDown idle_view => views[StateMachine_TopDown.Index.idle];
        public Character_View_TopDown walk_view => views[StateMachine_TopDown.Index.walk];

        public bool is_animator_is_notNull => _animator != null;

        public struct Data
        {
            public Transform parent;
            public IMove_Model move_model;
        }

        public void Set_Reference(Data _data) { this._data = _data; }

        public async UniTask Initialize_With_UniTask(CancellationToken _cancellationToken)
        {
            await Variable_Null_Handle(_cancellationToken);

            _animator = UnityEngine.Object.Instantiate(_animator, _data.parent);

            views_Initialize();

            Add_View_Listener();
        }

        public async UniTask Variable_Null_Handle(CancellationToken _cancellationToken)
        {
            if (Is.Variable_Null(_animator, nameof(_animator)))
            {
                GameObject _load = await UniTaskEX.Addressables_LoadAssetAsync<GameObject>(_prefab_name, _cancellationToken);
                _animator = _load.GetComponent<Animator>();
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

        public void Update_Animator_Speed()
        {
            if (_data.move_model.speed_ratio > 0.98f)
            {
                _animator.speed = 1f;
                return;
            }

            if (_data.move_model.speed_ratio == 0f)
            {
                _animator.speed = 1f;
                return;
            }

            _animator.speed = _data.move_model.speed_ratio;
        }
    }
}