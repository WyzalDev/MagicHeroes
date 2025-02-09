using System;
using UnityEngine;
using UnityEngine.UI;

namespace magic_heroes.Client.View
{
    public class SpellView : MonoBehaviour
    {
        public int order { get; set; }
        
        private Sprite _icon;
        
        public Sprite sprite
        {
            get => _icon;
            set
            {
                _icon = value;
                GetComponentInChildren<Image>().sprite = value;
            }
        }
    }
}