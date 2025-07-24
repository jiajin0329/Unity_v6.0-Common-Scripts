using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Logy.Unity_Common_v01
{
    [Serializable]
    public class Player_View_TopDown : Character_View_TopDown
    {
        protected override string _prefab_name => "hero";
        private Player_View_TopDown_Presenter _presenter = new();
        public struct Data
        {
            public Input_Model input_model;
            public IStateMachine_Model_TopDown stateMachine_model;
        }

        public Player_View_TopDown() : base(nameof(Player_View_TopDown)) {}

        public void Set_Reference(Data _data)
        {
            Player_View_TopDown_Presenter.Data _presenter_data = new()
            {
                player_view_topDown = this,
                input_model = _data.input_model,
                stateMachine_model = _data.stateMachine_model
            };
            _presenter.Set_Reference(_presenter_data);
        }
        
        protected override async UniTask Initialize_Detail_With_UniTask(CancellationToken _cancellationToken)
        {
            await base.Initialize_Detail_With_UniTask(_cancellationToken);

            _presenter.Initialize();
        }
    }
}