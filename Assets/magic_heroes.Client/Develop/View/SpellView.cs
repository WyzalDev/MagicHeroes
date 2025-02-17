using magic_heroes.Client.Presenter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace magic_heroes.Client.View
{
    public class SpellView : MonoBehaviour, IPointerClickHandler
    {
        public int order { get; set; }
        
        private Sprite _icon;
        
        public Sprite sprite
        {
            get => _icon;
            set
            {
                _icon = value;
                GetComponentInChildren<Image>().sprite = value;
            }
        }
        
        private EndTurnPresenter _endTurnPresenter;
        
        private ClientInfo _clientInfo;
        
        [Inject]
        public void Construct(EndTurnPresenter endTurnPresenter, ClientInfo clientInfo)
        {
            _endTurnPresenter = endTurnPresenter;
            _clientInfo = clientInfo;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _endTurnPresenter.SendEndTurnRequest(order, _clientInfo.user, _clientInfo.battleInGameId);
            Debug.Log("Spell Button Clicked");
        }
    }
}