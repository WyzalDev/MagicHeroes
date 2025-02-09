using magic_heroes.Client.Presenter;
using UnityEngine;
using Zenject;

namespace magic_heroes.Client.View
{
    public class ResetView : MonoBehaviour
    {
        private ResetPresenter _resetPresenter;
        
        [Inject]
        private void Contruct(ResetPresenter resetPresenter)
        {
            _resetPresenter = resetPresenter;
        }
        public void OnButtonClick()
        {
            _resetPresenter.SendResetRequest();
        }
    }
}