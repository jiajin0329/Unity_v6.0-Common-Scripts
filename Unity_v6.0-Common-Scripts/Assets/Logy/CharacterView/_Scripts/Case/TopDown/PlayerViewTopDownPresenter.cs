using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.UnityCommonV01
{
    [Serializable]
    public class PlayerViewTopDownPresenter : Process, IHasInitializeWithUniTask
    {
        [field: SerializeField]
        public PlayerViewTopDown playerView { get; private set; } = new();
        private Data _data;
        public struct Data
        {
            public Transform parent;
            public IMoveModel moveModel;
            public IStateMachineTopDown stateMachine;
        }

        public PlayerViewTopDownPresenter() : base(nameof(PlayerViewTopDownPresenter)) {}

        public async UniTask VariableNullHandle(CancellationToken _cancellationToken)
        {
            await playerView.VariableNullHandle(_cancellationToken);
        }

        public void SetReference(Data _data)
        {
            this._data = _data;

            PlayerViewTopDown.Data player_view_data = new()
            {
                parent = _data.parent,
                move_model = _data.moveModel
            };
            playerView.SetReference(player_view_data);
        }

        protected override async UniTask InitializeDetailWithUniTask(CancellationToken _cancellationToken)
        {
            await playerView.InitializeWithUniTask(_cancellationToken);

            AddViewListener();
        }

        private void AddViewListener()
        {
            _data.moveModel.TickAction += playerView.Tikc;

            AddStateMachineListener();
        }

        private void AddStateMachineListener()
        {
            for (byte i = 0; i < playerView.views.Length; i++)
            {
                _data.stateMachine.sates[i].OnDownAction += playerView.views[i].DownView;
                _data.stateMachine.sates[i].OnLeftAction += playerView.views[i].LeftView;
                _data.stateMachine.sates[i].OnRightAction += playerView.views[i].RightView;
                _data.stateMachine.sates[i].OnUpAction += playerView.views[i].UpView;
            }
        }
    }
}