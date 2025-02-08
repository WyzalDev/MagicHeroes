using magic_heroes.Client.Develop.View;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace magic_heroes.Client.Infrastructure.Installers
{
    public class PlayerSpawnInstaller : MonoInstaller
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject playerPrefab;

        public override void InstallBindings()
        {
            var playerInstance = Container
                .InstantiatePrefabForComponent<PlayerView>(playerPrefab, spawnPoint.position,
                    Quaternion.identity, null);

            playerInstance.CharacterInfo = new Develop.View.CharacterInfo()
            {
                hpBar = playerInstance.GetComponentInChildren<Image>().GetComponentsInChildren<Image>()[1]
            };

            Container
                .Bind<PlayerView>()
                .FromInstance(playerInstance)
                .AsSingle();
            Debug.Log("Instantiated PlayerMarker");
        }
    }
}