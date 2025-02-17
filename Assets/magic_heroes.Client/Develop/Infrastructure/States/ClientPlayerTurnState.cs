using System.Collections.Generic;
using magic_heroes.Client.UI;
using magic_heroes.Client.View;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using UnityEngine;

namespace magic_heroes.Client.Infrastructure.States
{
    public class ClientPlayerTurnState : PlayerTurnState
    {
        public const string STATE_NAME = "ClientPlayerTurnState";
        
        private const string CURRENT_TURN_TEXT = "YOUR TURN";

        private readonly List<SpellView> _spellViews;

        private readonly CurrentTurnUIMark _currentTurnUI;
        
        public ClientPlayerTurnState(Fsm fsm, List<SpellView> spellViews, CurrentTurnUIMark currentTurnUI) : base(fsm)
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
                if (!spellView.gameObject.activeSelf) spellView.gameObject.SetActive(true);
            }
            _currentTurnUI.SetText(CURRENT_TURN_TEXT);
            Debug.Log($"{fsm.FsmName}: Now is Client Player Turn");
        }

        public override void Update()
        {
            if (SwitchPlayerStateHit)
            {
                fsm.SetState(EnemyPlayerTurnState.STATE_NAME);
                SwitchPlayerStateHit = false;
                return;
            }
            
            
        }
    }
}