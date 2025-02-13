using magic_heroes.Client.UI;
using UnityEngine;
using Zenject;

namespace magic_heroes.Client.Infrastructure.Installers
{
    public class UIActivatorInstaller : MonoInstaller
    {
        [SerializeField] private Canvas allSceneUICanvas;
        
        [SerializeField] private SceneUIActivatorMark uiActivatorPrefab;

        public override void InstallBindings()
        {
            var uiActivatorInstance = Container.InstantiatePrefab(uiActivatorPrefab).GetComponent<SceneUIActivatorMark>();
            uiActivatorInstance.allUICanvas = allSceneUICanvas;
        }
    }
}