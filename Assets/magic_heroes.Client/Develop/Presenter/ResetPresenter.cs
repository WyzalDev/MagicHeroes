using System.Collections.Generic;
using magic_heroes.Client.UI;
using magic_heroes.GlobalUtils;
using magic_heroes.GlobalUtils.GlobalConnection;
using magic_heroes.GlobalUtils.HttpApi;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils.States;
using UnityEngine;

namespace magic_heroes.Client.Presenter
{
    public class ResetPresenter
    {
        private readonly Dictionary<string,string> _emptyDictionary = new Dictionary<string,string>();

        private WaitForConnectionUIMark _waitForConnectionUIMark;
        
        public ResetPresenter(WaitForConnectionUIMark waitForConnectionUIMark)
        {
            _waitForConnectionUIMark = waitForConnectionUIMark;
        }
        
        public void SendResetRequest()
        {
            var request = new Request()
            {
                msgHandlerName = MessageHandlerNames.ResetMessageHandlerName,
                fields = _emptyDictionary
            };
            var response = ClientServerAdapter.Instance.SendRequest(request);
            Debug.Log($"Response came back from {MessageHandlerNames.ResetMessageHandlerName}, status = {response.status}, Fields = {response.fields.ToDebugString()}");

            if (response.status == 200)
            {
                GameplayState.ResetHitted = true;
            }
        }
    }
}