using System.Collections;
using magic_heroes.Client.Presenter;
using UnityEngine;
using Zenject;

namespace magic_heroes.Client.UI
{
    public class SceneUIActivatorMark : MonoBehaviour
    {
        public Canvas allUICanvas {get; set; }

        private IConnectionPresenter _connectionPresenter;

        [Inject]
        private void Construct(IConnectionPresenter connectionPresenter)
        {
            _connectionPresenter = connectionPresenter;
        }

        private void Start()
        {
            StartCoroutine(SwitchActivationTriggerHandler());
            Debug.Log("SceneUIActivatorMark constructed");
        }

        private IEnumerator SwitchActivationTriggerHandler()
        {
            do
            {
                allUICanvas?.gameObject.SetActive(_connectionPresenter.isConnected);
                yield return null;
            } while (true);
        }
    }
}