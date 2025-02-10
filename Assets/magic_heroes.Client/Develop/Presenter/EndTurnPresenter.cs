using System.Collections.Generic;
using magic_heroes.Client.Dto;
using magic_heroes.Client.Infrastructure.States;
using magic_heroes.GlobalUtils;
using magic_heroes.GlobalUtils.ClientConnection;
using magic_heroes.GlobalUtils.HttpApi;
using UnityEngine;

namespace magic_heroes.Client.Presenter
{
    public class EndTurnPresenter
    {
        private const string MessageHandlerName = "EndTurn";

        public void SendEndTurnRequest(int spellOrder, UserDto user, long BattleInGameId)
        {
            var fields = new Dictionary<string, string>
            {
                { HttpAttributeNames.SPELL_ORDER, spellOrder.ToString() },
                { HttpAttributeNames.USER, JsonUtility.ToJson(user) },
                { HttpAttributeNames.BATTLE_INGAME_ID, BattleInGameId.ToString() }
            };

            var request = new Request()
            {
                name = MessageHandlerName,
                fields = fields
            };
            
            var response = ClientServerAdapter.Instance.SendRequest(request);
            Debug.Log($"Response came back, status = {response.status}, Fields = {response.fields.ToDebugString()}");
            
            if (response.status == 200)
            {
                PlayerTurnState.SwitchPlayerStateHit = true;
            }
        }
    }
}