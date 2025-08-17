using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class PlayerViewTopDownPresenter : Process, IHas_Initialize_With_UniTask
    {
        [field: SerializeField]
        public PlayerViewTopDown playerView { get; private set; } = new();
        private Data _data;
        public struct Data
        {
            public Transform parent;
            public IMove_Model moveModel;
            public IStateMachine_TopDown stateMachine;
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

        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await playerView.InitializeWithUniTask(_cancellationToken);

            AddViewListener();
        }

        private void AddViewListener()
        {
            _data.moveModel.Tick_Action += playerView.Tikc;

            AddStateMachineListener();
        }

        private void AddStateMachineListener()
        {
            for (byte i = 0; i < playerView.views.Length; i++)
            {
                _data.stateMachine.sates[i].OnDown_Action += playerView.views[i].DownView;
                _data.stateMachine.sates[i].OnLeft_Action += playerView.views[i].LeftView;
                _data.stateMachine.sates[i].OnRight_Action += playerView.views[i].RightView;
                _data.stateMachine.sates[i].OnUp_Action += playerView.views[i].UpView;
            }
        }
    }
}