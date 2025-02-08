using magic_heroes.Client.Develop.View;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace magic_heroes.Client.Infrastructure.Installers
{
    public class OpponentSpawnInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject opponentPrefab;
        
        [SerializeField]
        private Transform spawnPoint;

        public override void InstallBindings()
        {
            var opponentInstance = Container
                .InstantiatePrefabForComponent<OpponentView>(opponentPrefab, spawnPoint.position,
                    Quaternion.Euler(0,180,0), null);

            opponentInstance.CharacterInfo = new Develop.View.CharacterInfo()
            {
                hpBar = opponentInstance.GetComponentInChildren<Image>().GetComponentsInChildren<Image>()[1]
            };

            Container
                .Bind<OpponentView>()
                .FromInstance(opponentInstance)
                .AsSingle();
            Debug.Log($"Instantiated OpponentMarker");
        }
    }
}