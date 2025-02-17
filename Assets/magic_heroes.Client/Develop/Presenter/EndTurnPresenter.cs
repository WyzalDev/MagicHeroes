using System.Collections.Generic;
using magic_heroes.Client.Dto;
using magic_heroes.Client.Infrastructure.States;
using magic_heroes.GlobalUtils;
using magic_heroes.GlobalUtils.GlobalConnection;
using magic_heroes.GlobalUtils.HttpApi;
using UnityEngine;

namespace magic_heroes.Client.Presenter
{
    public class EndTurnPresenter
    {
        public void SendEndTurnRequest(int spellOrder, UserDto user, long battleInGameId)
        {
            var fields = new Dictionary<string, string>
            {
                { HttpAttributeNames.SPELL_ORDER, spellOrder.ToString() },
                { HttpAttributeNames.USER, JsonUtility.ToJson(user) },
                { HttpAttributeNames.BATTLE_INGAME_ID, battleInGameId.ToString() }
            };

            var request = new Request()
            {
                msgHandlerName = MessageHandlerNames.EndTurnMessageHandler,
                fields = fields
            };
            
            var response = ClientServerAdapter.Instance.SendRequest(request);
            Debug.Log($"Response came back from {MessageHandlerNames.EndTurnMessageHandler}, status = {response.status}, Fields = {response.fields.ToDebugString()}");
            
            if (response.status == 200)
            {
                PlayerTurnState.SwitchPlayerStateHit = true;
            }
        }
    }
}