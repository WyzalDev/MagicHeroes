using System;
using System.Collections.Generic;
using System.Linq;
using magic_heroes.Client.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace magic_heroes.Client.Infrastructure.Installers
{
    public class PlayersSpawnInstaller : MonoInstaller
    {
        [Header("Opponent and player settings")]
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform opponentSpawnPoint;
        
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject opponentPrefab;
        
        [Header("Active effects settings")]
        [SerializeField] private GameObject activeEffectPrefab;
        [Tooltip("activeEffectIcons and activeEffectNames lists are represent concrete active effects in front of the HP bar. Each element must be matched to elements in activeEffectNames list.")]
        [SerializeField] private List<Sprite> activeEffectIcons;
        [Tooltip("activeEffectIcons and activeEffectNames lists are represent concrete active effects in front of the HP bar. Each element must be matched to elements in activeEffectIcons list.")]
        [SerializeField] private List<EffectName> activeEffectNames;

        public override void InstallBindings()
        {
            //player
            var playerInstance = Container
                .InstantiatePrefabForComponent<PlayerView>(playerPrefab, playerSpawnPoint.position,
                    Quaternion.identity, null);
            var playerActiveEffectGridLayoutTransform = playerInstance.GetComponentInChildren<GridLayoutGroup>().transform;
            
            //player CharacterInfo
            playerInstance.CharacterInfo = new View.CharacterInfo()
            {
                hpBar = playerInstance.GetComponentInChildren<Canvas>().GetComponentsInChildren<Image>()[1],
                currentActiveEffectsObjects = InstantiateActiveEffects(playerActiveEffectGridLayoutTransform)
            };
            
            //bind playerView
            Container
                .Bind<PlayerView>()
                .FromInstance(playerInstance)
                .AsSingle();
            Debug.Log("Binded PlayerView");
            
            //opponent
            var opponentInstance = Container
                .InstantiatePrefabForComponent<OpponentView>(opponentPrefab, opponentSpawnPoint.position,
                    Quaternion.Euler(0,180,0), null);
            var opponentActiveEffectGridLayoutTransform = opponentInstance.GetComponentInChildren<GridLayoutGroup>().transform;
            
            //opponent CharacterInfo
            opponentInstance.CharacterInfo = new View.CharacterInfo()
            {
                hpBar = opponentInstance.GetComponentInChildren<Canvas>().GetComponentsInChildren<Image>()[1],
                currentActiveEffectsObjects = InstantiateActiveEffects(opponentActiveEffectGridLayoutTransform)
            };
            
            //bind opponentView
            Container
                .Bind<OpponentView>()
                .FromInstance(opponentInstance)
                .AsSingle();
            Debug.Log($"Binded OpponentView");
        }

        private List<ActiveEffect> InstantiateActiveEffects(Transform parent)
        {
            var result = new List<ActiveEffect>();
            foreach (var activeEffect in activeEffectIcons.Zip(activeEffectNames, Tuple.Create))
            {
                var activeEffectInstance = Container.InstantiatePrefabForComponent<ActiveEffect>(activeEffectPrefab, parent);
                activeEffectInstance.GetComponentInChildren<Image>().sprite = activeEffect.Item1;
                activeEffectInstance.activeEffectName = activeEffect.Item2;
                activeEffectInstance.gameObject.SetActive(false);
                result.Add(activeEffectInstance);
            }
            return result;
        }
    }
}