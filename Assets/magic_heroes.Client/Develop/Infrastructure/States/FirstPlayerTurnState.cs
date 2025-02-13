using System.Collections.Generic;
using magic_heroes.Client.UI;
using magic_heroes.Client.View;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using UnityEngine;

namespace magic_heroes.Client.Infrastructure.States
{
    public class FirstPlayerTurnState : PlayerTurnState
    {
        public const string STATE_NAME = "FirstPlayerTurnState";
        
        private const string CURRENT_TURN_TEXT = "FIRST PLAYER TURN";

        private readonly List<SpellView> _spellViews;

        private readonly CurrentTurnUIMark _currentTurnUI;
        
        public FirstPlayerTurnState(Fsm fsm, List<SpellView> spellViews, CurrentTurnUIMark currentTurnUI) : base(fsm)
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
            Debug.Log($"{fsm.FsmName}: Now is First Player Turn");
        }

        public override void Update()
        {
            if (SwitchPlayerStateHit)
            {
                fsm.SetState(SecondPlayerTurnState.STATE_NAME);
                SwitchPlayerStateHit = false;
                return;
            }
            
            
        }
    }
}