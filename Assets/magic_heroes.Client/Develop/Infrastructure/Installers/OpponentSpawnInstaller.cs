using magic_heroes.Client.Develop.Character;
using UnityEngine;
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
                .InstantiatePrefabForComponent<OpponentMarker>(opponentPrefab, spawnPoint.position,
                    Quaternion.Euler(0,180,0), null);
            
            Container
                .Bind<OpponentMarker>()
                .FromInstance(opponentInstance)
                .AsSingle();
        }
    }
}