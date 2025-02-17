using System.Collections.Generic;
using System.Threading;
using magic_heroes.Client.UI;
using magic_heroes.Client.View;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using UnityEngine;

namespace magic_heroes.Client.Infrastructure.States
{
    public class EnemyPlayerTurnState : PlayerTurnState
    {
        public const string STATE_NAME = "EnemyPlayerTurnState";
        
        private const string CURRENT_TURN_TEXT = "ENEMY TURN";
        
        private readonly List<SpellView> _spellViews;
        
        private readonly CurrentTurnUIMark _currentTurnUI;
  
        public EnemyPlayerTurnState(Fsm fsm, List<SpellView> spellViews, CurrentTurnUIMark currentTurnUI) : base(fsm)
        {
            Name = STATE_NAME;
            _spellViews = spellViews;
            _currentTurnUI = currentTurnUI;
        }

        public override void Enter()
        {
            base.Enter();
            foreach (var spellView in _spellViews)
            {
                if (spellView.gameObject.activeSelf) spellView.gameObject.SetActive(false);
            }
            _currentTurnUI.SetText(CURRENT_TURN_TEXT);
            Debug.Log($"{fsm.FsmName}: Now is Enemy Player Turn");
            
            //TODO delete when server ai player and EndTurnMessageHandler ready
            fsm.SetState(ClientPlayerTurnState.STATE_NAME);
        }

        public override void Update()
        {
            if (SwitchPlayerStateHit)
            {
                fsm.SetState(ClientPlayerTurnState.STATE_NAME);
                SwitchPlayerStateHit = false;
                return;
            }
        }
    }
}