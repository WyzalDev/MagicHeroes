﻿using System.Collections.Generic;
using magic_heroes.Client.View;
using UnityEngine;
using Zenject;

namespace magic_heroes.Client.Infrastructure.Installers
{
    public class SpellsUIInstaller : MonoInstaller
    {
        private const int SPELL_COUNT = 5;
        
        //first SPELL_COUNT spells will initializes
        [SerializeField] private List<GameObject> _spellsParentCanvases;
        [SerializeField] private List<Sprite> _spellSprites;
        
        [SerializeField] private GameObject _spellPrefab;
        
        public override void InstallBindings()
        {
            if (_spellsParentCanvases.Count < SPELL_COUNT || _spellSprites.Count < SPELL_COUNT) return;
            var spellViews = new List<SpellView>();
            for (var i = 0; i < SPELL_COUNT; i++)
            {
                var spellInstance =
                    Container.InstantiatePrefabForComponent<SpellView>(_spellPrefab, _spellsParentCanvases[i].transform);
                spellInstance.sprite = _spellSprites[i];
                spellInstance.order = i;
                spellViews.Add(spellInstance);
            }
            
            Container.Bind<List<SpellView>>().FromInstance(spellViews).AsSingle();
            
            Debug.Log($"Instantiated {SPELL_COUNT} spells");
        }
    }
}