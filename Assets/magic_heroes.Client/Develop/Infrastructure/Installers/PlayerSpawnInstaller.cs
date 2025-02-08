using magic_heroes.Client.Develop.Character;
using UnityEngine;
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
                .InstantiatePrefabForComponent<PlayerMarker>(playerPrefab, spawnPoint.position,
                    Quaternion.identity, null);
            
            Container
                .Bind<PlayerMarker>()
                .FromInstance(playerInstance)
                .AsSingle();
            Debug.Log("Instantiated PlayerMarker");
        }
    }
}